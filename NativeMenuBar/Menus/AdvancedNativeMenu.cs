using NativeMenuBar.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.Menus
{
    /// <summary>
    /// 上級者向け機能が使えるWindows APIを使用したメニューバー
    /// </summary>
    public class AdvancedNativeMenu : NativeMenu
    {
		/// <inheritdoc />
		public AdvancedNativeMenu() : base()
		{
		}

		/// <inheritdoc/>
		public AdvancedNativeMenu(IWindowMessageHook hookProvider) : base(hookProvider)
		{
		}

		/// <summary>
		/// ウィンドウメッセージを取得するフックを設定します。(上級者向け)
		/// </summary>
		public virtual void SetHook()
		{
			SetHookInternal();
		}

		/// <summary>
		/// ウィンドウメッセージを取得するフックを解除します。(上級者向け)
		/// </summary>
		public virtual void RemoveHook()
		{
			RemoveHookInternal();
		}
	}
}
