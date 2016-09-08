using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPlay.UI
{
	public class Slider : UIElement
	{
		#region EventHandlers
		public EventHandler Change;
		#endregion

		public string Name { get; private set; }
		private float _Value;
		private SliderOrientation Orientation;
		private bool IsMouseDown = false;

		private const float SL_SPACE = 4.5f;
		private const int SL_CUBE = 9;

		private int LastMousePoint1 = 0, LastMousePoint2 = 0;


		#region drawing stuff
		private SolidBrush BackgroudBrush = new SolidBrush(Color.FromArgb(31, 31, 31));
		private Pen BorderPen = new Pen(Color.FromArgb(21, 21, 21));

		private Pen PenLine = new Pen(Color.FromArgb(255, 240, 240, 240));
		private SolidBrush BrushSlider = new SolidBrush(Color.FromArgb(255, 240, 240, 240));
		private Pen PenBorder = new Pen(Color.FromArgb(255, 0, 0, 0));
		#endregion

		public enum SliderOrientation
		{
			Horizontal,
			Vertical
		}

		public float Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
				if (_Value > 1)
					_Value = 1;

				if (_Value < 0)
					_Value = 0;
			}
		}

		public Slider(Rect2D rect, string Name, SliderOrientation Orientation) : base(rect)
		{
			this.Name = Name;
			
			this.Orientation = Orientation;


			this.MouseDown += this.MDown;
		}


		public override void Draw(System.Windows.Forms.PaintEventArgs e)
		{
			graphics.FillRectangle(BackgroudBrush, 0, 0, RectScreenSpace.W, RectScreenSpace.H);


			if (Orientation == SliderOrientation.Horizontal)
			{
				int center = (int)((RectScreenSpace.W - (SL_SPACE * 2)) * ((float)Value));

				graphics.DrawLine(PenLine,
					0,
					(int)((RectScreenSpace.H / 2) + 0.5),
					RectScreenSpace.W,
					(int)((RectScreenSpace.H / 2) + 0.5));


				int c_cube = (int)(center - (int)((float)SL_CUBE / 2 + 0.5) + SL_SPACE - 0.5);


				graphics.FillRectangle(BrushSlider, c_cube + 1, 0, SL_CUBE, RectScreenSpace.H);
				graphics.DrawRectangle(PenBorder, c_cube + 1, 0, SL_CUBE - 1, RectScreenSpace.H - 1);
			}

			if (Orientation == SliderOrientation.Vertical)
			{
				int center = (int)((RectScreenSpace.H - (SL_SPACE * 2)) * ((float)Value));

				graphics.DrawLine(PenLine,
					(int)((RectScreenSpace.W / 2) + 0.5),
					0,
					(int)((RectScreenSpace.W / 2) + 0.5),
					RectScreenSpace.H);


				int c_cube = (int)(center - (int)((float)SL_CUBE / 2 + 0.5) + SL_SPACE - 0.5);


				graphics.FillRectangle(BrushSlider, 0, c_cube + 1, RectScreenSpace.W, SL_CUBE);
				graphics.DrawRectangle(PenBorder, 0, c_cube + 1, RectScreenSpace.W - 1, SL_CUBE - 1);
			}

			e.Graphics.DrawImageUnscaled(Bmp, RectScreenSpace.X, RectScreenSpace.Y);
		}




		//int Calculate()
		//{
		//	LPPOINT p = new POINT;
		//	GetCursorPos(p);
		//	ScreenToClient(hWnd, p);

		//	int tmp = p->x - dimensions->x - SL_SPACE;
		//	lastMousePoint1 = lastMousePoint2;
		//	lastMousePoint2 = tmp;


		//	if (p->x >= dimensions->x + 1 + SL_SPACE && p->x <= dimensions->x + dimensions->width - 1 - SL_SPACE)
		//	{

		//		if (lastMousePoint1 != tmp) progress = (float)tmp / (dimensions->width - 2 * SL_SPACE) * 100;
		//	}
		//	else
		//	{

		//		if (p->x < dimensions->x + 1 + SL_SPACE) progress = 0.01;
		//		if (p->x > dimensions->x + dimensions->width - 1 - SL_SPACE) progress = 100;

		//	}



		//	delete[] p;

		//	if (lastMousePoint1 != lastMousePoint2)
		//	{
		//		SendMessage(hWnd, WM_COMMAND, control_id, 0);
		//		UpdateGraphics();
		//	}
		//	return 0;
		//}



		private void MDown(object sender, EventArgs e)
		{
			this.IsMouseDown = true;
			UpdateProgress((Events.MouseEvent)e);
		}


		public override void HandleMouseEvents(Events.MouseEvent e)
		{
			base.HandleMouseEvents(e);
			switch(e.Event)
			{
				case Events.MouseEvent.EventType.MouseMove:
					if (IsMouseDown)
					{
						UpdateProgress(e);
					}
					break;

				case Events.MouseEvent.EventType.MouseUp:
					IsMouseDown = false;
					break;
			}
		}


		private void UpdateProgress(Events.MouseEvent e)
		{
			int MousePosition = Orientation == SliderOrientation.Horizontal ? ((Events.MouseEvent)e).X : ((Events.MouseEvent)e).Y;

			if (Orientation == SliderOrientation.Horizontal)
			{
				int tmp = MousePosition - RectScreenSpace.X - (int)SL_SPACE;
				LastMousePoint1 = LastMousePoint2;
				LastMousePoint2 = tmp;

				if (MousePosition >= RectScreenSpace.X + 1 + SL_SPACE && MousePosition <= RectScreenSpace.X + RectScreenSpace.W - 1 - SL_SPACE)
				{

					if (LastMousePoint1 != tmp) Value = (float)tmp / (RectScreenSpace.W - 2 * SL_SPACE) /** 100*/;
				}
				else
				{

					if (MousePosition < RectScreenSpace.X + 1 + SL_SPACE) Value = 0f;
					if (MousePosition > RectScreenSpace.X + RectScreenSpace.W - 1 - SL_SPACE) Value = 1f;

				}
			}


			if (Orientation == SliderOrientation.Vertical)
			{
				int tmp = MousePosition - RectScreenSpace.Y - (int)SL_SPACE;
				LastMousePoint1 = LastMousePoint2;
				LastMousePoint2 = tmp;

				if (MousePosition >= RectScreenSpace.Y + 1 + SL_SPACE && MousePosition <= RectScreenSpace.Y + RectScreenSpace.H - 1 - SL_SPACE)
				{

					if (LastMousePoint1 != tmp) Value = (float)tmp / (RectScreenSpace.H - 2 * SL_SPACE) /** 100*/;
				}
				else
				{

					if (MousePosition < RectScreenSpace.Y + 1 + SL_SPACE) Value = 0f;
					if (MousePosition > RectScreenSpace.Y + RectScreenSpace.H - 1 - SL_SPACE) Value = 1f;

				}
			}

			Change?.Invoke(this, e);
		}
	}
}
