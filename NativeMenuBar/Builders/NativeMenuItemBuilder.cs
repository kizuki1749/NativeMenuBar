using NativeMenuBar.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.Builders
{
    /// <summary>
    /// メニュー項目のビルダークラス
    /// </summary>
    public class NativeMenuItemBuilder : NativeMenuItemBuilderBase<NativeMenuItem, NativeMenuItemBuilder>
    {
        /// <inheritdoc/>
        public NativeMenuItemBuilder() : base()
        {
            Item = new NativeMenuItem();
            _option = new NativeMenuItemOptionBuilder(Item);
        }

        /// <inheritdoc/>
        public override NativeMenuItem Build()
        {
            base.Build();
            return Item;
        }
    }
}
