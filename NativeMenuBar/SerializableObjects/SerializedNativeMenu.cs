using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.SerializableObjects
{
    [MessagePackObject(true)]
    public class SerializedNativeMenu
    {
        public Type TargetType;
        public List<SerializedNativeMenuItem> Items = new List<SerializedNativeMenuItem>();
    }
}
