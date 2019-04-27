using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsOperation.TypeHelpers
{

	public class IntPtrHelper : HelperBase<IntPtr>
	{
		internal IntPtrHelper(IntPtr value) : base(value)
		{

		}

		/// <summary>
		/// 输入
		/// </summary>
		/// <param name="m"></param>
		public static implicit operator IntPtrHelper(IntPtr m)
		{
			return new IntPtrHelper(m);
		}

		/// <summary>
		/// 输入
		/// </summary>
		/// <param name="m"></param>
		public static implicit operator IntPtrHelper(int m)
		{
			return new IntPtrHelper(new IntPtr(m));
		}
	}//End Class
}
