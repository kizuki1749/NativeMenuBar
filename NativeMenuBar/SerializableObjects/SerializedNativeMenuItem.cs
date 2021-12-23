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
	[MessagePackObject(true)]
	public class SerializedNativeMenuItem
	{
		public Type TargetType;
		public NativeMenuFlags Flags;
		public SerializedNativeMenu SubMenu;
		public string Text;
		public int ItemSelected;
	}
}
