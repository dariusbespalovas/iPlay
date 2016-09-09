using System;
using System.Drawing;
using System.Windows.Forms;

namespace iPlay
{
	public class CustomForm : Form
	{
		private UI.Container uiForm;
		
		protected UI.Button buttonMinimize;
		protected UI.Button buttonClose;

		protected UI.Container uiContainer;

		private bool mouseDown;
		private Point lastLocation;

		//protected CustomForm() : this(100, 100)
		//{
			
		//}

		protected CustomForm(int width, int height)
		{
			InitializeComponent();

			this.uiForm = new UI.Container(new UI.Rect2D { X = 0, Y = 0, W = width, H = height });
			this.uiContainer = new UI.Container(new UI.Rect2D { X = 4, Y = 12, W = width-8, H = height-16 });

			this.buttonMinimize = new UI.Button(new UI.Rect2D { X = width - 21, Y = 2, W = 9, H = 9 }, "Minimize");
			this.buttonClose = new UI.Button(new UI.Rect2D { X = width - 11, Y = 2, W = 9, H = 9 }, "Close");

			this.uiForm
				.AddChild(buttonMinimize)
				.AddChild(buttonClose)
				.AddChild(uiContainer);

			this.uiContainer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
			this.buttonMinimize.Anchor = AnchorStyles.Right;
			this.buttonClose.Anchor = AnchorStyles.Right;

			this.buttonMinimize.Click += BtnMinimizeHandler;
			this.buttonClose.Click += BtnCloseHandler;
		}

		private void BtnMinimizeHandler(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void BtnCloseHandler(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CustomForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if(uiForm != null)
			{
				uiForm.Rect.W = this.ClientSize.Width;
				uiForm.Rect.H = this.ClientSize.Height;
			}

			uiForm?.Update(null);
			uiForm?.Draw(e.Graphics);
		}

		private void CustomForm_MouseDown(object sender, MouseEventArgs e)
		{
			if(e.X < (uiForm.Rect.W - 22) && e.Y < 12)
			{
				mouseDown = true;
				lastLocation = e.Location;
			}

			uiForm?.HandleMouseEvents(new Events.MouseEvent(iPlay.Events.MouseEvent.EventType.MouseDown, e));
		}

		private void CustomForm_MouseUp(object sender, MouseEventArgs e)
		{
			mouseDown = false;

			uiForm?.HandleMouseEvents(new Events.MouseEvent(iPlay.Events.MouseEvent.EventType.MouseUp, e));
		}

		private void CustomForm_MouseMove(object sender, MouseEventArgs e)
		{
			if(mouseDown)
			{
				this.Location = new Point(
					(this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

				this.Update();
			}

			uiForm?.HandleMouseEvents(new Events.MouseEvent(iPlay.Events.MouseEvent.EventType.MouseMove, e));
		}

		private void CustomForm_MouseWheel(object sender, MouseEventArgs e)
		{
			uiContainer?.HandleMouseEvents(new Events.MouseEvent(iPlay.Events.MouseEvent.EventType.MouseWheel, e));
		}

		private void CustomForm_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		private void CustomForm_KeyPress2(object sender, KeyEventArgs e)
		{
			uiForm?.HandleKeyControlEvents(e);
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();

			this.Name = "CustomForm";

			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;// | FormBorderStyle.Sizable;

			this.Paint += new PaintEventHandler(CustomForm_Paint);

			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustomForm_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CustomForm_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustomForm_MouseUp);
			this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.CustomForm_MouseWheel);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomForm_KeyPress);
			this.KeyPreview = true;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomForm_KeyPress2);

			this.ResumeLayout(false);
		}

		private const int cGrip = 5;      // Grip size
		//private const int cCaption = 32;   // Caption bar height;

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x84)
			{  // Trap WM_NCHITTEST
				Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
				pos = this.PointToClient(pos);
				//if (pos.Y < cCaption)
				//{
				//	m.Result = (IntPtr)2;  // HTCAPTION
				//	return;
				//}
				if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
				{
					m.Result = (IntPtr)17; // HTBOTTOMRIGHT
					return;
				}
			}
			base.WndProc(ref m);
		}
	}
}