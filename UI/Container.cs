using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPlay.UI
{
	public class Container : UIElement
	{
		private List<UIElement> Nodes;

		public Container(Rect2D rect) : base(rect)
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
			e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(31, 31, 31)), new Rectangle(Rect.X, Rect.Y, Rect.W, Rect.H));
			e.Graphics.DrawRectangle(new Pen(Color.FromArgb(21, 21, 21)), new Rectangle(Rect.X, Rect.Y, Rect.W, Rect.H));

			// draw childs
			Nodes.ForEach(fe => fe.Draw(e));
		}

        public override void MouseDown(MouseEventArgs e)
        {
            Nodes.ForEach(fe => fe.MouseDown(e));
        }
    }
}
