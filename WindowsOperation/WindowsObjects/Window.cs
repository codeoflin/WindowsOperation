using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsOperation.Enums;
using WindowsOperation.Modules;

namespace WindowsOperation.WindowsObjects
{
	/// <summary>
	/// 窗口
	/// </summary>
	public class Window : WindowBase
	{
		#region 常量
		/// <summary>
		/// 单击
		/// </summary>
		private const int BM_CLICK = 245;
		#endregion

		#region 构建方法
		/// <summary>
		/// 
		/// </summary>
		/// <param name="handle">句柄</param>
		public Window(IntPtr handle) : base(handle)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="classname"></param>
		/// <param name="windowname"></param>
		/// <returns></returns>
		public static Window GetWindow(string classname = null, string windowname = null)
		{
			if (classname == null && windowname == null) return null;
			var hwnd = NativeMethods.FindWindow(classname, windowname);
			if (hwnd == IntPtr.Zero) return null;
			return new Window(hwnd);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="classname"></param>
		/// <param name="windowname"></param>
		/// <returns></returns>
		public Window[] SubWindows(string classname = null, string windowname = null)
		{
			var lw = new List<Window>();
			var hwnd = NativeMethods.FindWindowEx(Handle, IntPtr.Zero, classname, windowname);
			for (; hwnd != IntPtr.Zero; hwnd = NativeMethods.FindWindowEx(Handle, hwnd, classname, windowname)) lw.Add(new Window(hwnd));
			return lw.ToArray();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Window NextWindow(string classname = null, string windowname = null)
		{
			var parent = NativeMethods.GetParent(Handle);
			var hwnd = NativeMethods.FindWindowEx(parent, Handle, classname, windowname);
			if (hwnd == IntPtr.Zero) return null;
			return new Window(hwnd);
		}

		#endregion

		#region 方法

		/// <summary>
		/// 
		/// </summary>
		/// <param name="subwindow"></param>
		/// <param name="wParam"></param>
		public async void Command(Window subwindow, int wParam)
		{
			await NativeMethods.SendMessageAsync(Handle, WM.COMMAND, wParam, subwindow.Handle);
			await NativeMethods.SendMessageAsync(Handle, WM.COMMAND, wParam, subwindow.Handle);
			//NativeMethods.SendMessage(Handle, BM_CLICK, 0, point.X + (point.Y * 0x10000));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="subwindow"></param>
		/// <param name="wParam"></param>
		public void PostCommand(Window subwindow, int wParam)
		{
			NativeMethods.PostMessage(Handle, (int)WM.COMMAND, wParam, subwindow.Handle);
			NativeMethods.PostMessage(Handle, (int)WM.COMMAND, wParam, subwindow.Handle);
			//NativeMethods.SendMessage(Handle, BM_CLICK, 0, point.X + (point.Y * 0x10000));
		}
		#region 各种点击系列
		/// <summary>
		/// 点击一个窗口
		/// </summary>
		/// <param name="hwnd">句柄</param>
		/// <param name="point">相对窗口内坐标</param>
		public async void Click(Point? p = null)
		{
			var point = Point.Empty;
			if (p != null) point = p.Value;
			await NativeMethods.SendMessageAsync(Handle, BM_CLICK, 0, point.X + (point.Y * 0x10000));
		}
		/// <summary>
		/// 点击一个窗口
		/// </summary>
		/// <param name="hwnd">句柄</param>
		/// <param name="point">相对窗口内坐标</param>
		public void PostClick(Point? p = null)
		{
			var point = Point.Empty;
			if (p != null) point = p.Value;
			NativeMethods.PostMessage(Handle, BM_CLICK, 0, point.X + (point.Y * 0x10000));
		}

		/// <summary>
		/// 点击一个窗口
		/// </summary>
		/// <param name="hwnd">句柄</param>
		/// <param name="point">相对窗口内坐标</param>
		public async void MouseLClick(Point? p = null)
		{
			var point = Point.Empty;
			if (p != null) point = p.Value;
			await NativeMethods.SendMessageAsync(Handle, WM.LBUTTONDOWN, 0, point.X + (point.Y * 0x10000));
			await NativeMethods.SendMessageAsync(Handle, WM.LBUTTONUP, 0, point.X + (point.Y * 0x10000));
			//NativeMethods.SendMessage(Handle, BM_CLICK, 0, point.X + (point.Y * 0x10000));
		}

		/// <summary>
		/// 点击一个窗口
		/// </summary>
		/// <param name="hwnd">句柄</param>
		/// <param name="point">相对窗口内坐标</param>
		public void PostMouseLClick(Point? p = null)
		{
			var point = Point.Empty;
			if (p != null) point = p.Value;
			NativeMethods.PostMessage(Handle, WM.LBUTTONDOWN, 0, point.X + (point.Y * 0x10000));
			NativeMethods.PostMessage(Handle, WM.LBUTTONUP, 0, point.X + (point.Y * 0x10000));
			//NativeMethods.SendMessage(Handle, BM_CLICK, 0, point.X + (point.Y * 0x10000));
		}

		/// <summary>
		/// 右键点击一个窗口
		/// </summary>
		/// <param name="hwnd">句柄</param>
		/// <param name="point">相对窗口内坐标</param>
		public async void MouseRClick(Point? p = null)
		{
			var point = Point.Empty;
			if (p != null) point = p.Value;
			await NativeMethods.SendMessageAsync(Handle, WM.RBUTTONDOWN, 0, point.X + (point.Y * 0x10000));
			await NativeMethods.SendMessageAsync(Handle, WM.RBUTTONUP, 0, point.X + (point.Y * 0x10000));
			//NativeMethods.SendMessage(Handle, BM_CLICK, 0, point.X + (point.Y * 0x10000));
		}

		/// <summary>
		/// 右键点击一个窗口
		/// </summary>
		/// <param name="hwnd">句柄</param>
		/// <param name="point">相对窗口内坐标</param>
		public void PostMouseRClick(Point? p = null)
		{
			var point = Point.Empty;
			if (p != null) point = p.Value;
			NativeMethods.PostMessage(Handle, WM.RBUTTONDOWN, 0, point.X + (point.Y * 0x10000));
			NativeMethods.PostMessage(Handle, WM.RBUTTONUP, 0, point.X + (point.Y * 0x10000));
			//NativeMethods.SendMessage(Handle, BM_CLICK, 0, point.X + (point.Y * 0x10000));
		}

		/// <summary>
		/// 点击菜单
		/// </summary>
		/// <param name="menuitem"></param>
		public async void ClickMenu(MenuItem menuitem)
		{
			await NativeMethods.SendMessageAsync(Handle, WM.COMMAND, menuitem.ItemID, 0);
		}

		/// <summary>
		/// 点击菜单
		/// </summary>
		/// <param name="menuitem"></param>
		public void PostClickMenu(MenuItem menuitem)
		{
			NativeMethods.PostMessage(Handle, WM.COMMAND, menuitem.ItemID, 0);
		}
		#endregion

		#region 读写内存系列
		/// <summary>
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <param name="buff"></param>
		/// <returns></returns>
		public int ReadMemory(int address, byte[] buff)
		{
			if (buff == null) throw new Exception("buff不能为null!");
			if (buff.Length <= 0) throw new Exception("buff长度不能为0!");
			var hprocess = NativeMethods.OpenProcess(ProcessAccessFlags.All, false, this.ProcessID);
			if (hprocess == IntPtr.Zero)
			{
				var errcode = Marshal.GetLastWin32Error();
				return -1;
			}
			int iret = NativeMethods.ReadProcessMemory(hprocess, new IntPtr(address), buff, buff.Length, out var readlen) ? 0 : -2;
			NativeMethods.CloseHandle(hprocess);
			return iret;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <param name="size"></param>
		/// <param name="buff"></param>
		/// <returns></returns>
		public int ReadMemory(int address, int size, out byte[] buff)
		{
			if (size <= 0) throw new Exception("长度不能为0!");
			buff = new byte[size];
			return ReadMemory(address, buff);
		}

		/// <summary>
		/// /
		/// </summary>
		/// <param name="address"></param>
		/// <param name="dat"></param>
		/// <returns></returns>
		public int ReadMemory(int address, out Int16 dat)
		{
			dat = 0;
			var iret = ReadMemory(address, 2, out var buff);
			if (iret != 0) return iret;
			dat = (Int16)((buff[1] << 8) + buff[0]);
			return iret;
		}

		/// <summary>
		/// /
		/// </summary>
		/// <param name="address"></param>
		/// <param name="dat"></param>
		/// <returns></returns>
		public int ReadMemory(int address, out UInt16 dat)
		{
			dat = 0;
			var iret = ReadMemory(address, 2, out var buff);
			if (iret != 0) return iret;
			dat = (UInt16)((buff[1] << 8) + buff[0]);
			return iret;
		}

		/// <summary>
		/// /
		/// </summary>
		/// <param name="address"></param>
		/// <param name="dat"></param>
		/// <returns></returns>
		public int ReadMemory(int address, out Int32 dat)
		{
			dat = 0;
			var iret = ReadMemory(address, 4, out var buff);
			if (iret != 0) return iret;
			dat = ((buff[3] << 24) + (buff[2] << 16) + (buff[1] << 8) + buff[0]);
			return iret;
		}

		/// <summary>
		/// /
		/// </summary>
		/// <param name="address"></param>
		/// <param name="dat"></param>
		/// <returns></returns>
		public int ReadMemory(int address, out UInt32 dat)
		{
			dat = 0;
			var iret = ReadMemory(address, 4, out var buff);
			if (iret != 0) return iret;
			dat = (UInt32)((buff[3] << 24) + (buff[2] << 16) + (buff[1] << 8) + buff[0]);
			return iret;
		}

		/// <summary>
		/// /
		/// </summary>
		/// <param name="address"></param>
		/// <param name="dat"></param>
		/// <returns></returns>
		public int ReadMemory(int address, out Int64 dat)
		{
			dat = 0;
			var iret = ReadMemory(address, 8, out var buff);
			if (iret != 0) return iret;
			for (int i = 7; i >= 0; i++)
			{
				dat <<= 8;
				dat += buff[i];
			}
			return iret;
		}

		/// <summary>
		/// /
		/// </summary>
		/// <param name="address"></param>
		/// <param name="dat"></param>
		/// <returns></returns>
		public int ReadMemory(int address, out UInt64 dat)
		{
			dat = 0;
			var iret = ReadMemory(address, 8, out var buff);
			if (iret != 0) return iret;
			for (int i = 7; i >= 0; i++)
			{
				dat <<= 8;
				dat += buff[i];
			}
			return iret;
		}

		/// <summary>
		/// /
		/// </summary>
		/// <param name="address"></param>
		/// <param name="buff"></param>
		/// <returns></returns>
		public int WriteMemory(int address, byte[] buff)
		{
			if (buff == null) throw new Exception("buff不能为null!");
			if (buff.Length <= 0) throw new Exception("buff长度不能为0!");
			var hprocess = NativeMethods.OpenProcess(ProcessAccessFlags.All, false, this.ProcessID);
			if (hprocess == IntPtr.Zero)
			{
				var errcode = Marshal.GetLastWin32Error();
				return -1;
			}
			int iret = NativeMethods.WriteProcessMemory(hprocess, new IntPtr(address), buff, buff.Length, out var readlen) ? 0 : -2;
			if (iret != 0)
			{
				var errcode = Marshal.GetLastWin32Error();
				return -1;
			}
			NativeMethods.CloseHandle(hprocess);
			return 0;
		}

		/// <summary>
		/// /
		/// </summary>
		/// <param name="address"></param>
		/// <param name="dat"></param>
		/// <returns></returns>
		public int WriteMemory(int address, Int16 dat)
		{
			return WriteMemory(address, new byte[] { (byte)dat, (byte)(dat >> 8) });
		}

		/// <summary>
		/// /
		/// </summary>
		/// <param name="address"></param>
		/// <param name="dat"></param>
		/// <returns></returns>
		public int WriteMemory(int address, UInt16 dat)
		{
			return WriteMemory(address, new byte[] { (byte)dat, (byte)(dat >> 8) });
		}

		/// <summary>
		/// /
		/// </summary>
		/// <param name="address"></param>
		/// <param name="dat"></param>
		/// <returns></returns>
		public int WriteMemory(int address, Int32 dat)
		{
			return WriteMemory(address, new byte[] { (byte)dat, (byte)(dat >> 8), (byte)(dat >> 16), (byte)(dat >> 24) });
		}

		/// <summary>
		/// /
		/// </summary>
		/// <param name="address"></param>
		/// <param name="dat"></param>
		/// <returns></returns>
		public int WriteMemory(int address, UInt32 dat)
		{
			return WriteMemory(address, new byte[] { (byte)dat, (byte)(dat >> 8), (byte)(dat >> 16), (byte)(dat >> 24) });
		}

		/// <summary>
		/// /
		/// </summary>
		/// <param name="address"></param>
		/// <param name="dat"></param>
		/// <returns></returns>
		public int WriteMemory(int address, Int64 dat)
		{
			return WriteMemory(address, new byte[] { (byte)dat, (byte)(dat >> 8), (byte)(dat >> 16), (byte)(dat >> 24), (byte)(dat >> 32), (byte)(dat >> 40), (byte)(dat >> 48), (byte)(dat >> 56) });
		}

		/// <summary>
		/// /
		/// </summary>
		/// <param name="address"></param>
		/// <param name="dat"></param>
		/// <returns></returns>
		public int WriteMemory(int address, UInt64 dat)
		{
			return WriteMemory(address, new byte[] { (byte)dat, (byte)(dat >> 8), (byte)(dat >> 16), (byte)(dat >> 24), (byte)(dat >> 32), (byte)(dat >> 40), (byte)(dat >> 48), (byte)(dat >> 56) });
		}

		#endregion

		/// <summary>
		/// 
		/// </summary>
		public async Task<int> Close()
		{
			//NativeMethods.CloseWindow(Handle);
			return await NativeMethods.SendMessageAsync(Handle, WM.CLOSE, 0, 0);
		}

		public void Activity()
		{
			//NativeMethods.SwitchToThisWindow(Handle, true);
			NativeMethods.SetForegroundWindow(Handle);
			//NativeMethods.SendMessage(Handle, WM.SETFOCUS, 0, 0);
			//NativeMethods.SendMessage(Handle, WM.MOUSEACTIVATE, 0, 0);
		}
		#endregion

		#region 属性
		/// <summary>
		/// 
		/// </summary>
		public int Left
		{
			set
			{
				if (!NativeMethods.GetWindowRect(Handle, out RECT lpRect)) throw new Exception("获取属性失败!");
				NativeMethods.MoveWindow(Handle, value, lpRect.Y, lpRect.Width, lpRect.Height, true);
			}
			get
			{
				if (!NativeMethods.GetWindowRect(Handle, out RECT lpRect)) throw new Exception("获取属性失败!");
				return lpRect.X;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Top
		{
			set
			{
				if (!NativeMethods.GetWindowRect(Handle, out RECT lpRect)) throw new Exception("获取属性失败!");
				NativeMethods.MoveWindow(Handle, lpRect.X, value, lpRect.Width, lpRect.Height, true);
			}
			get
			{
				if (!NativeMethods.GetWindowRect(Handle, out RECT lpRect)) throw new Exception("获取属性失败!");
				return lpRect.Y;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Width
		{
			set
			{
				if (!NativeMethods.GetWindowRect(Handle, out RECT lpRect)) throw new Exception("获取属性失败!");
				NativeMethods.MoveWindow(Handle, lpRect.X, lpRect.Y, value, lpRect.Height, true);
			}
			get
			{
				if (!NativeMethods.GetWindowRect(Handle, out RECT lpRect)) throw new Exception("获取属性失败!");
				return lpRect.Width;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Height
		{
			set
			{
				if (!NativeMethods.GetWindowRect(Handle, out RECT lpRect)) throw new Exception("获取属性失败!");
				NativeMethods.MoveWindow(Handle, lpRect.X, lpRect.Y, lpRect.Width, value, true);
			}
			get
			{
				if (!NativeMethods.GetWindowRect(Handle, out RECT lpRect)) throw new Exception("获取属性失败!");
				return lpRect.Height;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Point Location
		{
			set
			{
				if (!NativeMethods.GetWindowRect(Handle, out RECT lpRect)) throw new Exception("获取属性失败!");
				NativeMethods.MoveWindow(Handle, value.X, value.Y, lpRect.Width, lpRect.Height, true);
			}
			get
			{
				if (!NativeMethods.GetWindowRect(Handle, out RECT lpRect)) throw new Exception("获取属性失败!");
				return lpRect.Location;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Size Size
		{
			set
			{
				if (!NativeMethods.GetWindowRect(Handle, out RECT lpRect)) throw new Exception("获取属性失败!");
				NativeMethods.MoveWindow(Handle, lpRect.X, lpRect.Y, value.Width, value.Height, true);
			}
			get
			{
				if (!NativeMethods.GetWindowRect(Handle, out RECT lpRect)) throw new Exception("获取属性失败!");
				return lpRect.Size;
			}
		}

		/// <summary>
		/// Text
		/// </summary>
		public string Text
		{
			set
			{
				Click();
				var sb = new StringBuilder(value);
				NativeMethods.SendMessage(Handle, (int)WM.SETTEXT, 0, sb);
				sb.Clear();
			}
			get
			{
				var task = NativeMethods.SendMessage(Handle, (int)WM.GETTEXTLENGTH, 0, 0);
				var size = task + 1;
				var sb = new StringBuilder(size);
				sb.Clear();
				NativeMethods.SendMessage(Handle, (int)WM.GETTEXT, size, sb);
				var str = sb.ToString();
				sb.Clear();
				return str;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string ClassName
		{
			get
			{
				var size = 512;
				var sb = new StringBuilder(size);
				sb.Clear();
				NativeMethods.GetClassName(Handle, sb, size);
				var str = sb.ToString().TrimEnd('\0');
				sb.Clear();
				return str;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Window[] Controls
		{
			get
			{
				return SubWindows();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Menu Menu
		{
			get
			{
				var hmenu = NativeMethods.GetMenu(Handle);
				if (hmenu == IntPtr.Zero) return null;
				return new Menu(hmenu);
			}
		}


		/// <summary>
		/// 判断是否有效窗口
		/// </summary>
		public virtual bool IsWindow
		{
			get
			{
				return NativeMethods.IsWindow(Handle);
			}
		}

		/// <summary>
		　　/// 设置窗体为TopMost
		　　/// </summary>
		　　/// <param name="hWnd"></param>
		public bool TopMost
		{
			get
			{
				int exStyle = NativeMethods.GetWindowLong(Handle, (int)GWL.EXSTYLE);
				return (exStyle & (int)WS.EX_TOPMOST) == (int)WS.EX_TOPMOST;
			}
			set
			{
				NativeMethods.SetWindowPos(Handle, (IntPtr)(value ? HWND.TOPMOST : HWND.NOTOPMOST), this.Left, this.Top, this.Width, this.Height, 0);
			}
		}

		#endregion
	}//End Class
}
