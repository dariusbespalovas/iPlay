using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPlay.UI
{
	public partial class Panel : System.Windows.Forms.Panel
	{
		#region drawing stuff
		private SolidBrush BackgroudBrush = new SolidBrush(Color.FromArgb(31, 31, 31));
		private Pen BorderPen = new Pen(Color.FromArgb(121, 21, 21));
		#endregion

		public Panel()
		{
			InitializeComponent();
			this.Resize += Panel_Resize;
		}

		private void Panel_Resize(object sender, EventArgs e)
		{
			this.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			// draw self
			pe.Graphics.FillRectangle(BackgroudBrush, ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
			pe.Graphics.DrawRectangle(BorderPen, ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);

			base.OnPaint(pe);

			
		}
	}
}
