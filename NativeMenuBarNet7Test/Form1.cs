using NativeMenuBar.Builders;
using NativeMenuBar.Hooks;
using NativeMenuBar.MenuItems;
using NativeMenuBar.Menus;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NativeMenuBarNet7Test
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		NativeMenu menu;
		NativePopupMenu nativePopupMenu;

		private void Form1_Load(object sender, EventArgs e)
		{
			var hook = new NETWindowMessageHook();
			menu = new NativeMenu(hook);

			//テスト項目
			nativePopupMenu = new NativePopupMenu();

			nativePopupMenu.AddMenuItem(new NativeMenuPopupItemBuilder().SetSubMenuItems(new NativeMenuItemBuilder().WithText("サブメニューアイテム1").Build(),
				new NativeMenuItemBuilder().WithText("サブメニューアイテム2").Build(),
				new NativeMenuItemBuilder().WithText("サブメニューアイテム3").Build())
				.WithText("サブメニュー").Build());
			nativePopupMenu.AddMenuItem(new NativeMenuSeparatorItem());

			NativeMenuItem eventItem = (NativeMenuItem)nativePopupMenu.AddMenuItem(new NativeMenuItemBuilder().WithText("テストイベント実行")
			.WithItemSelected((item) => MessageBox.Show("テストイベント実行")).WithUncheckedIcon(Properties.Resources.Event_16x).Build());
			//eventItem.UnCheckedIcon = Properties.Resources.Event_16x;

			nativePopupMenu.AddMenuItem(new NativeMenuItemBuilder().WithText("チェックボックス").WithItemSelected((item) => item.IsChecked = !item.IsChecked).Build());

			menu.AddMenuItem(nativePopupMenu.CreateNativeMenuPopupItem("メニューバーテスト(&T)"));
			menu.SetMenu(Handle);
		}
	}
}