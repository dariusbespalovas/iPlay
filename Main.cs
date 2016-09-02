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
	public partial class Main : Form
	{
		private UI.Container p = new UI.Container(new UI.Rect2D { X = 0, Y = 0, W = 500, H = 200 });

		private string btnClicked = "000";

		public Main()
		{
			InitializeComponent();

			UI.Container p2 = new UI.Container(new UI.Rect2D { X = 2, Y = 12, W = 246, H = 186 });
			UI.Container p3 = new UI.Container(new UI.Rect2D { X = 250, Y = 12, W = 246, H = 186 });
			UI.Container p4 = new UI.Container(new UI.Rect2D { X = 20, Y = 20, W = 20, H = 20 });

			UI.Button b1 = new UI.Button(new UI.Rect2D { X = 5, Y = 5, W = 35, H = 15 },	"B1");
			UI.Button b2 = new UI.Button(new UI.Rect2D { X = 45, Y = 5, W = 35, H = 15 },	"B2");
			UI.Button b3 = new UI.Button(new UI.Rect2D { X = 5, Y = 25, W = 35, H = 15 },	"B3");
			UI.Button b4 = new UI.Button(new UI.Rect2D { X = 45, Y = 25, W = 35, H = 15 },	"B4");

			p.AddChild(p2);
			p.AddChild(p3);
			p3.AddChild(p4);

			p2.AddChild(b1);
			p2.AddChild(b2);
			p2.AddChild(b3);
			p2.AddChild(b4);

			b1.Click += BtnClickHandler;
			b2.Click += BtnClickHandler;
			b3.Click += BtnClickHandler;
			b4.Click += BtnClickHandler;

			this.Paint += new PaintEventHandler(Main_Paint);
		}


		private void BtnClickHandler(object sender, EventArgs e)
		{
			this.btnClicked = ((UI.Button)sender).Name;
			//System.Windows.Forms.MessageBox.Show(((UI.Button)sender).Name);
		}


		private void Main_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			p.Draw(e);

			e.Graphics.DrawString(btnClicked, new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 20, FontStyle.Bold), new SolidBrush(Color.FromArgb(240, 240, 240)), 100, 100);

			int a = 0;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.Refresh();
		}

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            p.MouseDown(e);
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
