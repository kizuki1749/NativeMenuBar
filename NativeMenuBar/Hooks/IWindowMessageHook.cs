using NativeMenuBar.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.Hooks
{
	/// <summary>
	/// 内部フックに使用するデリゲート
	/// </summary>
	/// <param name="hWnd">送信元のウィンドウハンドル</param>
	/// <param name="msg">メッセージ</param>
	/// <param name="wParam">パラメーター1</param>
	/// <param name="lParam">パラメーター2</param>
	public delegate void WndProcHookDelegate(IntPtr hWnd, uint msg, uint wParam, int lParam);

	/// <summary>
	/// ウィンドウメッセージを処理するインターフェース
	/// </summary>
	public interface IWindowMessageHook
	{
		/// <summary>
		/// ウィンドウメッセージ受信時にこのイベントを実行してください。
		/// </summary>
		event WndProcHookDelegate Hook;

		/// <summary>
		/// フック開始時に呼び出されます。
		/// </summary>
		/// <param name="hwnd">対象のウィンドウハンドル</param>
		void StartHook(IntPtr hwnd);

		/// <summary>
		/// フック終了時に呼び出されます。
		/// </summary>
		/// <param name="hwnd">対象のウィンドウハンドル</param>
		void StopHook(IntPtr hwnd);
	}
}
