using System.Windows.Forms;

namespace iPlay
{
	public class CustomForm : Form
	{
		protected UI.Container uiContainer;

		protected CustomForm()
		{
			InitializeComponent();
		}

		private void CustomForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			uiContainer?.Draw(e);
		}

		private void CustomForm_MouseDown(object sender, MouseEventArgs e)
		{
			uiContainer?.HandleMouseEvents(new Events.MouseEvent(iPlay.Events.MouseEvent.EventType.MouseDown, e));
		}

		private void CustomForm_MouseUp(object sender, MouseEventArgs e)
		{
			uiContainer?.HandleMouseEvents(new Events.MouseEvent(iPlay.Events.MouseEvent.EventType.MouseUp, e));
		}

		private void CustomForm_MouseMove(object sender, MouseEventArgs e)
		{
			uiContainer?.HandleMouseEvents(new Events.MouseEvent(iPlay.Events.MouseEvent.EventType.MouseMove, e));
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
			uiContainer?.HandleKeyControlEvents(e);
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// CustomForm
			// 
			//this.ClientSize = new System.Drawing.Size(386, 258);
			this.Name = "CustomForm";

			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

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