using NativeMenuBar.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.Hooks
{
	/// <summary>
	/// ウィンドウメッセージを受け取るための標準のフック
	/// </summary>
	public sealed class DefaultWindowMessageHook : IWindowMessageHook
	{
		private delegate int WndProcHookDelegateInternal(IntPtr hWnd, uint msg, uint wParam, int lParam);

		private static int GWL_WNDPROC = -4;
		[DllImport("user32.dll", EntryPoint = "GetWindowLongA")]
		extern static int GetWindowLong(IntPtr hwnd, int nIndex);
		[DllImport("user32.dll", EntryPoint = "SetWindowLongA")]
		extern static int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);
		[DllImport("user32.dll", EntryPoint = "SetWindowLongA")]
		extern static int SetWindowLong(IntPtr hwnd, int nIndex, WndProcHookDelegateInternal dwNewLong);
		[DllImport("user32.dll", EntryPoint = "CallWindowProcA")]
		internal extern static int CallWindowProc(int lpPrevWndFunc, IntPtr hwnd, uint msg, uint wParam, int lParam);

		internal static int lngWnP;

		/// <summary>
		/// ウィンドウメッセージ取得時のイベント
		/// </summary>
		public event WndProcHookDelegate Hook;

		/// <summary>
		/// フックを開始します。
		/// </summary>
		/// <param name="hwnd">対象のウィンドウハンドル</param>
		public void StartHook(IntPtr hwnd)
		{
			lngWnP = GetWindowLong(hwnd, GWL_WNDPROC);
			SetWindowLong(hwnd, GWL_WNDPROC, new WndProcHookDelegateInternal(WndProc));
		}

		/// <summary>
		/// フックを停止します。
		/// </summary>
		/// <param name="hwnd">対象のウィンドウハンドル</param>
		public void StopHook(IntPtr hwnd)
		{
			SetWindowLong(hwnd, GWL_WNDPROC, lngWnP);
		}

		private int WndProc(IntPtr hwnd, uint msg, uint wParam, int lParam)
		{
			Hook(hwnd, msg, wParam, lParam);
			return CallWindowProc(lngWnP, hwnd, msg, wParam, lParam);
		}
	}
}
