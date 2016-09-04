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
		public string Name { get; private set; }
		private float _Progress;


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

		public float Progress
		{
			get
			{
				return _Progress;
			}
			set
			{
				_Progress = value;
				if (_Progress > 1)
					_Progress = 1;

				if (_Progress < 0)
					_Progress = 0;
			}
		}

		public Slider(Rect2D rect, string Name) : base(rect)
		{
			this.Name = Name;
			this.MouseDown += this.MClick;
		}



		public override void Draw(System.Windows.Forms.PaintEventArgs e)
		{

			graphics.FillRectangle(BackgroudBrush, 0, 0, Rect.W, Rect.H);


			int center = (int)((Rect.W- (SL_SPACE * 2)) * ((float)Progress));



			graphics.DrawLine(PenLine, 
				0, 
				(int)((Rect.H / 2) + 0.5), 
				Rect.W, 
				(int)((Rect.H / 2) + 0.5));


			int c_cube = (int)(center - (int)((float)SL_CUBE / 2 + 0.5) + SL_SPACE-0.5);


			graphics.FillRectangle(BrushSlider, c_cube + 1, 0, SL_CUBE, Rect.H);
			graphics.DrawRectangle(PenBorder, c_cube + 1, 0, SL_CUBE-1, Rect.H - 1);




			e.Graphics.DrawImageUnscaled(Bmp, Rect.X, Rect.Y);









			
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



		private void MClick(object sender, EventArgs e)
		{
			UpdateProgress(((Events.MouseEvent)e).X);
		}


		private void UpdateProgress(int MousePosition)
		{
			int tmp = MousePosition - Rect.X - (int)SL_SPACE;
			LastMousePoint1 = LastMousePoint2;
			LastMousePoint2 = tmp;


			if (MousePosition >= Rect.X + 1 + SL_SPACE && MousePosition <= Rect.X + Rect.W - 1 - SL_SPACE)
			{

				if (LastMousePoint1 != tmp) Progress = (float)tmp / (Rect.W - 2 * SL_SPACE) /** 100*/;
			}
			else
			{

				if (MousePosition < Rect.X + 1 + SL_SPACE) Progress = 0.0001f;
				if (MousePosition > Rect.X + Rect.W - 1 - SL_SPACE) Progress = 1f;

			}
		}
	}
}
