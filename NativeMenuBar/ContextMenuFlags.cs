using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar
{
    /// <summary>
    /// コンテキストメニューの表示オプション
    /// </summary>
    [Serializable]
    [Flags]
    public enum ContextMenuFlags : uint
    {
        /// <summary>
        /// 指定座標に左揃え
        /// </summary>
        TPM_LEFTALIGN = 0x0,

        /// <summary>
        /// 指定座標に中央揃え(X軸)
        /// </summary>
        TPM_CENTERALIGN = 0x4,

        /// <summary>
        /// 指定座標に右揃え
        /// </summary>
        TPM_RIGHTALIGN = 0x8,

        /// <summary>
        /// 指定座標に上揃え
        /// </summary>
        TPM_TOPALIGN = 0x0,

        /// <summary>
        /// 指定座標に中央揃え(X軸)
        /// </summary>
        TPM_VCENTERALIGN = 0x10,

        /// <summary>
        /// 指定座標に下揃え
        /// </summary>
        TPM_BOTTOMALIGN = 0x20,

        /// <summary>
        /// メニュー項目をクリックしても通知メッセージを送信しない
        /// </summary>
        TPM_NONOTIFY = 0x80,

        /// <summary>
        /// 選択したメニュー項目識別子を返す
        /// </summary>
        TPM_RETURNCMD = 0x100,

        /// <summary>
        /// 左クリックのみで選択できる
        /// </summary>
        TPM_LEFTBUTTON = 0x0,

        /// <summary>
        /// 左クリックと右クリックの両方でクリックできる
        /// </summary>
        TPM_RIGHTBUTTON = 0x2,

        ///// <summary>
        ///// 左から右にアニメーション
        ///// </summary>
        //TPM_HORPOSANIMATION = 0x400,

        ///// <summary>
        ///// 右から左にアニメーション
        ///// </summary>
        //TPM_HORNEGANIMATION = 0x800,

        ///// <summary>
        ///// 上から下にアニメーション
        ///// </summary>
        //TPM_VERPOSANIMATION = 0x1000,

        ///// <summary>
        ///// 下から上にアニメーション
        ///// </summary>
        //TPM_VERNEGANIMATION = 0x2000,

        ///// <summary>
        ///// アニメーションなし
        ///// </summary>
        //TPM_NOANIMATION = 0x2000,
    }
}
