using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPlay
{
	public partial class CustomForm : Form
	{
		private bool mouseDown;
		private Point lastLocation;


		public CustomForm()
		{
			InitializeComponent();
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void buttonMinimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void formPanel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.X < (formPanel.ClientRectangle.Width - 22) && e.Y < 12)
			{
				mouseDown = true;
				lastLocation = e.Location;
			}
		}

		private void formPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseDown)
			{
				this.Location = new Point(
					(this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

				this.Update();
			}
		}

		private void formPanel_MouseUp(object sender, MouseEventArgs e)
		{
			mouseDown = false;
		}


		//private const int cGrip = 50;

		//protected override void WndProc(ref Message m)
		//{
		//	if (m.Msg == 0x84)
		//	{  // Trap WM_NCHITTEST
		//		Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
		//		pos = this.PointToClient(pos);
		//		//if (pos.Y < cCaption)
		//		//{
		//		//	m.Result = (IntPtr)2;  // HTCAPTION
		//		//	return;
		//		//}
		//		if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
		//		{
		//			m.Result = (IntPtr)17; // HTBOTTOMRIGHT
		//			return;
		//		}
		//	}
		//	base.WndProc(ref m);
		//}
	}
}
