using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPlay
{
	public partial class VideoForm : CustomForm
	{
		public VideoForm() : base(500, 500)
		{
			InitializeComponent();

			UI.Slider sliderVideoProgress = new UI.Slider(new UI.Rect2D { X = 5, Y = this.uiContainer.Rect.H - this.uiContainer.Rect.Y, W = this.uiContainer.Rect.W - 10, H = 7 }, "Slider1", UI.Slider.SliderOrientation.Horizontal);

			sliderVideoProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

			this.uiContainer.AddChild(sliderVideoProgress);

			this.ClientSize = new System.Drawing.Size(500, 500);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.Refresh();
		}
	}
}
