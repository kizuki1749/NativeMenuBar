using MessagePack;
using NativeMenuBar.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.Menus
{
	public class NativeMenuBase : IDisposable
	{
		internal IntPtr Handle
		{
			get
			{
				return _handle;
			}
		}

		/// <summary>
		/// 登録されているアイテムの一覧。
		/// </summary>
		[IgnoreMember]
		public IReadOnlyCollection<NativeMenuItemBase> Items
		{
			get
			{
				return _items;
			}
		}

		protected IntPtr _handle;
		protected List<NativeMenuItemBase> _items = new List<NativeMenuItemBase>();

		public NativeMenuBase()
		{
		}

		/// <summary>
		/// メニュー項目を追加します。
		/// </summary>
		/// <param name="menuItem">追加するメニュー項目</param>
		public virtual NativeMenuItemBase AddMenuItem(NativeMenuItemBase menuItem)
		{
			menuItem.Parent = this;
			menuItem.Register(_handle);
			_items.Add(menuItem);
			return menuItem;
		}

		/// <summary>
		/// インデックスの位置にメニュー項目を挿入します。
		/// </summary>
		/// <param name="index">挿入位置を示すインデックス</param>
		/// <param name="menuItem">追加するメニュー項目</param>
		public virtual NativeMenuItemBase InsertMenuItem(uint index, NativeMenuItemBase menuItem)
		{
			menuItem.Parent = this;
			menuItem.RegisterInsert(_handle, index, NativeMenuFlags.MF_BYPOSITION);
			_items.Insert((int)index, menuItem);
			return menuItem;
		}

		/// <summary>
		/// メニュー項目を削除します。
		/// </summary>
		/// <param name="menuItem">削除するメニュー項目</param>
		public virtual void DeleteMenuItem(NativeMenuItemBase menuItem)
		{
			menuItem.UnRegister();
			_items.Remove(menuItem);
		}

		/// <summary>
		/// インデックスを指定してメニュー項目を削除します。
		/// </summary>
		/// <param name="menuItem">削除するメニュー項目のインデックス</param>
		public virtual void DeleteMenuItem(int index)
		{
			_items[index].UnRegister();
			_items.Remove(_items[index]);
		}

		public virtual void Dispose()
		{
			NativeMethod.DestroyMenu(_handle);
		}

		internal bool SearchRunMethod(uint code)
		{
			foreach (var item in Items)
			{
				if (item is NativeMenuItem)
				{
					if (item is NativeMenuPopupItem)
					{
						NativeMenuPopupItem popupItem = (NativeMenuPopupItem)item;
						if (popupItem.SubMenu.SearchRunMethod(code))
							return true;
						else
							continue;
					}
					NativeMenuItem menuItem = (NativeMenuItem)item;
					if (menuItem.Id == code)
					{
						menuItem.PerformClick();
						return true;
					}
				}
			}
			return false;
		}
	}
}
