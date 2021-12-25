using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar
{
	/// <summary>
	/// ハイライトのオプション
	/// </summary>
	[Serializable]
	public enum NativeMenuHighliteFlags : uint
    {
		/// <summary>
		/// uPositionにメニュー項目のIDを使用する
		/// </summary>
		MF_BYCOMMAND = 0x0,

		/// <summary>
		/// uPositionに0から始まるインデックスを使用する
		/// </summary>
		MF_BYPOSITION = 0x400,

		/// <summary>
		/// 項目をハイライトする
		/// </summary>
		MF_HILITE = 0x80,

		/// <summary>
		/// 項目をハイライトしない(デフォルト)
		/// </summary>
		MF_UNHILITE = 0x0,
	}
}
