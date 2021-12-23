using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar
{
	internal static class NativeMethod
	{
		[DllImport("user32.dll")]
		public static extern IntPtr CreateMenu();

		[DllImport("user32.dll")]
		public static extern IntPtr CreatePopupMenu();

		[DllImport("user32.dll")]
		public static extern IntPtr DestroyMenu(IntPtr hMenu);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetMenu(IntPtr hWnd, IntPtr hMenu);

		[DllImport("user32.dll", CharSet = CharSet.Ansi)]
		public static extern bool AppendMenuA(IntPtr hMenu, NativeMenuFlags uFlags, uint uIDNewItem, string lpNewItem);

		[DllImport("user32.dll", CharSet = CharSet.Ansi)]
		public static extern bool AppendMenuA(IntPtr hMenu, NativeMenuFlags uFlags, IntPtr uIDNewItem, string lpNewItem);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern bool AppendMenuW(IntPtr hMenu, NativeMenuFlags uFlags, uint uIDNewItem, string lpNewItem);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern bool AppendMenuW(IntPtr hMenu, NativeMenuFlags uFlags, IntPtr uIDNewItem, string lpNewItem);

		[DllImport("user32.dll", CharSet = CharSet.Ansi)]
		public static extern bool InsertMenuA(IntPtr hMenu, uint uPosition, NativeMenuFlags uFlags, uint uIDNewItem, string lpNewItem);

		[DllImport("user32.dll", CharSet = CharSet.Ansi)]
		public static extern bool InsertMenuA(IntPtr hMenu, uint uPosition, NativeMenuFlags uFlags, IntPtr uIDNewItem, string lpNewItem);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern bool InsertMenuW(IntPtr hMenu, uint uPosition, NativeMenuFlags uFlags, uint uIDNewItem, string lpNewItem);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern bool InsertMenuW(IntPtr hMenu, uint uPosition, NativeMenuFlags uFlags, IntPtr uIDNewItem, string lpNewItem);

		[DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern bool ModifyMenuA(IntPtr hMenu, uint uPosition, NativeMenuFlags uFlags, uint uIDNewItem, string lpNewItem);

        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern bool ModifyMenuA(IntPtr hMenu, uint uPosition, NativeMenuFlags uFlags, IntPtr uIDNewItem, string lpNewItem);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern bool ModifyMenuW(IntPtr hMenu, uint uPosition, NativeMenuFlags uFlags, uint uIDNewItem, string lpNewItem);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern bool ModifyMenuW(IntPtr hMenu, uint uPosition, NativeMenuFlags uFlags, IntPtr uIDNewItem, string lpNewItem);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern bool DeleteMenu(IntPtr hMenu, uint uPosition, NativeMenuSelectorFlags uFlags);

		[DllImport("user32.dll")]
		public static extern bool SetMenuItemBitmaps(IntPtr hMenu, uint uPosition, NativeMenuSelectorFlags uFlags, IntPtr hBitmapUnchecked, IntPtr hBitmapChecked);

		[DllImport("user32.dll")]
		public static extern bool DrawMenuBar(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern int TrackPopupMenuEx(IntPtr hMenu, ContextMenuFlags uFlags, int x, int y, IntPtr hWnd, IntPtr lptpm);

		[DllImport("user32.dll")]
		public static extern bool HiliteMenuItem(IntPtr hWnd, IntPtr hMenu, uint uIDHiliteItem, NativeMenuHighliteFlags uHilite);

		//[DllImport("user32.dll")]
		//public static extern bool GetMenuItemInfoA(IntPtr hMenu, uint item, bool fByPosition, IntPtr lpmii);

		//[DllImport("user32.dll")]
		//public static extern bool SetMenuItemInfoA(IntPtr hMenu, uint item, bool fByPosition, IntPtr lpmii);

		[DllImport("user32.dll")]
		public static extern IntPtr GetActiveWindow();
	}
}
