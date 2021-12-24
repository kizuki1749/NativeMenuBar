using MessagePack;
using NativeMenuBar.Menus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace NativeMenuBar.MenuItems
{
	/// <summary>
	/// メニュー項目
	/// </summary>
	[Serializable]
	public class NativeMenuItem : NativeMenuItemBase
	{
		/// <summary>
		/// オブジェクト選択時に使用されるデリゲート
		/// </summary>
		/// <param name="sender"></param>
		public delegate void NativeMenuItemSelectedHandler(NativeMenuItem sender);

		/// <summary>
		/// 項目選択時に実行されます。
		/// </summary>
		internal event NativeMenuItemSelectedHandler ItemSelected;

		/// <summary>
		/// メニュー項目のID
		/// </summary>
		public uint Id { get; internal set; }

		/// <summary>
		/// メニュー項目に表示されるテキスト
		/// </summary>
		public string Text { get; internal set; }

		/// <summary>
		/// 未チェック時に表示されるアイコン。この項目は直ちに適用されます。(トップメニューの場合は再描画が必要)
		/// </summary>
		public Bitmap UnCheckedIcon
		{
			get
			{
				return _unCheckedIcon;
			}
			set
			{
				_unCheckedIcon = value;
				ApplyIcon();
			}
		}

		internal Bitmap _unCheckedIcon;

		/// <summary>
		/// チェック時に表示されるアイコン。この項目は直ちに適用されます。(トップメニューの場合は再描画が必要)
		/// </summary>
		public Bitmap CheckedIcon
		{
			get
			{
				return _checkedIcon;
			}
			set
			{
				_checkedIcon = value;
				ApplyIcon();
			}
		}

		internal Bitmap _checkedIcon;

		/// <summary>
		/// 項目がチェックされているか。この項目は直ちに適用されます。(トップメニューの場合は再描画が必要)
		/// </summary>
		public bool IsChecked
		{
			get
			{
				return Flags.HasFlag(NativeMenuFlags.MF_CHECKED);
			}
			set
			{
				if (value)
					Flags |= NativeMenuFlags.MF_CHECKED;
				else
					Flags &= ~NativeMenuFlags.MF_CHECKED;
				Apply();
			}
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		internal NativeMenuItem() : base()
		{
			Flags = NativeMenuFlags.MF_UNCHECKED | NativeMenuFlags.MF_STRING | NativeMenuFlags.MF_ENABLED;
			Id = (uint)GetHashCode();
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="text">メニュー項目に表示されるテキスト</param>
		internal NativeMenuItem(string text) : base()
		{
			Flags = NativeMenuFlags.MF_UNCHECKED | NativeMenuFlags.MF_STRING | NativeMenuFlags.MF_ENABLED;
			Id = (uint)GetHashCode();
			Text = text;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="text">メニュー項目に表示されるテキスト</param>
		/// <param name="icon">メニュー項目に表示されるアイコン</param>
		internal NativeMenuItem(Bitmap icon, string text) : this(text)
		{
			UnCheckedIcon = icon;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="text">メニュー項目に表示されるテキスト</param>
		/// <param name="itemClicked">項目選択時に実行される処理</param>
		internal NativeMenuItem(string text, NativeMenuItemSelectedHandler itemClicked) : this(text)
		{
			ItemSelected += itemClicked;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="text">メニュー項目に表示されるテキスト</param>
		/// <param name="id">使用するID</param>
		internal NativeMenuItem(string text, int id) : this(text)
		{
			Id = (uint)id;
		}

		internal override void Register(IntPtr menuHandle)
		{
			Handle = menuHandle;
			if (NativeMenu.UseUnicode)
			{
				//LPCWSTR型(WCHAR)
				if (!NativeMethod.AppendMenuW(menuHandle, Flags, Id, Text))
					throw new InvalidOperationException("メニュー項目の登録に失敗しました。");
			}
			else
			{
				//LPCSTR型(char)
				if (!NativeMethod.AppendMenuA(menuHandle, Flags, Id, Text))
					throw new InvalidOperationException("メニュー項目の登録に失敗しました。");
			}
			ApplyIcon(Parent.Items.Count);
		}

		internal override void RegisterInsert(IntPtr menuHandle, uint index, NativeMenuFlags flags)
		{
			Handle = menuHandle;
			if (NativeMenu.UseUnicode)
			{
				//LPCWSTR型(WCHAR)
				if (!NativeMethod.InsertMenuW(menuHandle, index, Flags | flags, Id, Text))
					throw new InvalidOperationException("メニュー項目の登録に失敗しました。");
			}
			else
			{
				//LPCSTR型(char)
				if (!NativeMethod.InsertMenuA(menuHandle, index, Flags | flags, Id, Text))
					throw new InvalidOperationException("メニュー項目の登録に失敗しました。");
			}
			ApplyIcon((int)index);
		}

		/// <summary>
		/// メニュー項目クリック時の処理を実行します。
		/// </summary>
		public virtual void PerformClick()
		{
			ItemSelected?.Invoke(this);
		}

		/// <inheritdoc/>
		public override void Apply()
		{
			if (NativeMenu.UseUnicode)
			{
				if (!NativeMethod.ModifyMenuA(Handle, (uint)GetThisIndex(), Flags | NativeMenuFlags.MF_BYPOSITION, Id, Text))
					throw new InvalidOperationException("メニュー項目の更新に失敗しました。");
			}
			else
			{
				if (!NativeMethod.ModifyMenuW(Handle, (uint)GetThisIndex(), Flags | NativeMenuFlags.MF_BYPOSITION, Id, Text))
					throw new InvalidOperationException("メニュー項目の更新に失敗しました。");
			}
			ApplyIcon();
		}

		/// <summary>
		/// 現在の項目へアイコンを適用します。
		/// </summary>
		protected void ApplyIcon()
		{
			NativeMethod.SetMenuItemBitmaps(Handle, (uint)GetThisIndex(), NativeMenuSelectorFlags.MF_BYPOSITION,
				UnCheckedIcon != null ? UnCheckedIcon.GetHbitmap() : IntPtr.Zero,
				CheckedIcon != null ? CheckedIcon.GetHbitmap() : IntPtr.Zero);
		}

		/// <summary>
		/// 現在の項目へインデックスを指定してアイコンを適用します。
		/// </summary>
		/// <param name="index">対象の項目のインデックス</param>
		protected void ApplyIcon(int index)
		{
			NativeMethod.SetMenuItemBitmaps(Handle, (uint)index, NativeMenuSelectorFlags.MF_BYPOSITION,
				UnCheckedIcon != null ? UnCheckedIcon.GetHbitmap() : IntPtr.Zero,
				CheckedIcon != null ? CheckedIcon.GetHbitmap() : IntPtr.Zero);
		}

		/// <summary>
		/// メニュー選択時のイベントを取得します。
		/// </summary>
		/// <returns>イベントハンドラ</returns>
		public NativeMenuItemSelectedHandler GetEventHandler()
		{
			return ItemSelected;
		}

		//public void Refresh(Action<MENUITEMINFO> func, MaskFlags mask = MaskFlags.MIIM_BITMAP | MaskFlags.MIIM_CHECKMARKS | MaskFlags.MIIM_DATA | MaskFlags.MIIM_FTYPE | MaskFlags.MIIM_ID
		//    | MaskFlags.MIIM_STATE | MaskFlags.MIIM_STRING | MaskFlags.MIIM_SUBMENU)
		//{
		//    MENUITEMINFO info = new MENUITEMINFO();
		//    info.cbSize = (uint)Marshal.SizeOf(typeof(MENUITEMINFO));
		//    info.fMask = mask;
		//    IntPtr infoPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(MENUITEMINFO)));
		//    Marshal.StructureToPtr(info, infoPtr, false);

		//    if (!NativeMethod.GetMenuItemInfoA(Parent.Handle, (uint)Parent.Items.ToList().IndexOf(this), true, infoPtr))
		//        throw new InvalidOperationException("メニュー項目の取得に失敗しました。");

		//    info = (MENUITEMINFO)Marshal.PtrToStructure(infoPtr, typeof(MENUITEMINFO));

		//    func(info);

		//    if (!NativeMethod.SetMenuItemInfoA(Parent.Handle, (uint)Parent.Items.ToList().IndexOf(this), true, infoPtr))
		//        throw new InvalidOperationException("メニュー項目の更新に失敗しました。");
		//}
	}
}
