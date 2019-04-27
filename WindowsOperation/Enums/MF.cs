using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsOperation.Enums
{

	/// <summary>
	/// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-modifymenua
	/// </summary>
	public enum MF : uint
	{
		/// <summary>
		/// 编号从0开始
		/// </summary>
		BYPOSITION = 0x00000400,
		/// <summary>
		/// 
		/// </summary>
		BYCOMMAND = 0x00000000,
		/// <summary>
		/// 
		/// </summary>
		GRAYED = 0x0001,
		/// <summary>
		/// 
		/// </summary>
		DISABLED = 0x0002,
		/// <summary>
		/// 
		/// </summary>
		BITMAP = 0x0004,
		/// <summary>
		/// 
		/// </summary>
		CHECKED = 0x0008,
		/// <summary>
		/// 
		/// </summary>
		MENUBARBREAK = 0x00000020,
		/// <summary>
		/// 
		/// </summary>
		MENUBREAK = 0x00000040,
		/// <summary>
		/// 
		/// </summary>
		OWNERDRAW = 0x00000100,
		/// <summary>
		/// 
		/// </summary>
		POPUP = 0x00000010,
		/// <summary>
		/// 
		/// </summary>
		SEPARATOR = 0x00000800,

	}
}
