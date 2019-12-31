using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		[DllImport("kernel32.dll")]
		public static extern uint GetTickCount();

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

		[DllImport("user32.dll", SetLastError = true)]
		public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

		#region SendMessage各种版本
		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, int wParam, string lParam);

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, int wParam, StringBuilder lParam);

		[DllImport("user32.dll", SetLastError = true, EntryPoint = "SendMessage")]
		private static extern int SendMessageE(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, StringBuilder lParam);

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, WM msg, int wParam, string lParam);

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, WM msg, int wParam, StringBuilder lParam);

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
			return SendMessageE(hwnd.Value, msg.Value, wparam.Value, lparam.Value);
		}

		/// <summary>
		/// 异步SendMessage
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="msg"></param>
		/// <param name="wparam"></param>
		/// <param name="lparam"></param>
		/// <returns></returns>
		public async static Task<int> SendMessageAsync(IntPtrHelper hwnd, IntHelper msg, IntHelper wparam, IntHelper lparam)
		{
			return await Task.Factory.StartNew<int>(() =>
			{
				return SendMessage(hwnd, msg, wparam, lparam);
			});
		}
		#endregion

		#region PostMessage各种版本

		[DllImport("user32.dll", EntryPoint = "PostMessage", SetLastError = true)]
		public static extern int PostMessageE(IntPtr hWnd, int Msg, int wParam, int lParam);


		/// <summary>
		/// SendMessage
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="msg"></param>
		/// <param name="wparam"></param>
		/// <param name="lparam"></param>
		/// <returns></returns>
		public static int PostMessage(IntPtrHelper hwnd, IntHelper msg, IntHelper wparam, IntHelper lparam)
		{
			return PostMessageE(hwnd.Value, msg.Value, wparam.Value, lparam.Value);
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
		#endregion
		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, CmdShow nCmdShow);
		[DllImport("user32.dll", SetLastError = true)]
		public static extern int CloseWindow(IntPtr hWnd);

		#region 进程操作有关

		[DllImport("user32.dll", SetLastError = true)]
		public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

		// When you don't want the ProcessId, use this overload and pass IntPtr.Zero for the second parameter
		[DllImport("user32.dll")]
		public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool OpenProcessToken(IntPtr ProcessHandle,
		UInt32 DesiredAccess, out IntPtr TokenHandle);

		[Flags]
		public enum AllocationType
		{
			Commit = 0x1000,
			Reserve = 0x2000,
			Decommit = 0x4000,
			Release = 0x8000,
			Reset = 0x80000,
			Physical = 0x400000,
			TopDown = 0x100000,
			WriteWatch = 0x200000,
			LargePages = 0x20000000
		}

		[Flags]
		public enum MemoryProtection
		{
			Execute = 0x10,
			ExecuteRead = 0x20,
			ExecuteReadWrite = 0x40,
			ExecuteWriteCopy = 0x80,
			NoAccess = 0x01,
			ReadOnly = 0x02,
			ReadWrite = 0x04,
			WriteCopy = 0x08,
			GuardModifierflag = 0x100,
			NoCacheModifierflag = 0x200,
			WriteCombineModifierflag = 0x400
		}
		[Flags]
		public enum FreeType
		{
			Decommit = 0x4000,
			Release = 0x8000,
		}

		[DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
		public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, FreeType dwFreeType);

		[DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
		public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr OpenProcess(
		 ProcessAccessFlags processAccess,
		 bool bInheritHandle,
		 uint processId
		);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool ReadProcessMemory(
				IntPtr hProcess,
				IntPtr lpBaseAddress,
				[Out] byte[] lpBuffer,
				int dwSize,
				out IntPtr lpNumberOfBytesRead);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool ReadProcessMemory(
				IntPtr hProcess,
				IntPtr lpBaseAddress,
				[Out, MarshalAs(UnmanagedType.AsAny)] object lpBuffer,
				int dwSize,
				out IntPtr lpNumberOfBytesRead);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool ReadProcessMemory(
				IntPtr hProcess,
				IntPtr lpBaseAddress,
				IntPtr lpBuffer,
				int dwSize,
				out IntPtr lpNumberOfBytesRead);
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool CloseHandle(IntPtr hHandle);

		[DllImport("advapi32.dll")]
		static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, ref LUID lpLuid);
		// Use this signature if you want the previous state information returned
		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AdjustTokenPrivileges(IntPtr TokenHandle,
			 [MarshalAs(UnmanagedType.Bool)]bool DisableAllPrivileges,
			 ref TOKEN_PRIVILEGES NewState,
			 UInt32 BufferLengthInBytes,
			 TOKEN_PRIVILEGES PreviousState,
			 out UInt32 ReturnLengthInBytes);

		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AdjustTokenPrivileges(IntPtr TokenHandle, [MarshalAs(UnmanagedType.Bool)]bool DisableAllPrivileges, ref TOKEN_PRIVILEGES NewState, UInt32 BufferLengthInBytes, IntPtr PreviousState, out UInt32 ReturnLengthInBytes);
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [MarshalAs(UnmanagedType.AsAny)] object lpBuffer, Int32 nSize, out IntPtr lpNumberOfBytesWritten);

		private static uint STANDARD_RIGHTS_REQUIRED = 0x000F0000;
		private static uint STANDARD_RIGHTS_READ = 0x00020000;
		private static uint TOKEN_ASSIGN_PRIMARY = 0x0001;
		private static uint TOKEN_DUPLICATE = 0x0002;
		private static uint TOKEN_IMPERSONATE = 0x0004;
		private static uint TOKEN_QUERY = 0x0008;
		private static uint TOKEN_QUERY_SOURCE = 0x0010;
		private static uint TOKEN_ADJUST_PRIVILEGES = 0x0020;
		private static uint TOKEN_ADJUST_GROUPS = 0x0040;
		private static uint TOKEN_ADJUST_DEFAULT = 0x0080;
		private static uint TOKEN_ADJUST_SESSIONID = 0x0100;
		private static uint TOKEN_READ = (STANDARD_RIGHTS_READ | TOKEN_QUERY);
		private static uint TOKEN_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | TOKEN_ASSIGN_PRIMARY | TOKEN_DUPLICATE | TOKEN_IMPERSONATE | TOKEN_QUERY | TOKEN_QUERY_SOURCE | TOKEN_ADJUST_PRIVILEGES | TOKEN_ADJUST_GROUPS | TOKEN_ADJUST_DEFAULT | TOKEN_ADJUST_SESSIONID);
		private static string SE_CREATE_TOKEN_NAME = "SeCreateTokenPrivilege";
		private static string SE_ASSIGNPRIMARYTOKEN_NAME = "SeAssignPrimaryTokenPrivilege";
		private static string SE_LOCK_MEMORY_NAME = "SeLockMemoryPrivilege";
		private static string SE_INCREASE_QUOTA_NAME = "SeIncreaseQuotaPrivilege";
		private static string SE_UNSOLICITED_INPUT_NAME = "SeUnsolicitedInputPrivilege";
		private static string SE_MACHINE_ACCOUNT_NAME = "SeMachineAccountPrivilege";
		private static string SE_TCB_NAME = "SeTcbPrivilege";
		private static string SE_SECURITY_NAME = "SeSecurityPrivilege";
		private static string SE_TAKE_OWNERSHIP_NAME = "SeTakeOwnershipPrivilege";
		private static string SE_LOAD_DRIVER_NAME = "SeLoadDriverPrivilege";
		private static string SE_SYSTEM_PROFILE_NAME = "SeSystemProfilePrivilege";
		private static string SE_SYSTEMTIME_NAME = "SeSystemtimePrivilege";
		private static string SE_PROF_SINGLE_PROCESS_NAME = "SeProfileSingleProcessPrivilege";
		private static string SE_INC_BASE_PRIORITY_NAME = "SeIncreaseBasePriorityPrivilege";
		private static string SE_CREATE_PAGEFILE_NAME = "SeCreatePagefilePrivilege";
		private static string SE_CREATE_PERMANENT_NAME = "SeCreatePermanentPrivilege";
		private static string SE_BACKUP_NAME = "SeBackupPrivilege";
		private static string SE_RESTORE_NAME = "SeRestorePrivilege";
		private static string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
		private static string SE_DEBUG_NAME = "SeDebugPrivilege";
		private static string SE_AUDIT_NAME = "SeAuditPrivilege";
		private static string SE_SYSTEM_ENVIRONMENT_NAME = "SeSystemEnvironmentPrivilege";
		private static string SE_CHANGE_NOTIFY_NAME = "SeChangeNotifyPrivilege";
		private static string SE_REMOTE_SHUTDOWN_NAME = "SeRemoteShutdownPrivilege";
		private static string SE_UNDOCK_NAME = "SeUndockPrivilege";
		private static string SE_SYNC_AGENT_NAME = "SeSyncAgentPrivilege";
		private static string SE_ENABLE_DELEGATION_NAME = "SeEnableDelegationPrivilege";
		private static string SE_MANAGE_VOLUME_NAME = "SeManageVolumePrivilege";

		[StructLayout(LayoutKind.Sequential)]
		public struct LUID
		{
			public int LowPart;
			public int HighPart;
		}
		public const UInt32 SE_PRIVILEGE_ENABLED_BY_DEFAULT = 0x00000001;
		public const UInt32 SE_PRIVILEGE_ENABLED = 0x00000002;
		public const UInt32 SE_PRIVILEGE_REMOVED = 0x00000004;
		public const UInt32 SE_PRIVILEGE_USED_FOR_ACCESS = 0x80000000; public struct TOKEN_PRIVILEGES
		{
			public UInt32 PrivilegeCount;
			[MarshalAs(UnmanagedType.ByValArray)]
			public LUID_AND_ATTRIBUTES[] Privileges;
		}
		public enum TOKEN_INFORMATION_CLASS
		{
			TokenUser = 1,
			TokenGroups,
			TokenPrivileges,
			TokenOwner,
			TokenPrimaryGroup,
			TokenDefaultDacl,
			TokenSource,
			TokenType,
			TokenImpersonationLevel,
			TokenStatistics,
			TokenRestrictedSids,
			TokenSessionId,
			TokenGroupsAndPrivileges,
			TokenSessionReference,
			TokenSandBoxInert,
			TokenAuditPolicy,
			TokenOrigin
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct LUID_AND_ATTRIBUTES
		{
			public LUID pLuid;
			public UInt32 Attributes;
		}
		public static bool EnableDebugPrivilege()
		{
			LUID sedebugnameValue = new LUID();
			TOKEN_PRIVILEGES tkp = new TOKEN_PRIVILEGES();
			if (!OpenProcessToken(new IntPtr(Process.GetCurrentProcess().Id), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, out var hToken))
			{
				return false;
			}
			if (!LookupPrivilegeValue(null, SE_DEBUG_NAME, ref sedebugnameValue))
			{
				CloseHandle(hToken);
				return false;
			}
			tkp.PrivilegeCount = 1;
			tkp.Privileges = new LUID_AND_ATTRIBUTES[1];
			tkp.Privileges[0].pLuid = sedebugnameValue;
			tkp.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;
			if (!AdjustTokenPrivileges(hToken, false, ref tkp, (uint)Marshal.SizeOf(tkp), IntPtr.Zero, out var lengh))
			{
				CloseHandle(hToken);
				return false;
			}
			CloseHandle(hToken);
			return true;
		}
		#endregion


	}

}
