﻿using System.Drawing;
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

		protected CustomForm()
		{
			InitializeComponent();

			this.uiForm = new UI.Container(new UI.Rect2D { X = 0, Y = 0, W = 488, H = 145 });
			this.uiContainer = new UI.Container(new UI.Rect2D { X = 4, Y = 12, W = 480, H = 129 });

			this.buttonMinimize = new UI.Button(new UI.Rect2D { X = 467, Y = 2, W = 9, H = 9 }, "Minimize");
			this.buttonClose = new UI.Button(new UI.Rect2D { X = 477, Y = 2, W = 9, H = 9 }, "Close");

			this.uiForm
				.AddChild(buttonMinimize)
				.AddChild(buttonClose)
				.AddChild(uiContainer);


			this.uiContainer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.buttonMinimize.Anchor = AnchorStyles.Right;
			this.buttonClose.Anchor = AnchorStyles.Right;

		}

		private void CustomForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if(uiForm != null)
			{
				uiForm.Rect.W = this.ClientSize.Width;
				uiForm.Rect.H = this.ClientSize.Height;
			}

			uiForm?.Update(null);
			uiForm?.Draw(e);
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
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;// | FormBorderStyle.Sizable;
			

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
	}
}