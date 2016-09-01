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

		public Main()
		{
			InitializeComponent();

			UI.Container p2 = new UI.Container(new UI.Rect2D { X = 2, Y = 12, W = 246, H = 186 });
			UI.Container p3 = new UI.Container(new UI.Rect2D { X = 250, Y = 12, W = 246, H = 186 });
			UI.Container p4 = new UI.Container(new UI.Rect2D { X = 20, Y = 20, W = 20, H = 20 });

			UI.Button b1 = new UI.Button(new UI.Rect2D { X = 5, Y = 5, W = 30, H = 15 });

			p.AddChild(p2);
			p.AddChild(p3);
			p3.AddChild(p4);

			p2.AddChild(b1);

			this.Paint += new PaintEventHandler(Main_Paint);
		}

		private void Main_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			p.Draw(e);
			int a = 0;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.Refresh();
		}
	}
}
