using NativeMenuBar.MenuItems;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.Builders
{
	/// <summary>
	/// メニュー項目のオプションを指定します。
	/// </summary>
	public class NativeMenuItemOptionBuilder : IBuilder<NativeMenuFlags>
	{
		/// <summary>
		/// メニューの改行の設定
		/// </summary>
		public enum MenuBreakOperationType
		{
			/// <summary>
			/// 指定なし
			/// </summary>
			None = 0,

			/// <summary>
			/// 新しい行または列に描画(区切り線あり)
			/// これ以降に描画されるアイテムはすべて新しい行または列に描画されます。
			/// </summary>
			MenuBarBreak,

			/// <summary>
			/// 新しい行または列に描画(区切り線なし)
			/// これ以降に描画されるアイテムはすべて新しい行または列に描画されます。
			/// </summary>
			MenuBreak
		}

		NativeMenuFlags MenuItemFlags;

		/// <summary>
		/// メニュー項目を無効にするかを取得、設定します。
		/// </summary>
		public bool IsDisabled
		{
			get => MenuItemFlags.HasFlag(NativeMenuFlags.MF_GRAYED);
			set
			{
				if (!MenuItemFlags.HasFlag(NativeMenuFlags.MF_GRAYED) && value)
					MenuItemFlags |= NativeMenuFlags.MF_GRAYED;
				else if (MenuItemFlags.HasFlag(NativeMenuFlags.MF_GRAYED) && !value)
					MenuItemFlags &= ~NativeMenuFlags.MF_GRAYED;
			}
		}

		/// <summary>
		/// メニュー項目がチェックされているかを取得、設定します。
		/// </summary>
		public bool IsChecked
		{
			get => MenuItemFlags.HasFlag(NativeMenuFlags.MF_CHECKED);
			set
			{
				if (!MenuItemFlags.HasFlag(NativeMenuFlags.MF_CHECKED) && value)
					MenuItemFlags |= NativeMenuFlags.MF_CHECKED;
				else if (MenuItemFlags.HasFlag(NativeMenuFlags.MF_CHECKED) && !value)
					MenuItemFlags &= ~NativeMenuFlags.MF_CHECKED;
			}
		}

		/// <summary>
		/// メニュー項目を改行するかを取得、設定します。
		/// </summary>
		public MenuBreakOperationType MenuBreak
		{
			get
			{
				if (MenuItemFlags.HasFlag(NativeMenuFlags.MF_MENUBARBREAK))
					return MenuBreakOperationType.MenuBarBreak;
				else if (MenuItemFlags.HasFlag(NativeMenuFlags.MF_MENUBREAK))
					return MenuBreakOperationType.MenuBreak;
				else
					return MenuBreakOperationType.None;
			}
			set
			{
				if (value == MenuBreakOperationType.MenuBarBreak)
				{
					if (!MenuItemFlags.HasFlag(NativeMenuFlags.MF_MENUBARBREAK))
						MenuItemFlags |= NativeMenuFlags.MF_MENUBARBREAK;
					else if (MenuItemFlags.HasFlag(NativeMenuFlags.MF_MENUBREAK))
						MenuItemFlags &= ~NativeMenuFlags.MF_MENUBREAK;
				}
				else if (value == MenuBreakOperationType.MenuBreak)
				{
					if (!MenuItemFlags.HasFlag(NativeMenuFlags.MF_MENUBREAK))
						MenuItemFlags |= NativeMenuFlags.MF_MENUBREAK;
					else if (MenuItemFlags.HasFlag(NativeMenuFlags.MF_MENUBARBREAK))
						MenuItemFlags &= ~NativeMenuFlags.MF_MENUBARBREAK;
				}
				else if (value == MenuBreakOperationType.None)
				{
					if (MenuItemFlags.HasFlag(NativeMenuFlags.MF_MENUBREAK))
						MenuItemFlags &= ~NativeMenuFlags.MF_MENUBREAK;
					if (MenuItemFlags.HasFlag(NativeMenuFlags.MF_MENUBARBREAK))
						MenuItemFlags &= ~NativeMenuFlags.MF_MENUBARBREAK;
				}
			}
		}

		internal NativeMenuItemOptionBuilder(NativeMenuItem MenuItem)
		{
			MenuItemFlags = MenuItem.Flags;
		}

		/// <summary>
		/// メニュー項目を無効にするかを設定します。
		/// </summary>
		/// <param name="Disabled">メニュー項目を無効にするか</param>
		/// <returns>現在のインスタンス</returns>
		public NativeMenuItemOptionBuilder WithDisabled(bool Disabled)
		{
			IsDisabled = Disabled;
			return this;
		}

		/// <summary>
		/// メニュー項目を改行するかを設定します。
		/// </summary>
		/// <param name="Operation">メニュー項目を改行するか</param>
		/// <returns>現在のインスタンス</returns>
		public NativeMenuItemOptionBuilder WithMenuBreak(MenuBreakOperationType Operation)
		{
			MenuBreak = Operation;
			return this;
		}

		/// <summary>
		/// 設定をビルドします。
		/// </summary>
		/// <returns>ビルド結果</returns>
		public NativeMenuFlags Build()
		{
			return MenuItemFlags;
		}
	}
}
