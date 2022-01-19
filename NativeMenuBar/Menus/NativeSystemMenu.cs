using System;
using System.Collections.Generic;
using System.Text;

namespace NativeMenuBar.Menus
{
	/// <summary>
	/// Windows APIを使用したシステムメニュー
	/// </summary>
	public class NativeSystemMenu : NativeMenu
	{
		/// <inheritdoc />
		public NativeSystemMenu(IntPtr hWnd)
		{
			base.hWnd = hWnd;
			Handle = NativeMethod.GetSystemMenu(hWnd, false);
		}

		/// <inheritdoc />
        public override void SetMenu(IntPtr hWnd)
		{
			WndProc.StartHook(hWnd);
			SetHookInternal();
		}

		/// <summary>
		/// システムメニューへメニューを設定します。
		/// </summary>
		public void SetMenu()
		{
			SetMenu(hWnd);
		}

		/// <inheritdoc/>
		public override void Dispose()
		{
			WndProc.StopHook(hWnd);
		}
	}
}
