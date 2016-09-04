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
		private UI.Container p = new UI.Container(new UI.Rect2D { X = 0, Y = 0, W = 490, H = 150 });

		private string btnClicked = "000";

		private string DoubleClickResult = "010";

		public Main()
		{
			InitializeComponent();

			UI.Container p2 = new UI.Container(new UI.Rect2D { X = 5, Y = 13, W = 480, H = 132 });
			UI.Container p3 = new UI.Container(new UI.Rect2D { X = 250, Y = 12, W = 246, H = 186 });
			UI.Container p4 = new UI.Container(new UI.Rect2D { X = 20, Y = 20, W = 20, H = 20 });

			UI.Button b1 = new UI.Button(new UI.Rect2D { X = 5, Y = 115, W = 17, H = 13 },	"Prev");
			UI.Button b2 = new UI.Button(new UI.Rect2D { X = 24, Y = 115, W = 17, H = 13 }, "Play");
			UI.Button b3 = new UI.Button(new UI.Rect2D { X = 43, Y = 115, W = 17, H = 13 }, "Pause");
			UI.Button b4 = new UI.Button(new UI.Rect2D { X = 62, Y = 115, W = 17, H = 13 }, "Stop");
			UI.Button b5 = new UI.Button(new UI.Rect2D { X = 81, Y = 115, W = 17, H = 13 }, "Next");

			UI.Button b6 = new UI.Button(new UI.Rect2D { X = 468, Y = 2, W = 7, H = 7 }, "Minimize");
			UI.Button b7 = new UI.Button(new UI.Rect2D { X = 478, Y = 2, W = 7, H = 7 }, "Close");

			p.AddChild(p2);

			p.AddChild(b6);
			p.AddChild(b7);

			//p.AddChild(p3);
			//p3.AddChild(p4);

			p2.AddChild(b1);
			p2.AddChild(b2);
			p2.AddChild(b3);
			p2.AddChild(b4);
			p2.AddChild(b5);

			b1.Click += BtnClickHandler;
			b1.DoubleClick += BtnDblClickHandler;
			b2.Click += BtnClickHandler;
			b3.Click += BtnClickHandler;
			b4.Click += BtnClickHandler;
			b5.Click += BtnClickHandler;

			b6.Click += BtnClickHandler;
			b7.Click += BtnCloseHandler;

			//p2.Click += PanelClickHandler;
			//p4.Click += PanelClickHandler;

			this.Paint += new PaintEventHandler(Main_Paint);


			var xml = System.IO.File.ReadAllText("settings.xml");
			var sss = Utils.XmlUtility.DeserializeFromXmlString<Settings>(xml);


		  
		}


		private void BtnCloseHandler(object sender, EventArgs e)
		{
			var a = this.Top;
			var b = this.Left;

			Settings.Instance.WindowX = this.Left;
			Settings.Instance.WindowY = this.Top;

			string s = Utils.XmlUtility.SerializeToXmlString(Settings.Instance);

			System.IO.File.WriteAllText("settings.xml", s);


			

			Application.Exit();
			//this.btnClicked = ((UI.Button)sender).Name;
			//System.Windows.Forms.MessageBox.Show(((UI.Button)sender).Name);
		}


		private void BtnClickHandler(object sender, EventArgs e)
		{
			this.btnClicked = ((UI.Button)sender).Name;
			//System.Windows.Forms.MessageBox.Show(((UI.Button)sender).Name);
		}

		private void BtnDblClickHandler(object sender, EventArgs e)
		{
			this.DoubleClickResult = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond).ToString();
			//System.Windows.Forms.MessageBox.Show(((UI.Button)sender).Name);
		}

		private void PanelClickHandler(object sender, EventArgs e)
		{
			//this.btnClicked = ((UI.Button)sender).Name;
			//System.Windows.Forms.MessageBox.Show("panel click");

			this.btnClicked = "C";
		}

		private void Main_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			p.Draw(e);

			e.Graphics.DrawString(btnClicked, new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 20, FontStyle.Bold), new SolidBrush(Color.FromArgb(240, 240, 240)), 100, 100);
			e.Graphics.DrawString(DoubleClickResult, new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 20, FontStyle.Bold), new SolidBrush(Color.FromArgb(240, 240, 240)), 100, 80);

			int a = 0;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.Refresh();
		}









		private void Main_MouseDown(object sender, MouseEventArgs e)
		{
			p.HandleMouseEvents(new Events.MouseEvent(iPlay.Events.MouseEvent.EventType.MouseDown, e));
		}

		private void Main_MouseUp(object sender, MouseEventArgs e)
		{
			p.HandleMouseEvents(new Events.MouseEvent(iPlay.Events.MouseEvent.EventType.MouseUp, e));
		}

		private void Main_MouseMove(object sender, MouseEventArgs e)
		{
			p.HandleMouseEvents(new Events.MouseEvent(iPlay.Events.MouseEvent.EventType.MouseMove, e));
		}

	}
}
