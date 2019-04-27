using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsOperation.WindowsObjects
{
	public class Menu
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
		public Menu(IntPtr handle)
		{
			Handle = handle;
		}
		#endregion

		#region 属性
		/// <summary>
		/// Text
		/// </summary>
		public MenuItem[] Items
		{
			get
			{
				var items = new List<MenuItem>();
				var itemcount = NativeMethods.GetMenuItemCount(Handle);
				for (uint i = 0; i < itemcount; i++) items.Add(new MenuItem(Handle, i));
				return items.ToArray();
			}
		}
		#endregion
	}

}
