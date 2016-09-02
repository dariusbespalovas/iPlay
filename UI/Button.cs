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
		public string Name { get; private set; }

		



		public Button(Rect2D rect, string Name) : base(rect)
		{
			this.Name = Name;
		}

		public override void Draw(System.Windows.Forms.PaintEventArgs e)
		{
			// draw self
			e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(31, 31, 31)), new Rectangle(Rect.X, Rect.Y, Rect.W, Rect.H));
			e.Graphics.DrawRectangle(new Pen(Color.FromArgb(21, 21, 21)), new Rectangle(Rect.X, Rect.Y, Rect.W, Rect.H));

			e.Graphics.DrawString("BTN", new Font(new FontFamily(GenericFontFamilies.SansSerif), 10 , FontStyle.Bold), new SolidBrush(Color.FromArgb(240, 240, 240)), Rect.X, Rect.Y);
		}

		public override void MouseDown(MouseEventArgs e)
		{
			if (CheckBoundingBox(e))
			{
				EventHandler handler = Click;
				if (handler != null)
				{
					handler(this, e);
				}
			}
		}
	}
}
