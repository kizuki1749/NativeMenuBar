using NativeMenuBar.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeMenuBar.Builders
{
	/// <summary>
	/// ビルド可能なクラスを表すインターフェース
	/// </summary>
	/// <typeparam name="T">ビルド成果物の型</typeparam>
	public interface IBuilder<T>
	{
		/// <summary>
		/// ビルドを実行します。
		/// </summary>
		/// <returns>ビルド成果物</returns>
		T Build();
	}
}
