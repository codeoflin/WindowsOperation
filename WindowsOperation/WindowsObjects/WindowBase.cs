using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsOperation.Enums;

namespace WindowsOperation.WindowsObjects
{
	public abstract class WindowBase
	{
		#region 变量
		/// <summary>
		/// Handle
		/// </summary>
		public IntPtr Handle { get; private set; } = IntPtr.Zero;
		#endregion

		#region 构造方法
		/// <summary>
		/// 
		/// </summary>
		/// <param name="handle">句柄</param>
		public WindowBase(IntPtr handle)
		{
			Handle = handle;
		}
		#endregion

		#region 方法


		#endregion

		#region 属性


		/// <summary>
		/// 进程ID
		/// </summary>
		public uint ProcessID
		{
			get
			{
				var iret = NativeMethods.GetWindowThreadProcessId(Handle, out uint pid);
				if (iret == 0) return uint.MaxValue;
				return pid;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual bool Enable
		{
			set
			{
				NativeMethods.EnableWindow(Handle, value);
			}
			get
			{
				return NativeMethods.IsWindowEnabled(Handle);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual bool Visiable
		{
			set
			{
				NativeMethods.ShowWindow(Handle, value ? CmdShow.SW_SHOW : CmdShow.SW_HIDE);
			}
			get
			{
				return NativeMethods.IsWindowVisible(Handle);
			}
		}

		#endregion
	}
}
