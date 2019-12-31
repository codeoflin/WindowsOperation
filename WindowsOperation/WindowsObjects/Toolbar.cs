using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsOperation.Enums;

namespace WindowsOperation.WindowsObjects
{

	public class Toolbar : Window
	{
		/// <summary>
		/// 工具栏按钮
		/// </summary>
		public class ToolbarButton
		{
			/// <summary>
			/// 
			/// </summary>
			public int ID;
			/// <summary>
			/// 
			/// </summary>
			public string Text;
		}

		private const int WM_USER = 0x0400;
		private const int TB_HIDEBUTTON = WM_USER + 4;
		private const int TB_DELETEBUTTON = WM_USER + 22;
		private const int TB_GETBUTTON = WM_USER + 23;
		private const int TB_BUTTONCOUNT = WM_USER + 24;
		private const int TB_GETBUTTONINFO = WM_USER + 63;
		private const int PROCESS_VM_OPERATION = 0x8;
		private const int PROCESS_VM_READ = 0x10;
		private const int PROCESS_VM_WRITE = 0x20;
		private const int TBIF_IMAGE = 0x0001;
		private const int TBIF_TEXT = 0x0002;
		private const int TBIF_STATE = 0x0004;
		private const int TBIF_STYLE = 0x0008;
		private const int TBIF_LPARAM = 0x0010;
		private const int TBIF_COMMAND = 0x0020;
		private const int TBIF_SIZE = 0x0040;
		private const uint TBIF_BYINDEX = 0x80000000;


		[StructLayout(LayoutKind.Sequential)]
		private struct TBBUTTONINFO
		{
			public uint cbSize;
			public uint dwMask;
			public int idCommand;
			public int iImage;
			public byte fsState;
			public byte fsStyle;
			public short cx;
			public IntPtr lParam;
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszText;
			public int cchText;
		}

		#region 构造方法
		/// <summary>
		/// 
		/// </summary>
		/// <param name="handle">句柄</param>
		public Toolbar(IntPtr handle) : base(handle)
		{

		}
		#endregion

		#region 属性
		/// <summary>
		/// 按钮(未完成)
		/// </summary>
		public ToolbarButton[] Buttons
		{
			get
			{
				var lbutt = new List<ToolbarButton>();
				var nbutts = NativeMethods.SendMessage(Handle, TB_BUTTONCOUNT, 0, 0);
				//.GetMenuString(Handle, MenuPos, sb, 512, GetMenuString_MF.BYPOSITION);
				if (nbutts <= 0) return lbutt.ToArray();

				//NativeMethods.SendMessage(Handle, TB_GETBUTTONINFO, 0, 0);
				var hprocess = NativeMethods.OpenProcess(ProcessAccessFlags.All, false, this.ProcessID);
				if (hprocess == IntPtr.Zero)
				{
					var errcode = Marshal.GetLastWin32Error();
					return lbutt.ToArray(); ;
				}


				var info = new TBBUTTONINFO();
				var buff = NativeMethods.VirtualAllocEx((IntPtr)ProcessID, IntPtr.Zero, (uint)Marshal.SizeOf(info), NativeMethods.AllocationType.Commit, NativeMethods.MemoryProtection.ReadWrite);
				WriteMemory(buff.ToInt32(), new byte[Marshal.SizeOf(info)]);
				for (int i = 0; i < nbutts; i++)
				{
					NativeMethods.SendMessage(Handle, TB_GETBUTTONINFO, 0, buff);// some bugs in here
					int iret = NativeMethods.ReadProcessMemory(hprocess, buff, info, Marshal.SizeOf(info), out var readlen) ? 0 : -2;

				}
				// */
				NativeMethods.VirtualFreeEx((IntPtr)ProcessID, buff, 512, NativeMethods.FreeType.Release);

				NativeMethods.CloseHandle(hprocess);

				return lbutt.ToArray();
			}
		}
		#endregion
	}

}
