using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsOperation.Enums;

namespace WindowsOperation.WindowsObjects
{
	public class MenuItem : WindowBase
	{
		#region 变量
		/// <summary>
		/// 菜单编号
		/// </summary>
		public uint MenuPos { get; private set; } = 0;
		#endregion

		#region 构造方法
		/// <summary>
		/// 
		/// </summary>
		/// <param name="handle">句柄</param>
		public MenuItem(IntPtr handle, uint menuid) : base(handle)
		{
			MenuPos = menuid;
		}
		#endregion

		#region 属性
		/// <summary>
		/// Text
		/// </summary>
		public string Text
		{
			set
			{
				NativeMethods.ModifyMenu(Handle, MenuPos, MF.BYPOSITION, ItemID, value);
			}
			get
			{
				var sb = new StringBuilder(512);
				sb.Clear();
				NativeMethods.GetMenuString(Handle, MenuPos, sb, 512, MF.BYPOSITION);
				var str = sb.ToString().TrimEnd('\0');
				sb.Clear();
				return str;
			}
		}

		/// <summary>
		/// Text
		/// </summary>
		public Menu Menu
		{
			get
			{
				var submenu = NativeMethods.GetSubMenu(Handle, MenuPos);
				if (submenu == IntPtr.Zero) return null;
				return new Menu(submenu);
			}
		}

		/// <summary>
		/// 菜单项是否可用
		/// </summary>
		public override bool Enable
		{
			get
			{
				var state = NativeMethods.GetMenuState(Handle, MenuPos, MF.BYCOMMAND | MF.BYPOSITION);
				return (state & (uint)(MF.DISABLED | MF.GRAYED)) == 0;
			}
			set
			{
				var state = value ? (MF.BYPOSITION | MF.BYCOMMAND) : (MF.DISABLED | MF.BYPOSITION | MF.GRAYED);
				NativeMethods.EnableMenuItem(Handle, MenuPos, state);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsMenu
		{
			get
			{
				return NativeMethods.IsMenu(Handle);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public uint ItemID
		{
			get
			{
				return NativeMethods.GetMenuItemID(Handle, MenuPos);
			}
		}

		#endregion
	}

}
