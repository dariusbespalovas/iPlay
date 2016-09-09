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
		public Rect2D OriginalRect;
		public AnchorStyles Anchor { get; set; }

		protected Rect2D RectScreenSpace;

		protected System.Drawing.Graphics graphics;
		protected System.Drawing.Bitmap Bmp;

		

		public UIElement(Rect2D rect)
		{
			this.Rect = rect;
			this.RectScreenSpace = new Rect2D
			{
				X = rect.X,
				Y = rect.Y,
				W = rect.W,
				H = rect.H
			};
			this.OriginalRect = new Rect2D
			{
				X = rect.X,
				Y = rect.Y,
				W = rect.W,
				H = rect.H
			};
			this.Bmp = new System.Drawing.Bitmap(Rect.W, rect.H);
			this.graphics = System.Drawing.Graphics.FromImage(this.Bmp);
			this.Anchor = AnchorStyles.None;

			//System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(this.Bmp);

			//gr.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0, 0)), new System.Drawing.Rectangle(1, 1, Rect.W, Rect.H));
		}

		public bool CheckBoundingBox(Events.MouseEvent e)
		{
			return(	e.X >= RectScreenSpace.X && e.X < RectScreenSpace.X + RectScreenSpace.W &&
					e.Y >= RectScreenSpace.Y && e.Y < RectScreenSpace.Y + RectScreenSpace.H);
		}

		public abstract void Draw(PaintEventArgs e);
		public virtual void Update(UIElement parrent)
		{
			RectScreenSpace.X = Rect.X;
			RectScreenSpace.Y = Rect.Y;

			if (parrent != null)
			{
				this.RectScreenSpace.X += parrent.RectScreenSpace.X;
				this.RectScreenSpace.Y += parrent.RectScreenSpace.Y;
			}

			

			RectScreenSpace.W = Rect.W;
			RectScreenSpace.H = Rect.H;


			//this.RectScreenSpace.X = parrent.Rect.W - this.Rect.W - this.RectScreenSpace.X;

			//this.RectScreenSpace.X = (parrent.Rect.X + parrent.Rect.W) - (parrent.RectScreenSpace.W - this.RectScreenSpace.X);

			//this.RectScreenSpace.X = parrent.Rect.W - this.Rect.W - this.RectScreenSpace.X;


			if ((Anchor & (AnchorStyles.Left | AnchorStyles.Right)) == (AnchorStyles.Left | AnchorStyles.Right))
			{
				this.RectScreenSpace.W += parrent.RectScreenSpace.W - parrent.OriginalRect.W;
			}
			else if ((Anchor & AnchorStyles.Right) == AnchorStyles.Right)
			{
				this.RectScreenSpace.X = parrent.RectScreenSpace.X + parrent.RectScreenSpace.W - (parrent.OriginalRect.W - this.OriginalRect.X);
			}


			if ((Anchor & (AnchorStyles.Bottom | AnchorStyles.Top)) == (AnchorStyles.Bottom | AnchorStyles.Top))
			{
				this.RectScreenSpace.H += parrent.RectScreenSpace.H - parrent.OriginalRect.H; 
			}
			else if ((Anchor & AnchorStyles.Bottom) == AnchorStyles.Bottom)
			{
				this.RectScreenSpace.Y = parrent.RectScreenSpace.Y + parrent.RectScreenSpace.H - (parrent.OriginalRect.H - this.OriginalRect.Y);
			}

			

			//switch (Anchor)
			//{
			//	case AnchorStyles.None:




			//		break;

			//	case AnchorStyles.Left | AnchorStyles.Right:

			//		break;

			//	case AnchorStyles.Right:
			//		this.RectScreenSpace.X = parrent.RectScreenSpace.X + parrent.RectScreenSpace.W - (parrent.OriginalRect.W - this.OriginalRect.X);
			//		break;
			//	case AnchorStyles.Bottom:
			//		this.RectScreenSpace.Y = parrent.RectScreenSpace.Y + parrent.RectScreenSpace.H - (parrent.OriginalRect.H - this.OriginalRect.Y);

			//		break;


			//}

		}

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

		public virtual void HandleKeyControlEvents(KeyEventArgs e)
		{

		}
		#endregion

	}
}
