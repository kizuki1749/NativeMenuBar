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
		public ImmutableList<NativeMenuPopupItem> SubMenuItems { get => (ImmutableList<NativeMenuPopupItem>)SubMenu.Items; }

		protected NativePopupMenu SubMenu;

		public NativeMenuPopupItemBuilder() : base()
		{
			Item = new NativeMenuPopupItem("", new NativePopupMenu());
			SubMenu = Item.SubMenu;
			_option = new NativeMenuItemOptionBuilder(Item);
		}

		public NativeMenuPopupItemBuilder SetSubMenuItems(params NativeMenuItemBase[] SubMenuItems)
		{
			SetSubMenuItemsFromArray(SubMenuItems);
			return this;
		}

		public NativeMenuPopupItemBuilder SetSubMenuItemsFromArray(NativeMenuItemBase[] SubMenuItems)
		{
			while (SubMenu.Items.Count > 0)
				SubMenu.DeleteMenuItem(0);
			foreach (NativeMenuItemBase item in SubMenuItems)
				SubMenu.AddMenuItem(item);
			return this;
		}

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
