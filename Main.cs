using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace iPlay
{
	public partial class Main : Form
	{
		private UI.Container p = new UI.Container(new UI.Rect2D { X = 0, Y = 0, W = 488, H = 145 });

		private string btnClicked = "000";

		private string sliderResult = "010";

		public Main()
		{
			InitializeComponent();


			List<PlaylistItemModel> playlist = new List<PlaylistItemModel>();
			for(int i = 0; i < 500; i++)
			{
				playlist.Add(new PlaylistItemModel
				{
					Name = "Name" + i.ToString(),
					Path = "Path" + i.ToString(),
					Duration = 0
				});
			}


			List<UI.PlayListMenu<PlaylistItemModel>.TableSetingsModel> playlistSetings = new List<UI.PlayListMenu<PlaylistItemModel>.TableSetingsModel>
			{
				new UI.PlayListMenu<PlaylistItemModel>.TableSetingsModel()
				{
					FieldName = "Name",
					Width = 150
				},

				new UI.PlayListMenu<PlaylistItemModel>.TableSetingsModel()
				{
					FieldName = "Path",
					Width = 50
				}

			};


			UI.Container p2 = new UI.Container(new UI.Rect2D { X = 4, Y = 12, W = 480, H = 129 });

			UI.Button b1 = new UI.Button(new UI.Rect2D { X = 4,	Y = 113, W = 17, H = 13 },	"Prev");
			UI.Button b2 = new UI.Button(new UI.Rect2D { X = 22, Y = 113, W = 17, H = 13 }, "Play");
			UI.Button b3 = new UI.Button(new UI.Rect2D { X = 40, Y = 113, W = 17, H = 13 }, "Pause");
			UI.Button b4 = new UI.Button(new UI.Rect2D { X = 58, Y = 113, W = 17, H = 13 }, "Stop");
			UI.Button b5 = new UI.Button(new UI.Rect2D { X = 76, Y = 113, W = 17, H = 13 }, "Next");

			UI.Button b6 = new UI.Button(new UI.Rect2D { X = 467, Y = 3, W = 7, H = 7 }, "Minimize");
			UI.Button b7 = new UI.Button(new UI.Rect2D { X = 477, Y = 3, W = 7, H = 7 }, "Close");


			UI.Slider s1 = new UI.Slider(new UI.Rect2D { X = 4, Y = 102, W = 192, H = 7 }, "Slider1", UI.Slider.SliderOrientation.Horizontal);
			UI.Slider s2 = new UI.Slider(new UI.Rect2D { X = 102, Y = 116, W = 94, H = 7 }, "Slider2", UI.Slider.SliderOrientation.Horizontal);

			//UI.Slider s3 = new UI.Slider(new UI.Rect2D { X = 220, Y = 10, W = 7, H = 110 }, "Slider3", UI.Slider.SliderOrientation.Vertical);

			UI.PlayListMenu<PlaylistItemModel> pm = new UI.PlayListMenu<PlaylistItemModel>(new UI.Rect2D { X = 198, Y = 4, W = 278, H = 108 }, playlist, playlistSetings);

			//s3.Value = 0.3f;

			p.AddChild(p2);

			p.AddChild(b6);
			p.AddChild(b7);


			p2.AddChild(pm);
			p2.AddChild(b1);
			p2.AddChild(b2);
			p2.AddChild(b3);
			p2.AddChild(b4);
			p2.AddChild(b5);

			p2.AddChild(s1);
			p2.AddChild(s2);

			//p2.AddChild(s3);


			b1.Click += BtnClickHandler;
			b2.Click += BtnClickHandler;
			b3.Click += BtnClickHandler;
			b4.Click += BtnClickHandler;
			b5.Click += BtnClickHandler;

			b6.Click += BtnClickHandler;
			b7.Click += BtnCloseHandler;


			s1.Change += SliderChangeHandler;
			s2.Change += SliderChangeHandler;
			//s3.Change += SliderChangeHandler;


			this.Paint += new PaintEventHandler(Main_Paint);


			//var xml = System.IO.File.ReadAllText("settings.xml");
			//var sss = Utils.XmlUtility.DeserializeFromXmlString<Settings>(xml);

			s1.Value = 0.8f;

			//int a = 5;

		  
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
		}


		private void BtnClickHandler(object sender, EventArgs e)
		{
			this.btnClicked = ((UI.Button)sender).Name;
		}

		private void SliderChangeHandler(object sender, EventArgs e)
		{
			this.sliderResult = ((UI.Slider)sender).Value.ToString();
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

			e.Graphics.DrawString(btnClicked, new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 20, FontStyle.Bold), new SolidBrush(Color.FromArgb(240, 240, 240)), 30, 40);
			e.Graphics.DrawString(sliderResult, new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 20, FontStyle.Bold), new SolidBrush(Color.FromArgb(240, 240, 240)), 30, 20);

			//int a = 0;
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
