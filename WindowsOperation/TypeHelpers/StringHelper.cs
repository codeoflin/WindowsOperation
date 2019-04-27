using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsOperation.TypeHelpers
{
	public class StringHelper : HelperBase<string>
	{
		internal StringHelper(string value) : base(value)
		{
		}

		/// <summary>
		/// 输出
		/// </summary>
		/// <param name="m"></param>
		public static implicit operator StringBuilder(StringHelper m)
		{
			return new StringBuilder(m.Value);
		}


		/// <summary>
		/// 输入
		/// </summary>
		/// <param name="m"></param>
		public static implicit operator StringHelper(string m)
		{
			return new StringHelper(m);
		}

		/// <summary>
		/// 输入
		/// </summary>
		/// <param name="m"></param>
		public static implicit operator StringHelper(StringBuilder m)
		{
			return new StringHelper(m.ToString());
		}

	}
}
