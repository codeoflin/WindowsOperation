using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
		/// 点击一个窗口
		/// </summary>
		/// <param name="hwnd">句柄</param>
		/// <param name="point">相对窗口内坐标</param>
		public async void Click(Point? p = null)
		{
			var point = Point.Empty;
			if (p != null) point = p.Value;
			await NativeMethods.PostMessageAsync(Handle, WM.LBUTTONDOWN, 0, point.X + (point.Y * 0x10000));
			await NativeMethods.PostMessageAsync(Handle, WM.LBUTTONUP, 0, point.X + (point.Y * 0x10000));
			//NativeMethods.SendMessage(Handle, BM_CLICK, 0, point.X + (point.Y * 0x10000));
		}

		/// <summary>
		/// 右键点击一个窗口
		/// </summary>
		/// <param name="hwnd">句柄</param>
		/// <param name="point">相对窗口内坐标</param>
		public async void ClickRight(Point? p = null)
		{
			var point = Point.Empty;
			if (p != null) point = p.Value;
			await NativeMethods.PostMessageAsync(Handle, WM.RBUTTONDOWN, 0, point.X + (point.Y * 0x10000));
			await NativeMethods.PostMessageAsync(Handle, WM.RBUTTONUP, 0, point.X + (point.Y * 0x10000));
			//NativeMethods.SendMessage(Handle, BM_CLICK, 0, point.X + (point.Y * 0x10000));
		}

		/// <summary>
		/// 点击菜单
		/// </summary>
		/// <param name="menuitem"></param>
		public async void ClickMenu(MenuItem menuitem)
		{
			await NativeMethods.PostMessageAsync(Handle, WM.COMMAND, menuitem.ItemID, 0);
		}


		/// <summary>
		/// 
		/// </summary>
		public async Task<int> Close()
		{

			//NativeMethods.CloseWindow(Handle);
			return await NativeMethods.PostMessageAsync(Handle, WM.CLOSE, 0, 0);

		}

		/// <summary>
		/// 
		/// </summary>
		public async Task<int> Activity()
		{
			return await Task.Factory.StartNew<int>(() =>
			{
				//return (int)NativeMethods.SetActiveWindow(Handle);
				return NativeMethods.SetForegroundWindow(Handle) ? 0 : -1;
			});
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
