using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar
{
	[Serializable]
	internal enum NativeMenuSelectorFlags : uint
    {
		/// <summary>
		/// uPositionにメニュー項目のIDを使用する
		/// </summary>
		MF_BYCOMMAND = 0x0,

		/// <summary>
		/// uPositionに0から始まるインデックスを使用する
		/// </summary>
		MF_BYPOSITION = 0x400
    }
}
