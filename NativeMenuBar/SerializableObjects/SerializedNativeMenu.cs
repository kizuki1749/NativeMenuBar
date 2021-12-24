using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.SerializableObjects
{
	/// <summary>
	/// シリアライズされたメニュー
	/// </summary>
	[MessagePackObject(true)]
	public class SerializedNativeMenu
	{
		/// <summary/>
		public Type TargetType;

		/// <summary/>
		public List<SerializedNativeMenuItem> Items = new List<SerializedNativeMenuItem>();
	}
}
