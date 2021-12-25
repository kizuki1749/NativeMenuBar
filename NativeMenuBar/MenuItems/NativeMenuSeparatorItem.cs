using NativeMenuBar.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.MenuItems
{
	/// <summary>
	/// 区切り線(セパレーター)
	/// </summary>
	[Serializable]
	public class NativeMenuSeparatorItem : NativeMenuItemBase
	{
		/// <inheritdoc />
		public NativeMenuSeparatorItem() : base()
		{
			Flags = NativeMenuFlags.MF_SEPARATOR;
		}

		internal override void Register(IntPtr menuHandle)
		{
			Handle = menuHandle;
			if (NativeMenuRegisterOption.UseUnicode)
			{
				if (!NativeMethod.AppendMenuW(menuHandle, Flags, 0, null))
					throw new InvalidOperationException("メニュー項目の登録に失敗しました。");
			}
			else
			{
				if (!NativeMethod.AppendMenuA(menuHandle, Flags, 0, null))
					throw new InvalidOperationException("メニュー項目の登録に失敗しました。");
			}
		}

		internal override void RegisterInsert(IntPtr menuHandle, uint index, NativeMenuFlags flags)
		{
			Handle = menuHandle;
			if (NativeMenuRegisterOption.UseUnicode)
			{
				if (!NativeMethod.InsertMenuW(menuHandle, index, Flags | flags, 0, null))
					throw new InvalidOperationException("メニュー項目の登録に失敗しました。");
			}
			else
			{
				if (!NativeMethod.InsertMenuA(menuHandle, index, Flags | flags, 0, null))
					throw new InvalidOperationException("メニュー項目の登録に失敗しました。");
			}
		}
	}
}
