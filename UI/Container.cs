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
		private Pen BorderPen = new Pen(Color.FromArgb(121, 21, 21));
		#endregion

		public Container(Rect2D rect) : base(rect)
		{
			this.Nodes = new List<UIElement>();
		}

		public Container AddChild(UIElement item)
		{
			//item.Rect.X += this.Rect.X;
			//item.Rect.Y += this.Rect.Y;

			this.Nodes.Add(item);

			return this;
		}

		public override void Draw(System.Windows.Forms.PaintEventArgs e)
		{
			// draw self
			e.Graphics.FillRectangle(BackgroudBrush, RectScreenSpace.X, RectScreenSpace.Y, RectScreenSpace.W, RectScreenSpace.H);
			e.Graphics.DrawRectangle(BorderPen, RectScreenSpace.X, RectScreenSpace.Y, RectScreenSpace.W - 1, RectScreenSpace.H - 1);

			// draw childs
			Nodes.ForEach(fe => fe.Draw(e));
		}

		public override void Update(UIElement parrent)
		{
			base.Update(parrent);
			Nodes.ForEach(fe => fe.Update(this));
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
