using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsOperation.TypeHelpers
{
	public abstract class HelperBase<T>
	{
		internal T Value;

		internal HelperBase(T value)
		{
			Value = value;
		}

		/// <summary>
		/// 输出
		/// </summary>
		/// <param name="m"></param>
		public static implicit operator T(HelperBase<T> m)
		{
			return m.Value;
		}
	}
}
