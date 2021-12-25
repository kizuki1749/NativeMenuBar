using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar
{
    [Obsolete("現段階では未使用", true)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 512)]
    public struct MENUITEMINFO
    {
        public uint cbSize;
        public MaskFlags fMask;
        public uint fType;
        public uint wID;
        public IntPtr hSubMenu;
        public IntPtr hbmpChecked;
        public IntPtr hbmpUnchecked;
        public object dwItemData;
        public string dwTypeData;
        public uint cch;
        public IntPtr hbmpItem;
    }
}
