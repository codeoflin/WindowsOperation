using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsOperation.Enums
{
	/// <summary>
	/// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-showwindow
	/// </summary>
	public enum CmdShow
	{
		SW_FORCEMINIMIZE = 11,
		SW_HIDE = 0,
		SW_MAXIMIZE = 3,
		SW_MINIMIZE = 6,
		SW_RESTORE = 9,
		SW_SHOW = 5,
		SW_SHOWDEFAULT = 10,
		SW_SHOWMAXIMIZED = 3,
		SW_SHOWMINIMIZED = 2,
		SW_SHOWMINNOACTIVE = 7,
		SW_SHOWNA = 8,
		SW_SHOWNOACTIVATE = 4,
		SW_SHOWNORMAL = 1
	}

}
