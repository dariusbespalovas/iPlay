using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPlay.UI
{
	public class OldButton : UIElement
	{
		#region drawing stuff
		private SolidBrush BackgroudBrush = new SolidBrush(Color.FromArgb(131, 31, 31));
		private Pen BorderPen = new Pen(Color.FromArgb(21, 21, 21));
		private SolidBrush testBrush = new SolidBrush(Color.FromArgb(200, 31, 31));
		#endregion

		public OldButton(Rect2D rect) : base(rect)
		{
		}

		public override void Draw(Graphics g)
		{

			graphics.FillRectangle(BackgroudBrush, 0, 0, RectScreenSpace.W, RectScreenSpace.H);
			graphics.DrawRectangle(BorderPen, 0, 0, RectScreenSpace.W - 1, RectScreenSpace.H - 1);

			graphics.FillRectangle(testBrush, 0 + RectScreenSpace.W / 3, 0 + RectScreenSpace.H / 3, RectScreenSpace.W / 3, RectScreenSpace.H / 3);

			//graphics.DrawString(Name, new Font(new FontFamily(GenericFontFamilies.SansSerif), 7, FontStyle.Regular), new SolidBrush(Color.FromArgb(240, 240, 240)), 0, 0);


			g.DrawImageUnscaled(Bmp, RectScreenSpace.X, RectScreenSpace.Y);

		}

	}
}
