using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsOperation.Enums;

namespace WindowsOperation.TypeHelpers
{
	/// <summary>
	/// 隐式转换其他类型为Int类型
	/// </summary>
	public class IntHelper : HelperBase<int>
	{
		internal IntHelper(int value) : base(value)
		{
		}

		/// <summary>
		/// 输出
		/// </summary>
		/// <param name="m"></param>
		public static implicit operator IntPtr(IntHelper m)
		{
			return new IntPtr(m.Value);
		}

		/// <summary>
		/// 输入
		/// </summary>
		/// <param name="m"></param>
		public static implicit operator IntHelper(IntPtr m)
		{
			return new IntHelper((int)m);
		}

		/// <summary>
		/// 输入
		/// </summary>
		/// <param name="m"></param>
		public static implicit operator IntHelper(byte m)
		{
			return new IntHelper((int)m);
		}

		/// <summary>
		/// 输入
		/// </summary>
		/// <param name="m"></param>
		public static implicit operator IntHelper(Int16 m)
		{
			return new IntHelper((int)m);
		}
		/// <summary>
		/// 输入
		/// </summary>
		/// <param name="m"></param>
		public static implicit operator IntHelper(UInt16 m)
		{
			return new IntHelper((int)m);
		}

		/// <summary>
		/// 输入
		/// </summary>
		/// <param name="m"></param>
		public static implicit operator IntHelper(Int32 m)
		{
			return new IntHelper((int)m);
		}

		/// <summary>
		/// 输入
		/// </summary>
		/// <param name="m"></param>
		public static implicit operator IntHelper(UInt32 m)
		{
			return new IntHelper((int)m);
		}

		/// <summary>
		/// 输入
		/// </summary>
		/// <param name="m"></param>
		public static implicit operator IntHelper(WM m)
		{
			return new IntHelper((int)m);
		}


	}
}
