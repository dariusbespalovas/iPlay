using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPlay.UI
{
	public abstract class UIElement
	{
		public EventHandler Click;

		public Rect2D Rect;


		public UIElement(Rect2D rect)
		{
			this.Rect = rect;
		}


        protected bool CheckBoundingBox(MouseEventArgs e)
        {
            return(e.X >= Rect.X + 1 && e.X <= Rect.X + Rect.W - 1 &&
                e.Y >= Rect.Y && e.Y <= Rect.Y + Rect.H);
        }


        public abstract void Draw(PaintEventArgs e);

		public virtual void MouseDown(MouseEventArgs e) 
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
		public virtual void MouseUp(MouseEventArgs e) { }
		public virtual void Hover(MouseEventArgs e) { }
		public virtual void OnDblClick(MouseEventArgs e) { }
	}
}
