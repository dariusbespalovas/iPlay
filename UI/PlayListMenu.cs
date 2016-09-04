using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPlay.UI
{
	public class PlayListMenu : UIElement
	{
		private Slider Scrollbar;


		#region drawing stuff
		private SolidBrush BackgroudBrush = new SolidBrush(Color.FromArgb(131, 31, 31));
		private Pen BorderPen = new Pen(Color.Orange);
		#endregion

		//private bool UpdateLocations

		public PlayListMenu(Rect2D Rect) : base(Rect)
		{
			Scrollbar = new UI.Slider(new UI.Rect2D { X = this.Rect.X, Y = this.Rect.Y, W = 7, H = this.Rect.H }, "Slider1", UI.Slider.SliderOrientation.Vertical);
		}

		private void UpdateLocations()
		{
			Scrollbar.Rect.X = this.Rect.X + this.Rect.W - 7;
			Scrollbar.Rect.Y = this.Rect.Y;
		}


		public override void Draw(System.Windows.Forms.PaintEventArgs e)
		{
			UpdateLocations();

			graphics.FillRectangle(BackgroudBrush, 0, 0, Rect.W, Rect.H);
			graphics.DrawRectangle(BorderPen, 0, 0, Rect.W - 1, Rect.H - 1);

			e.Graphics.DrawImageUnscaled(Bmp, Rect.X, Rect.Y);

			Scrollbar.Draw(e);
		}

		public override void HandleMouseEvents(Events.MouseEvent e)
		{
			if(!Scrollbar.CheckBoundingBox(e))
				base.HandleMouseEvents(e);

			//if (!Nodes.Any(a => a.CheckBoundingBox(e)))
			//	base.HandleMouseEvents(e);

			Scrollbar.HandleMouseEvents(e);
		}
	}
}
