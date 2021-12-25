using NativeMenuBar.MenuItems;
using NativeMenuBar.Menus;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.Builders
{
	/// <summary>
	/// ポップアップメニュー項目のビルダークラス
	/// </summary>
	public class NativeMenuPopupItemBuilder : NativeMenuItemBuilderBase<NativeMenuPopupItem, NativeMenuPopupItemBuilder>
	{
		/// <summary>
		/// サブメニューの項目を取得します。
		/// </summary>
		public ImmutableList<NativeMenuItemBase> SubMenuItems { get => (ImmutableList<NativeMenuItemBase>)SubMenu.Items; }

		/// <summary>
		/// 登録されているサブメニュー
		/// </summary>
		protected NativePopupMenu SubMenu;

		/// <inheritdoc/>
		public NativeMenuPopupItemBuilder() : base()
		{
			Item = new NativeMenuPopupItem("", new NativePopupMenu());
			SubMenu = Item.SubMenu;
			_option = new NativeMenuItemOptionBuilder(Item);
		}

		/// <summary>
		/// サブメニューの項目を設定します。
		/// </summary>
		/// <param name="SubMenuItems">登録する項目</param>
		/// <returns>現在のインスタンス</returns>
		public NativeMenuPopupItemBuilder SetSubMenuItems(params NativeMenuItemBase[] SubMenuItems)
		{
			SetSubMenuItemsFromArray(SubMenuItems);
			return this;
		}

		/// <summary>
		/// サブメニューの項目を設定します。
		/// </summary>
		/// <param name="SubMenuItems">登録する項目の配列</param>
		/// <returns>現在のインスタンス</returns>
		public NativeMenuPopupItemBuilder SetSubMenuItemsFromArray(NativeMenuItemBase[] SubMenuItems)
		{
			while (SubMenu.Items.Count > 0)
				SubMenu.DeleteMenuItem(0);
			foreach (NativeMenuItemBase item in SubMenuItems)
				SubMenu.AddMenuItem(item);
			return this;
		}

		/// <inheritdoc/>
		public override NativeMenuPopupItem Build()
		{
			base.Build();
			Item.SubMenu = SubMenu;
			if (!Item.Flags.HasFlag(NativeMenuFlags.MF_POPUP))
				Item.Flags |= NativeMenuFlags.MF_POPUP;
			return Item;
		}
	}
}
