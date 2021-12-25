using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar
{
    /// <summary>
    /// NativeMenuのオプションを指定します。
    /// </summary>
    public static class NativeMenuRegisterOption
    {
        /// <summary>
		/// メニューの項目テキストにUnicodeを使用するかどうかを取得、設定します。
		/// </summary>
		public static bool UseUnicode { get; set; } = false;
    }
}
