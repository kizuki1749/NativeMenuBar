using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar
{
    /// <summary>
    /// 取得または設定するメンバーを指定します。
    /// </summary>
    [Serializable]
    [Flags]
    public enum MaskFlags : uint
    {
        /// <summary>
        /// fState
        /// </summary>
        MIIM_STATE = 0x1,

        /// <summary>
        /// wID
        /// </summary>
        MIIM_ID = 0x2,

        /// <summary>
        /// hSubMenu
        /// </summary>
        MIIM_SUBMENU = 0x4,

        /// <summary>
        /// hbmpChecked、hbmpUnchecked
        /// </summary>
        MIIM_CHECKMARKS = 0x8,

        /// <summary>
        /// fType、dwTypeData
        /// MIIM_BITMAP、MIIM_FTYPE、MIIM_STRINGと同様
        /// </summary>
        MIIM_TYPE = 0x10,

        /// <summary>
        /// dwItemData
        /// </summary>
        MIIM_DATA = 0x20,

        /// <summary>
        /// dwTypeData
        /// </summary>
        MIIM_STRING = 0x40,

        /// <summary>
        /// hbmpItem
        /// </summary>
        MIIM_BITMAP = 0x80,

        /// <summary>
        /// fType
        /// </summary>
        MIIM_FTYPE = 0x100
    }
}
