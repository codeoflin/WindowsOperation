using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsOperation.Enums;
using WindowsOperation.Modules;
using WindowsOperation.TypeHelpers;

namespace WindowsOperation
{

	public static class NativeMethods
	{
		[DllImport("user32.dll", SetLastError = true)]
		public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
		[DllImport("user32.dll")]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);

		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern int GetClassName(IntPtr hWnd, StringBuilder buf, int nMaxCount);

		[DllImport("user32.dll")]
		public static extern uint GetMenuItemID(IntPtr hMenu, int nPos);
		[DllImport("user32.dll")]
		public static extern uint GetMenuState(IntPtr hMenu, uint uIDEnableItem, MF uEnable);
		[DllImport("user32.dll")]
		public static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, MF uEnable);

		[DllImport("user32.dll")]
		public static extern int GetMenuItemCount(IntPtr hMenu);

		[DllImport("user32.dll")]
		public static extern int GetMenuString(IntPtr hMenu, uint uIDItem, [Out] StringBuilder lpString, int nMaxCount, MF uFlag);

		[DllImport("user32.dll")]
		public static extern IntPtr GetMenu(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern IntPtr GetSubMenu(IntPtr hMenu, uint nPos);

		[DllImport("user32.dll")]
		public static extern uint GetMenuItemID(IntPtr hMenu, uint nPos);

		[DllImport("user32.dll")]
		public static extern bool ModifyMenu(IntPtr hMnu, uint uPosition, MF uFlags, uint uIDNewItem, string lpNewItem);

		[DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
		public static extern IntPtr GetParent(IntPtr hWnd);
		/// <summary>
		/// 判断窗口是否有效
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		[DllImport("user32.dll", EntryPoint = "IsWindow")]
		public static extern bool IsWindow(IntPtr hwnd);
		/// <summary>
		/// 判断窗口是否有效
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		[DllImport("user32.dll", EntryPoint = "IsMenu")]
		public static extern bool IsMenu(IntPtr hmenu);
		//消息发送API
		[DllImport("User32.dll", EntryPoint = "PostMessage")]
		public static extern int PostMessage(
			IntPtr hWnd,        // 信息发往的窗口的句柄
			int Msg,            // 消息ID
			int wParam,         // 参数1
			IntPtr lParam       // 参数2
		);

		//消息发送API
		[DllImport("User32.dll", EntryPoint = "PostMessage")]
		public static extern int PostMessage(
			IntPtr hWnd,        // 信息发往的窗口的句柄
			int Msg,            // 消息ID
			int wParam,         // 参数1
			StringBuilder lParam// 参数2
		);

		[DllImport("User32.Dll")]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr childwindow, string lpszClass, string lpszWindow);

		[DllImport("user32.dll", CharSet = CharSet.Ansi)]
		public static extern int SetWindowText(int hwnd, string lpString);

		[DllImport("user32.dll", CharSet = CharSet.Ansi)]
		public static extern int SetWindowText(IntPtr hwnd, string lpString);

		[DllImport("user32.dll")]
		public static extern int GetWindowTextLength(IntPtr hWnd);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int nMaxCount);

		[DllImport("user32.dll")]
		public static extern IntPtr SetActiveWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
		[DllImport("user32.dll")]
		public static extern bool IsWindowVisible(IntPtr hwnd);
		[DllImport("user32.dll")]
		public static extern bool IsWindowEnabled(IntPtr hWnd);
		[DllImport("user32.dll")]
		public static extern bool UpdateWindow(IntPtr hWnd);//更新窗口

		[DllImport("user32.dll")]
		public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);//设置Enable属性

		#region SendMessage各种版本
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, StringBuilder lParam);
		#endregion

		#region PostMessage各种版本

		[DllImport("user32.dll")]
		public static extern IntPtr PostMessage(IntPtr hWnd, WM Msg, uint wParam, int lParam);
		#endregion
		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, CmdShow nCmdShow);
		[DllImport("user32.dll", SetLastError = true)]
		public static extern int CloseWindow(IntPtr hWnd);


		/// <summary>
		/// SendMessage
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="msg"></param>
		/// <param name="wparam"></param>
		/// <param name="lparam"></param>
		/// <returns></returns>
		public static int SendMessage(IntPtrHelper hwnd, IntHelper msg, IntHelper wparam, IntHelper lparam)
		{
			return SendMessage(hwnd, msg, wparam, lparam);
		}

		/// <summary>
		/// 异步PostMessage
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="msg"></param>
		/// <param name="wparam"></param>
		/// <param name="lparam"></param>
		/// <returns></returns>
		public async static Task<int> PostMessageAsync(IntPtrHelper hwnd, IntHelper msg, IntHelper wparam, StringBuilder lparam)
		{
			return await Task.Factory.StartNew<int>(() =>
			{
				/*
				var result = 0;
				var str = Marshal.StringToHGlobalUni(lparam);
				try
				{
					result = PostMessage(hwnd, msg, wparam, str);
				}
				finally
				{
					Marshal.FreeHGlobal(str);
				}
				return result;
				// */
				return PostMessage(hwnd, msg, wparam, lparam);
			});
		}



		/// <summary>
		/// 异步PostMessage
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="msg"></param>
		/// <param name="wparam"></param>
		/// <param name="lparam"></param>
		/// <returns></returns>
		public async static Task<int> PostMessageAsync(IntPtrHelper hwnd, IntHelper msg, IntHelper wparam, IntPtrHelper lparam)
		{
			return await Task.Factory.StartNew<int>(() =>
			{
				return PostMessage(hwnd, msg, wparam, lparam);
			});
		}
	}

}
