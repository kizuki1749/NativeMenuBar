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
	/// メニュー項目のビルダークラス
	/// </summary>
	/// <typeparam name="T1">ビルド結果の型</typeparam>
	/// <typeparam name="T2">派生クラスの型</typeparam>
	public abstract class NativeMenuItemBuilderBase<T1, T2> : IBuilder<T1> where T1 : NativeMenuItem where T2 : NativeMenuItemBuilderBase<T1, T2>
	{
		/// <summary>
		/// ビルド成果物を示します。
		/// </summary>
		protected T1 Item;

		/// <summary>
		/// オプションビルダーを示します。
		/// </summary>
		protected NativeMenuItemOptionBuilder _option;

		/// <summary>
		/// メニュー項目のテキストを取得、設定します。
		/// </summary>
		public string Text
        {
			get => Item.Text;
			set => Item.Text = value;
        }

		/// <summary>
		/// メニュー項目のIDを取得、設定します。
		/// </summary>
		public uint Id
		{
			get => Item.Id;
			set => Item.Id = value;
		}

		/// <summary>
		/// メニュー項目のオプションを取得、設定します。
		/// </summary>
		public NativeMenuItemOptionBuilder Option
        {
			get => _option;
        }

		/// <summary>
		/// アイテム選択時の処理を取得、設定します。
		/// </summary>
		public event NativeMenuItem.NativeMenuItemSelectedHandler ItemSelected
        {
			add => Item.ItemSelected += value;
			remove => Item.ItemSelected -= value;
        }

		/// <summary>
		/// メニュー項目のアイコンを取得、設定します。
		/// </summary>
		public Bitmap Icon
		{
			get => Item.UnCheckedIcon;
			set => Item.UnCheckedIcon = value;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		protected NativeMenuItemBuilderBase()
        {
        }

		/// <summary>
		/// メニュー項目のテキストを設定します。
		/// </summary>
		/// <param name="Text">設定するテキスト</param>
		/// <returns>現在のインスタンス</returns>
		public T2 WithText(string Text)
        {
			Item.Text = Text;
			return (T2)this;
        }

		/// <summary>
		/// メニュー項目がチェックされているかを取得、設定します。
		/// </summary>
		/// <param name="Checked">メニュー項目がチェックされているか</param>
		/// <returns>現在のインスタンス</returns>
		public T2 WithChecked(bool Checked)
		{
			Option.IsChecked = Checked;
			return (T2)this;
		}

		/// <summary>
		/// メニュー項目を無効にするかを設定します。
		/// </summary>
		/// <param name="Disabled">メニュー項目を無効にするか</param>
		/// <returns>現在のインスタンス</returns>
		public T2 WithDisabled(bool Disabled)
		{
			Option.IsDisabled = Disabled;
			return (T2)this;
		}

		/// <summary>
		/// チェックされていない時に表示されるアイコンを取得、設定します。
		/// </summary>
		/// <param name="Icon">設定するアイコン</param>
		/// <returns>現在のインスタンス</returns>
		public T2 WithUncheckedIcon(Bitmap Icon)
		{
			Item._unCheckedIcon = Icon;
			return (T2)this;
		}

		/// <summary>
		/// チェックされている時に表示されるアイコンを取得、設定します。
		/// </summary>
		/// <param name="Icon">設定するアイコン</param>
		/// <returns>現在のインスタンス</returns>
		public T2 WithCheckedIcon(Bitmap Icon)
		{
			Item._checkedIcon = Icon;
			return (T2)this;
		}

		/// <summary>
		/// アイテム選択時の処理を取得、設定します。
		/// </summary>
		/// <param name="ItemSelected">アイテム選択時の処理</param>
		/// <returns>現在のインスタンス</returns>
		public T2 WithItemSelected(NativeMenuItem.NativeMenuItemSelectedHandler ItemSelected)
        {
			Item.ItemSelected += ItemSelected;
			return (T2)this;
        }

		/// <summary>
		/// 項目に使用するIDを取得、設定します。
		/// </summary>
		/// <param name="Id">項目に使用するID</param>
		/// <returns>現在のインスタンス</returns>
		public T2 WithId(uint Id)
		{
			Item.Id = Id;
			return (T2)this;
		}

		/// <summary>
		/// オプションを手動で操作します。
		/// </summary>
		/// <param name="Action">実行する処理</param>
		/// <returns>現在のインスタンス</returns>
		public T2 WithOption(Action<NativeMenuItemOptionBuilder> Action)
		{
			Action?.Invoke(_option);
			return (T2)this;
		}

		/// <summary>
		/// 設定をビルドします。
		/// </summary>
		/// <returns>ビルド結果</returns>
		public virtual T1 Build()
        {
			Item.Flags = Option.Build();
			return Item;
        }
	}
}
