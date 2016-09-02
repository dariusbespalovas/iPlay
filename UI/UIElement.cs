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
		public EventHandler MouseDown;
		public EventHandler MouseUp;
		public EventHandler Hover;
		public EventHandler DoubleClick;

		public Rect2D Rect;

		public UIElement(Rect2D rect)
		{
			this.Rect = rect;
		}

		public bool CheckBoundingBox(Events.MouseEvent e)
		{
			return(e.X >= Rect.X && e.X <= Rect.X + Rect.W &&
				e.Y >= Rect.Y && e.Y <= Rect.Y + Rect.H);
		}

		public abstract void Draw(PaintEventArgs e);

		#region EVENTS
		public virtual void HandleMouseEvents(Events.MouseEvent e)
		{

			if (CheckBoundingBox(e))
			{
				EventHandler handler = null;

				if(e.Event == Events.MouseEvent.EventType.MouseDown && e.Button == Events.MouseEvent.MouseButton.Left)
					handler = MouseDown;

				if (e.Event == Events.MouseEvent.EventType.MouseUp && e.Button == Events.MouseEvent.MouseButton.Left)
					handler = MouseUp;

				if (e.Event == Events.MouseEvent.EventType.MouseDown && e.Button == Events.MouseEvent.MouseButton.Left)
					handler = Click;

				
				if (handler != null)
				{
					handler(this, e);
				}

			}
			else
			{
				//clear events;
			}
		}
		#endregion

	}
}
