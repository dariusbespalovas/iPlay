using iPlay.Player;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace iPlay
{
	public partial class Main : CustomForm
	{
		private iPlayer player = new FmodPlayer();

		UI.Slider sliderProgress = null;
		UI.Slider sliderVolume = null;

		

		private string btnClicked = "000";

		private string sliderResult = "010";

		public Main()
		{
			


			List<PlaylistItemModel> playlist = new List<PlaylistItemModel>();
			for(int i = 0; i < 500; i++)
			{
				playlist.Add(new PlaylistItemModel
				{
					Name = "Name" + i.ToString(),
					Path = "Path" + i.ToString(),
					Duration = 0,
					DurationString = "00:00:00"
				});
			}


			List<UI.PlayListMenu<PlaylistItemModel>.TableSetingsModel> playlistSetings = new List<UI.PlayListMenu<PlaylistItemModel>.TableSetingsModel>
			{
				new UI.PlayListMenu<PlaylistItemModel>.TableSetingsModel()
				{
					FieldName = "Name",
					Width = 215,
					Alignment = StringAlignment.Near
				},

				new UI.PlayListMenu<PlaylistItemModel>.TableSetingsModel()
				{
					FieldName = "DurationString",
					Width = 55,
					Alignment = StringAlignment.Far
				}

			};


			UI.Container p2 = new UI.Container(new UI.Rect2D { X = 4, Y = 12, W = 480, H = 129 });

			UI.Button buttonPrev = new UI.Button(new UI.Rect2D { X = 4,	Y = 113, W = 17, H = 13 },	"Prev");
			UI.Button buttonPlay = new UI.Button(new UI.Rect2D { X = 22, Y = 113, W = 17, H = 13 }, "Play");
			UI.Button buttonPause = new UI.Button(new UI.Rect2D { X = 40, Y = 113, W = 17, H = 13 }, "Pause");
			UI.Button buttonStop = new UI.Button(new UI.Rect2D { X = 58, Y = 113, W = 17, H = 13 }, "Stop");
			UI.Button buttonNext = new UI.Button(new UI.Rect2D { X = 76, Y = 113, W = 17, H = 13 }, "Next");

			UI.Button buttonMinimize = new UI.Button(new UI.Rect2D { X = 467, Y = 3, W = 7, H = 7 }, "Minimize");
			UI.Button buttonClose = new UI.Button(new UI.Rect2D { X = 477, Y = 3, W = 7, H = 7 }, "Close");


			sliderProgress = new UI.Slider(new UI.Rect2D { X = 4, Y = 102, W = 192, H = 7 }, "Slider1", UI.Slider.SliderOrientation.Horizontal);
			sliderVolume = new UI.Slider(new UI.Rect2D { X = 102, Y = 116, W = 94, H = 7 }, "Slider2", UI.Slider.SliderOrientation.Horizontal);


			UI.PlayListMenu<PlaylistItemModel> pm = new UI.PlayListMenu<PlaylistItemModel>(new UI.Rect2D { X = 198, Y = 4, W = 278, H = 108 }, playlist, playlistSetings);

			//s3.Value = 0.3f;

			uiContainer.AddChild(p2);

			uiContainer.AddChild(buttonMinimize);
			uiContainer.AddChild(buttonClose);


			p2.AddChild(pm);
			p2.AddChild(buttonPrev);
			p2.AddChild(buttonPlay);
			p2.AddChild(buttonPause);
			p2.AddChild(buttonStop);
			p2.AddChild(buttonNext);

			p2.AddChild(sliderProgress);
			p2.AddChild(sliderVolume);

			//p2.AddChild(s3);


			buttonPrev.Click += BtnClickHandler;
			buttonPlay.Click += BtnClickHandler;
			buttonPause.Click += BtnClickHandler;
			buttonStop.Click += BtnClickHandler;
			buttonNext.Click += BtnClickHandler;

			buttonMinimize.Click += BtnClickHandler;
			buttonClose.Click += BtnCloseHandler;


			sliderVolume.Change += VolumeChangeHandler;
			sliderProgress.Change += ProgressChangeHandler;
			//s3.Change += SliderChangeHandler;

			pm.SelectionChanged += PlaylistSelectHandler;

			this.Paint += new PaintEventHandler(Main_Paint);


			//var xml = System.IO.File.ReadAllText("settings.xml");
			//var sss = Utils.XmlUtility.DeserializeFromXmlString<Settings>(xml);

			sliderProgress.Value = 0.8f;

			//int a = 5;

			InitializeComponent();
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

		private void VolumeChangeHandler(object sender, EventArgs e)
		{
			this.sliderResult = ((UI.Slider)sender).Value.ToString();
			this.player.SetVolume(((UI.Slider)sender).Value);
		}

		private void ProgressChangeHandler(object sender, EventArgs e)
		{
			this.sliderResult = ((UI.Slider)sender).Value.ToString();
			this.player.SetProgress(((UI.Slider)sender).Value);
		}


		private void PanelClickHandler(object sender, EventArgs e)
		{
			//this.btnClicked = ((UI.Button)sender).Name;
			//System.Windows.Forms.MessageBox.Show("panel click");

			this.btnClicked = "C";
		}

		private void PlaylistSelectHandler(object sender, EventArgs e)
		{

			player.Play("D:\\test.mp3");
		}




		private void Main_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			e.Graphics.DrawString(btnClicked, new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 20, FontStyle.Bold), new SolidBrush(Color.FromArgb(240, 240, 240)), 30, 40);
			e.Graphics.DrawString(sliderResult, new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 20, FontStyle.Bold), new SolidBrush(Color.FromArgb(240, 240, 240)), 30, 20);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			sliderProgress.Value = player.GetProgress();
			sliderVolume.Value = player.GetVolume();

			this.Refresh();
		}






		
	}
}
