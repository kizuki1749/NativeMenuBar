using NativeMenuBar;
using NativeMenuBar.Builders;
using NativeMenuBar.MenuItems;
using NativeMenuBar.Menus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NativeMenuBarTest
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
			menu = new NativeMenu();
			
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

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			menu.Dispose();
		}

		private void Form1_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
				nativePopupMenu.ShowContextMenu(Cursor.Position.X, Cursor.Position.Y, 0, Handle);
		}
	}
}
