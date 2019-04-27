using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsOperation.TypeHelpers;
using WindowsOperation.WindowsObjects;


namespace Test
{
	static class Program
	{
		static void Main(string[] args)
		{
			//窗口类名和窗口标题,只要传入1个就能获取.建议取类名,因为类名通常是固定的
			var win = Window.GetWindow("Notepad");
			//var win = Window.GetWindow(windowname: "无标题 - 记事本");

			//激活窗口
			win.Activity().Wait();

			//改下窗口位置大小
			win.Location = new Point(0, 0);
			win.Width = 300;
			win.Height = 300;

			//获取窗口标题
			var text = win.Text;
			Console.WriteLine(text);

			//修改窗口标题
			win.Text = "1记事本";
			win.Text = "2记事本";
			win.Text = "3记事本";
			win.Text = "4记事本";

			//这里获取Notepad的第一个控件,并写入内容
			var edit = win.Controls[0];
			edit.Text = "这是内容这是内容这是内容这是内容这是内容这是内容这是内容这是内容这是内容";

			//模拟鼠标操作
			edit.Click(new Point(100, 5));//单击鼠标左键,参数是点击位置,不传的话默认值为X0,Y0

			//点击菜单里 第1列第3行 的"保存" 
			//win.ClickMenu(win.Menu.Items[0].Menu.Items[2]);

			//修改菜单内容
			win.Menu.Items[1].Text = "Hello World";

			//翻转菜单的可用状态
			win.Menu.Items[1].Enable = !win.Menu.Items[1].Enable;

			//设为顶层窗口
			win.TopMost = !win.TopMost;
			win.TopMost = !win.TopMost;
			win.TopMost = !win.TopMost;

		}
	}
}
