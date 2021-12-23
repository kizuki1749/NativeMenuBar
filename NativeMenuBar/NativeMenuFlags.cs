using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar
{
	/// <summary>
	/// 詳細は、 https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-appendmenua 参照。
	/// </summary>
	[Serializable]
	[Flags]
	public enum NativeMenuFlags : uint
	{
		/// <summary>
		/// テキスト文字列
		/// </summary>
		MF_STRING = 0x0,

		/// <summary>
		/// チェックされていない
		/// </summary>
		MF_UNCHECKED = 0x0,

		/// <summary>
		/// 有効
		/// </summary>
		MF_ENABLED = 0x0,

		/// <summary>
		/// uPositionにメニュー項目のIDを使用する
		/// </summary>
		MF_BYCOMMAND = 0x0,

		/// <summary>
		/// uPositionに0から始まるインデックスを使用する
		/// </summary>
		MF_BYPOSITION = 0x400,

		/// <summary>
		/// 無効
		/// </summary>
		MF_GRAYED = 0x1,

		/// <summary>
		/// 無効(グレーアウトしない)
		/// </summary>
		MF_DISABLED = 0x2,

		/// <summary>
		/// メニューにBitmap画像を使用
		/// </summary>
		MF_BITMAP = 0x4,

		/// <summary>
		/// チェックされている
		/// </summary>
		MF_CHECKED = 0x8,

		/// <summary>
		/// サブメニューを設定
		/// </summary>
		MF_POPUP = 0x10,

		/// <summary>
		/// 新しい行または列に描画(区切り線あり)
		/// これ以降に描画されるアイテムはすべて新しい行または列に描画されます。
		/// </summary>
		MF_MENUBARBREAK = 0x20,

		/// <summary>
		/// 新しい行または列に描画(区切り線なし)
		/// これ以降に描画されるアイテムはすべて新しい行または列に描画されます。
		/// </summary>
		MF_MENUBREAK = 0x40,

		/// <summary>
		/// オーナードロー
		/// </summary>
		MF_OWNERDRAW = 0x100,

		/// <summary>
		/// 区切り線
		/// </summary>
		MF_SEPARATOR = 0x800
	}
}
