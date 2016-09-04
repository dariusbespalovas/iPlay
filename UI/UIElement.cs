using System;
using System.Windows.Forms;

namespace iPlay.UI
{
	public abstract class UIElement
	{
		#region EventHandlers
		public EventHandler MouseEnter;
		public EventHandler Click;
		public EventHandler MouseDown;
		public EventHandler MouseUp;
		public EventHandler DoubleClick;
		public EventHandler MouseLeave;
		#endregion

		#region EventHandlersVariables

		protected bool IsMouseOver = false;
		protected bool ClickStarted = false;
		protected long LastClickTime = 0;

		#endregion

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

			if(CheckBoundingBox(e))
			{
				switch(e.Event)
				{
					case Events.MouseEvent.EventType.MouseMove:

						if(!IsMouseOver)
						{
							IsMouseOver = true;
							MouseEnter?.Invoke(this, e);
						}

						break;

					case Events.MouseEvent.EventType.MouseDown:

						ClickStarted = true;
						MouseDown?.Invoke(this, e);

						long ClickTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

						if(ClickTime - LastClickTime < 500)
						{
							LastClickTime = 0;
							DoubleClick?.Invoke(this, e);
						}
						else
						{
							LastClickTime = ClickTime;
						}

						break;

					case Events.MouseEvent.EventType.MouseUp:

						if (ClickStarted)
						{
							ClickStarted = false;
							Click?.Invoke(this, e);
						}

						MouseUp?.Invoke(this, e);

						break;
				}
			}
			else
			{
				switch (e.Event)
				{
					case Events.MouseEvent.EventType.MouseMove:
						if (IsMouseOver)
						{
							IsMouseOver = false;
							MouseLeave?.Invoke(this, e);
						}
						break;

					case Events.MouseEvent.EventType.MouseDown:
						ClickStarted = false;
						break;

					case Events.MouseEvent.EventType.MouseUp:
						ClickStarted = false;
						break;

					
				}
			}

		}
		#endregion

	}
}
