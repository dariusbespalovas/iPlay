using System;
namespace iPlay.Events
{
	public class MouseEvent : EventArgs
	{
		public enum EventType
		{
			MouseDown,
			MouseUp,
			MouseMove
		}

		public enum MouseButton
		{
			None,
			Left,
			Right,
			Middle
		}

		public MouseEvent(EventType Event, System.Windows.Forms.MouseEventArgs e)
		{
			this.Event = Event;
			this.Button = this.GetButtonType(e.Button);
			this.X = e.X;
			this.Y = e.Y;
		}


		public EventType Event { get; private set; }
		public MouseButton Button { get; private set; }
		public int X { get; private set; }
		public int Y { get; private set; }

		private MouseButton GetButtonType(System.Windows.Forms.MouseButtons e)
		{
			switch(e)
			{
				case System.Windows.Forms.MouseButtons.Left:
					return MouseButton.Left;
					break;
				case System.Windows.Forms.MouseButtons.Right:
					return MouseButton.Right;
					break;
				case System.Windows.Forms.MouseButtons.Middle:
					return MouseButton.Middle;
					break;
				default:
					return MouseButton.None;
					break;
			}
		}
	}
}
