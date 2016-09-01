using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPlay.UI
{
	public class Panel : UIElement
	{
		private List<UIElement> Nodes;

		public Panel(Rect2D rect) : base(rect)
		{
			this.Nodes = new List<UIElement>();
		}

		public void AddChild(UIElement item)
		{
			item.Rect.X += this.Rect.X;
			item.Rect.Y += this.Rect.Y;

			this.Nodes.Add(item);
		}


		public override void Draw(System.Windows.Forms.PaintEventArgs e)
		{
			// draw self
			e.Graphics.FillRectangle(System.Drawing.Brushes.IndianRed, new Rectangle(Rect.X, Rect.Y, Rect.W, Rect.H));
			e.Graphics.DrawRectangle(System.Drawing.Pens.Red, new Rectangle(Rect.X, Rect.Y, Rect.W, Rect.H));

			// draw childs
			Nodes.ForEach(fe => fe.Draw(e));
		}
	}
}
