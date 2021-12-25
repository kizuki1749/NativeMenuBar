using NativeMenuBar.Menus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.MenuItems
{
	/// <summary>
	/// ポップアップのあるメニュー項目
	/// </summary>
	[Serializable]
	public class NativeMenuPopupItem : NativeMenuItem
	{
		internal new IntPtr Id
		{
			get
			{
				return SubMenu.Handle;
			}
		}

		/// <summary>
		/// 表示するサブメニュー
		/// </summary>
		public NativePopupMenu SubMenu { get; protected internal set; }

		internal NativeMenuPopupItem(string text, NativePopupMenu subMenu) : base(text)
		{
			Flags |= NativeMenuFlags.MF_POPUP;
			SubMenu = subMenu;
		}

        internal override void Register(IntPtr menuHandle)
		{
			Handle = menuHandle;
			if (NativeMenuRegisterOption.UseUnicode)
			{
				//LPCWSTR型(WCHAR)
				if (!NativeMethod.AppendMenuW(menuHandle, Flags, Id, Text))
					throw new InvalidOperationException("メニュー項目の登録に失敗しました。");
			}
			else
			{
				//LPCSTR型(char)
				if (!NativeMethod.AppendMenuA(menuHandle, Flags, Id, Text))
					throw new InvalidOperationException("メニュー項目の登録に失敗しました。");
			}
			ApplyIcon(Parent.Items.Count);
		}

		internal override void RegisterInsert(IntPtr menuHandle, uint index, NativeMenuFlags flags)
		{
			Handle = menuHandle;
			if (NativeMenuRegisterOption.UseUnicode)
			{
				//LPCWSTR型(WCHAR)
				if (!NativeMethod.InsertMenuW(menuHandle, index, Flags | flags, Id, Text))
					throw new InvalidOperationException("メニュー項目の登録に失敗しました。");
			}
			else
			{
				//LPCSTR型(char)
				if (!NativeMethod.InsertMenuA(menuHandle, index, Flags | flags, Id, Text))
					throw new InvalidOperationException("メニュー項目の登録に失敗しました。");
			}
			ApplyIcon((int)index);
		}
	}
}
