using NativeMenuBar.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.Hooks
{
    public delegate void WndProcHookDelegate(IntPtr hWnd, uint msg, uint wParam, int lParam);
    public interface IWindowMessageHook
    {
        event WndProcHookDelegate Hook;
        void StartHook(IntPtr hwnd);
        void StopHook(IntPtr hwnd);
    }
}
