using MessagePack;
using NativeMenuBar.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NativeMenuBar.MenuItems.NativeMenuItem;

namespace NativeMenuBar.SerializableObjects
{
	/// <summary>
	/// シリアライズされたメニュー項目
	/// </summary>
	[MessagePackObject(true)]
	public class SerializedNativeMenuItem
	{
		/// <summary/>
		public Type TargetType;

		/// <summary/>
		public NativeMenuFlags Flags;

		/// <summary/>
		public SerializedNativeMenu SubMenu;

		/// <summary/>
		public string Text;

		/// <summary/>
		public int ItemSelected;
	}
}
