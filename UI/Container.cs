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


		#region drawing stuff
		private SolidBrush BackgroudBrush = new SolidBrush(Color.FromArgb(31, 31, 31));
		private Pen BorderPen = new Pen(Color.FromArgb(21, 21, 21));
		#endregion

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
			e.Graphics.FillRectangle(BackgroudBrush, Rect.X, Rect.Y, Rect.W, Rect.H);
			e.Graphics.DrawRectangle(BorderPen, Rect.X, Rect.Y, Rect.W - 1, Rect.H - 1);

			// draw childs
			Nodes.ForEach(fe => fe.Draw(e));
		}

		public override void HandleMouseEvents(Events.MouseEvent e)
		{
			if(!Nodes.Any(a => a.CheckBoundingBox(e)))
				base.HandleMouseEvents(e);

			Nodes.ForEach(fe => fe.HandleMouseEvents(e));
		}

		public override void HandleKeyControlEvents(KeyEventArgs e)
		{
			base.HandleKeyControlEvents(e);

			Nodes.ForEach(fe => fe.HandleKeyControlEvents(e));
		}
	}
}
