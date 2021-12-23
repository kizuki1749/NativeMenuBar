using MessagePack;
using NativeMenuBar.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.MenuItems
{
	[Serializable]
	public abstract class NativeMenuItemBase : IDisposable
	{
		public NativeMenuFlags Flags { get; set; }
		[IgnoreMember]
		public NativeMenuBase Parent { get; set; }
		protected IntPtr Handle { get; set; }

		public NativeMenuItemBase()
		{
		}

		internal abstract void Register(IntPtr menuHandle);
		internal abstract void RegisterInsert(IntPtr menuHandle, uint index, NativeMenuFlags flags);

		internal virtual void UnRegister()
		{
			if (!NativeMethod.DeleteMenu(Handle, (uint)GetThisIndex(), NativeMenuSelectorFlags.MF_BYPOSITION))
				throw new InvalidOperationException("メニュー項目の削除に失敗しました。");
			Dispose();
		}

		/// <summary>
		/// 項目を強調します。
		/// </summary>
		/// <param name="hWnd">対象のウィンドウハンドル</param>
		/// <param name="flags">オプション</param>
		/// <exception cref="InvalidOperationException"></exception>
		public virtual void SetHilite(IntPtr hWnd, NativeMenuHighliteFlags flags)
        {
			if (!NativeMethod.HiliteMenuItem(hWnd, Handle, (uint)GetThisIndex(), flags | NativeMenuHighliteFlags.MF_BYPOSITION))
				throw new InvalidOperationException("メニュー項目の更新に失敗しました。");
		}

		/// <summary>
		/// この項目に行った変更を適用します。メニューの種類は変更しないでください。
		/// </summary>
		/// <exception cref="InvalidOperationException"></exception>
		public virtual void Apply()
		{
			if (NativeMenu.UseUnicode)
			{
				if (!NativeMethod.ModifyMenuA(Handle, (uint)GetThisIndex(), Flags | NativeMenuFlags.MF_BYPOSITION, 0, ""))
					throw new InvalidOperationException("メニュー項目の更新に失敗しました。");
			}
			else
			{
				if (!NativeMethod.ModifyMenuW(Handle, (uint)GetThisIndex(), Flags | NativeMenuFlags.MF_BYPOSITION, 0, ""))
					throw new InvalidOperationException("メニュー項目の更新に失敗しました。");
			}
		}

		internal int GetThisIndex()
		{
			if (Parent == null)
				throw new InvalidOperationException("この操作はメニューに追加(AddMenuItem)される前には実行出来ません。");
			return Parent.Items.ToList().IndexOf(this);
		}

		public void Dispose()
		{
		}
    }
}
