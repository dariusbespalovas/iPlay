﻿using System;
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
	public partial class Button : Control
	{

		#region drawing stuff
		private SolidBrush BackgroudBrush = new SolidBrush(Color.FromArgb(131, 31, 31));
		private Pen BorderPen = new Pen(Color.FromArgb(21, 21, 21));
		private SolidBrush testBrush = new SolidBrush(Color.FromArgb(200, 31, 31));
		#endregion

		public Button()
		{
			InitializeComponent();

			this.Resize += Button_Resize;
		}

		private void Button_Resize(object sender, EventArgs e)
		{
			this.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);

			pe.Graphics.FillRectangle(BackgroudBrush, ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
			pe.Graphics.DrawRectangle(BorderPen, ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);

			pe.Graphics.FillRectangle(testBrush, ClientRectangle.X + ClientRectangle.Width / 3, ClientRectangle.Y + ClientRectangle.Height / 3, ClientRectangle.Width / 3, ClientRectangle.Height / 3);

			//g.DrawImageUnscaled(Bmp, RectScreenSpace.X, RectScreenSpace.Y);
		}
	}
}
