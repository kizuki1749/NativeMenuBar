using NativeMenuBar.Hooks;
using NativeMenuBar.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.Menus
{
	/// <summary>
	/// Windows APIを使用したメニューバー
	/// </summary>
	public class NativeMenu : NativeMenuBase
	{
		private const uint WM_COMMAND = 0x0111;
		private const uint WM_SYSCOMMAND = 0x0112;

		/// <summary>
		/// ウィンドウメッセージを処理するクラスのインスタンス
		/// </summary>
		protected IWindowMessageHook WndProc = new DefaultWindowMessageHook();

		/// <summary>
		/// 対象のウィンドウハンドル
		/// </summary>
		protected IntPtr hWnd;

		/// <inheritdoc />
		public NativeMenu() : base()
		{
			Handle = NativeMethod.CreateMenu();
		}

		/// <summary>
		/// コンストラクタ(独自実装のフックを使用)
		/// </summary>
		/// <param name="hookProvider">フックに使用するインスタンス</param>
		public NativeMenu(IWindowMessageHook hookProvider) : this()
		{
			WndProc = hookProvider;
		}

		/// <summary>
		/// 対象のウィンドウにあるメニューバーを再描画します。
		/// </summary>
		public virtual void Repaint()
		{
			NativeMethod.DrawMenuBar(hWnd);
		}

		/// <inheritdoc/>
		public override NativeMenuItemBase AddMenuItem(NativeMenuItemBase menuItem)
		{
			var result = base.AddMenuItem(menuItem);
			if (!(this is NativePopupMenu) && this is NativeMenu)
				Repaint();
			return result;
		}

		/// <inheritdoc/>
		public override NativeMenuItemBase InsertMenuItem(uint index, NativeMenuItemBase menuItem)
		{
			base.InsertMenuItem(index, menuItem);
			return menuItem;
		}

		/// <inheritdoc/>
		public override void DeleteMenuItem(NativeMenuItemBase menuItem)
		{
			base.DeleteMenuItem(menuItem);
			Repaint();
		}

		/// <inheritdoc/>
		public override void DeleteMenuItem(int index)
		{
			base.DeleteMenuItem(index);
			Repaint();
		}

		/// <summary>
		/// 指定したウィンドウハンドルへメニューを設定します。
		/// </summary>
		/// <param name="hWnd">対象のウィンドウのハンドル</param>
		public virtual void SetMenu(IntPtr hWnd)
		{
			if (!NativeMethod.SetMenu(hWnd, Handle))
				throw new InvalidOperationException("メニューの設定に失敗しました。");
			this.hWnd = hWnd;
			SetHookInternal();
			WndProc.StartHook(hWnd);
		}

		/// <summary>
		/// 指定したウィンドウハンドルに設定されているメニューを解除します。
		/// </summary>
		/// <param name="hWnd">対象のウィンドウのハンドル</param>
		public virtual void RemoveMenu(IntPtr hWnd)
		{
			NativeMethod.SetMenu(hWnd, IntPtr.Zero);
			this.hWnd = hWnd;
			RemoveHookInternal();
			WndProc.StopHook(hWnd);
		}

		/// <summary>
		/// ウィンドウメッセージを取得するフックを設定します。(上級者向け)
		/// </summary>
		protected void SetHookInternal()
		{
			WndProc.Hook += Hook;
		}

		/// <summary>
		/// ウィンドウメッセージを取得するフックを解除します。(上級者向け)
		/// </summary>
		protected void RemoveHookInternal()
		{
			WndProc.Hook -= Hook;
		}

		/// <summary>
		/// ウィンドウメッセージ受信時に実行されます。
		/// </summary>
		/// <param name="hWnd">送信元のウィンドウハンドル</param>
		/// <param name="msg">ウィンドウメッセージ</param>
		/// <param name="wParam">パラメーター1</param>
		/// <param name="lParam">パラメーター2</param>
		protected void Hook(IntPtr hWnd, uint msg, uint wParam, int lParam)
		{
			if (msg == WM_COMMAND || msg == WM_SYSCOMMAND)
				SearchRunMethod(wParam);
		}

		/// <inheritdoc/>
		public override void Dispose()
		{
			base.Dispose();
			WndProc.StopHook(hWnd);
		}
	}
}
