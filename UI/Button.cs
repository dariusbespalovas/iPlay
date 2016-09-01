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
	public class Button : UIElement
	{
		public Button(Rect2D rect) : base(rect)
		{

		}

		public override void Draw(System.Windows.Forms.PaintEventArgs e)
		{
			// draw self
			e.Graphics.FillRectangle(System.Drawing.Brushes.Cyan, new Rectangle(Rect.X, Rect.Y, Rect.W, Rect.H));
			e.Graphics.DrawRectangle(System.Drawing.Pens.Blue, new Rectangle(Rect.X, Rect.Y, Rect.W, Rect.H));

            e.Graphics.DrawString("BTN", new Font(new FontFamily(GenericFontFamilies.SansSerif), 10 , FontStyle.Bold), Brushes.DarkOrange, Rect.X, Rect.Y);
		}

		public override void MouseDown(MouseEventArgs e)
		{
            if (CheckBoundingBox(e))
            {
                int a = 5;
            }
		}
	}
}
