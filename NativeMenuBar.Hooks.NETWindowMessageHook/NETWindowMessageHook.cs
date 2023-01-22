using System;
using System.Windows.Forms;

namespace NativeMenuBar.Hooks
{
	/// <summary>
	/// ウィンドウメッセージを受け取るためのフック。NET Coreや.NET 5以降で使用されるWinFormsに使用する場合はこちらを使用。
	/// </summary>
	public class NETWindowMessageHook : IWindowMessageHook
	{
		private WindowHook hook;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public NETWindowMessageHook()
		{
		}

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
			hook = new WindowHook(this, hwnd);
		}

		/// <summary>
		/// フックを停止します。
		/// </summary>
		/// <param name="hwnd">対象のウィンドウハンドル</param>
		public void StopHook(IntPtr hwnd)
		{
			hook.DestroyHandle();
			hook.ReleaseHandle();
		}

		private int WndProc(IntPtr hwnd, uint msg, uint wParam, int lParam)
		{
			Hook(hwnd, msg, wParam, lParam);
			return 0;
		}

		private class WindowHook : NativeWindow
		{
			private NETWindowMessageHook _hook;

			public WindowHook(NETWindowMessageHook hook, IntPtr handle)
			{
				_hook = hook;
				AssignHandle(handle);
			}

			protected override void WndProc(ref Message m)
			{
				base.WndProc(ref m);
				_hook.WndProc(m.HWnd, (uint)(ulong)m.Msg, (uint)(ulong)m.WParam, (int)(long)m.LParam);
			}
		}
	}
}
