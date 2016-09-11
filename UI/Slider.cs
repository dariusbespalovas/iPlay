using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPlay.UI
{
	public partial class Slider : Control
	{
		#region EventHandlers
		//[SRCategoryAttribute("CatPropertyChanged")]
		//[IODescriptionAttribute("ControlOnTextChangedDescr")]
		public event EventHandler ValueChanged;
		#endregion

		private float _Value;
		private SliderOrientation _Orientation;

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

		public SliderOrientation Orientation
		{
			get
			{
				return _Orientation;
			}

			set
			{
				this.Invalidate();
				_Orientation = value;
			}
		}

		public float Value
		{
			get
			{
				return _Value;
			}
			set
			{
				if (value != _Value)
					this.Invalidate();

				_Value = value;
				if (_Value > 1)
					_Value = 1;

				if (_Value < 0)
					_Value = 0;
			}
		}

		public Slider()
		{
			InitializeComponent();

			this.MouseDown += Slider_MouseDown;
			this.MouseMove += Slider_MouseMove;
			this.MouseUp += Slider_MouseUp;
		}

		private void Slider_MouseUp(object sender, MouseEventArgs e)
		{
			this.IsMouseDown = false;
		}

		private void Slider_MouseMove(object sender, MouseEventArgs e)
		{
			if(this.IsMouseDown)
				UpdateProgress(e);
		}

		private void Slider_MouseDown(object sender, MouseEventArgs e)
		{
			this.IsMouseDown = true;
			UpdateProgress(e);
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);


			pe.Graphics.FillRectangle(BackgroudBrush, 0, 0, this.ClientRectangle.Width, ClientRectangle.Height);


			if (_Orientation == SliderOrientation.Horizontal)
			{
				int center = (int)((ClientRectangle.Width - (SL_SPACE * 2)) * ((float)Value));

				pe.Graphics.DrawLine(PenLine,
					0,
					(int)((ClientRectangle.Height / 2) + 0.5),
					ClientRectangle.Width,
					(int)((ClientRectangle.Height / 2) + 0.5));


				int c_cube = (int)(center - (int)((float)SL_CUBE / 2 + 0.5) + SL_SPACE - 0.5);


				pe.Graphics.FillRectangle(BrushSlider, c_cube + 1, 0, SL_CUBE, ClientRectangle.Height);
				pe.Graphics.DrawRectangle(PenBorder, c_cube + 1, 0, SL_CUBE - 1, ClientRectangle.Height - 1);
			}

			if (_Orientation == SliderOrientation.Vertical)
			{
				int center = (int)((ClientRectangle.Height - (SL_SPACE * 2)) * ((float)Value));

				pe.Graphics.DrawLine(PenLine,
					(int)((ClientRectangle.Width / 2) + 0.5),
					0,
					(int)((ClientRectangle.Width / 2) + 0.5),
					ClientRectangle.Height);


				int c_cube = (int)(center - (int)((float)SL_CUBE / 2 + 0.5) + SL_SPACE - 0.5);


				pe.Graphics.FillRectangle(BrushSlider, 0, c_cube + 1, ClientRectangle.Width, SL_CUBE);
				pe.Graphics.DrawRectangle(PenBorder, 0, c_cube + 1, ClientRectangle.Width - 1, SL_CUBE - 1);
			}

			//g.DrawImageUnscaled(Bmp, RectScreenSpace.X, RectScreenSpace.Y);
		}

		private void UpdateProgress(MouseEventArgs e)
		{
			int MousePosition = Orientation == SliderOrientation.Horizontal ? e.X : e.Y;

			if (Orientation == SliderOrientation.Horizontal)
			{
				int tmp = MousePosition - ClientRectangle.X - (int)SL_SPACE;
				LastMousePoint1 = LastMousePoint2;
				LastMousePoint2 = tmp;

				if (MousePosition >= ClientRectangle.X + 1 + SL_SPACE && MousePosition <= ClientRectangle.X + ClientRectangle.Width - 1 - SL_SPACE)
				{

					if (LastMousePoint1 != tmp) Value = (float)tmp / (ClientRectangle.Width - 2 * SL_SPACE) /** 100*/;
				}
				else
				{

					if (MousePosition < ClientRectangle.X + 1 + SL_SPACE) Value = 0f;
					if (MousePosition > ClientRectangle.X + ClientRectangle.Width - 1 - SL_SPACE) Value = 1f;

				}
			}


			if (Orientation == SliderOrientation.Vertical)
			{
				int tmp = MousePosition - ClientRectangle.Y - (int)SL_SPACE;
				LastMousePoint1 = LastMousePoint2;
				LastMousePoint2 = tmp;

				if (MousePosition >= ClientRectangle.Y + 1 + SL_SPACE && MousePosition <= ClientRectangle.Y + ClientRectangle.Height - 1 - SL_SPACE)
				{

					if (LastMousePoint1 != tmp) Value = (float)tmp / (ClientRectangle.Height - 2 * SL_SPACE) /** 100*/;
				}
				else
				{

					if (MousePosition < ClientRectangle.Y + 1 + SL_SPACE) Value = 0f;
					if (MousePosition > ClientRectangle.Y + ClientRectangle.Height - 1 - SL_SPACE) Value = 1f;

				}
			}

			ValueChanged?.Invoke(this, e);
		}
	}
}
