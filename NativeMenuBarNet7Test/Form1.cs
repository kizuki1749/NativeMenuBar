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

			//�e�X�g����
			nativePopupMenu = new NativePopupMenu();

			nativePopupMenu.AddMenuItem(new NativeMenuPopupItemBuilder().SetSubMenuItems(new NativeMenuItemBuilder().WithText("�T�u���j���[�A�C�e��1").Build(),
				new NativeMenuItemBuilder().WithText("�T�u���j���[�A�C�e��2").Build(),
				new NativeMenuItemBuilder().WithText("�T�u���j���[�A�C�e��3").Build())
				.WithText("�T�u���j���[").Build());
			nativePopupMenu.AddMenuItem(new NativeMenuSeparatorItem());

			NativeMenuItem eventItem = (NativeMenuItem)nativePopupMenu.AddMenuItem(new NativeMenuItemBuilder().WithText("�e�X�g�C�x���g���s")
			.WithItemSelected((item) => MessageBox.Show("�e�X�g�C�x���g���s")).WithUncheckedIcon(Properties.Resources.Event_16x).Build());
			//eventItem.UnCheckedIcon = Properties.Resources.Event_16x;

			nativePopupMenu.AddMenuItem(new NativeMenuItemBuilder().WithText("�`�F�b�N�{�b�N�X").WithItemSelected((item) => item.IsChecked = !item.IsChecked).Build());

			menu.AddMenuItem(nativePopupMenu.CreateNativeMenuPopupItem("���j���[�o�[�e�X�g(&T)"));
			menu.SetMenu(Handle);
		}
	}
}