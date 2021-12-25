using NativeMenuBar.MenuItems;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.Menus
{
	/// <summary>
	/// ポップアップメニュー
	/// </summary>
	public class NativePopupMenu : NativeMenu
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public NativePopupMenu() : base()
		{
			Handle = NativeMethod.CreatePopupMenu();
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="items">追加する項目の配列</param>
		internal NativePopupMenu(params NativeMenuItemBase[] items) : this()
		{
			foreach (NativeMenuItemBase item in items)
				base.AddMenuItem(item);
		}

		/// <summary>
		/// 現在のインスタンスからNativeMenuPopupItemを生成します。
		/// </summary>
		/// <param name="text">メニュー項目に表示されるテキスト</param>
		/// <returns></returns>
		public NativeMenuPopupItem CreateNativeMenuPopupItem(string text)
		{
			NativeMenuPopupItem item = new NativeMenuPopupItem(text, this);
			return item;
		}

		/// <summary>
		/// コンテキストメニューを表示します。
		/// </summary>
		/// <param name="x">表示位置X</param>
		/// <param name="y">表示位置Y</param>
		/// <param name="flags">表示オプション</param>
		/// <param name="hWnd">対象のウィンドウハンドル</param>
		public virtual void ShowContextMenu(int x, int y, ContextMenuFlags flags, IntPtr hWnd)
		{
			int result = NativeMethod.TrackPopupMenuEx(Handle, flags | ContextMenuFlags.TPM_RETURNCMD, x, y, hWnd, IntPtr.Zero);
			if (result > 0)
				SearchRunMethod((uint)result);
		}

		/// <summary>
		/// この項目では未使用。
		/// </summary>
		/// <exception cref="NotImplementedException"></exception>
		public override void Repaint()
		{
			throw new NotImplementedException("この操作は出来ません。");
		}
	}
}
