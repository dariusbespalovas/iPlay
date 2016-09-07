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
		private List<PlaylistItemModel> playlist = null;



		UI.Container p2;

		UI.Button buttonPrev;
		UI.Button buttonPlay;
		UI.Button buttonPause;
		UI.Button buttonStop;
		UI.Button buttonNext;

		UI.Button buttonMinimize;
		UI.Button buttonClose;

		UI.Slider sliderProgress = null;
		UI.Slider sliderVolume = null;


		public Main()
		{
			InitializeComponent();


			playlist = new List<PlaylistItemModel>();


			try
			{
				playlist = Utils.XmlUtility.DeserializeFromXmlString<List<PlaylistItemModel>>(System.IO.File.ReadAllText("playlist.xml"));
			}
			catch(Exception e)
			{
			}


			//System.IO.File.WriteAllText("playlist.xml", Utils.XmlUtility.SerializeToXmlString(playlist));
			//for(int i = 0; i < 500; i++)
			//{
			//	playlist.Add(new PlaylistItemModel
			//	{
			//		Name = "Name" + i.ToString(),
			//		Path = "Path" + i.ToString(),
			//		Duration = 0,
			//		DurationString = "00:00:00"
			//	});
			//}


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
					FieldName = "DurationFormated",
					Width = 55,
					Alignment = StringAlignment.Far
				}

			};

			this.uiContainer = new UI.Container(new UI.Rect2D { X = 0, Y = 0, W = this.Width, H = this.Height });

			p2 = new UI.Container(new UI.Rect2D { X = 4, Y = 12, W = 480, H = 129 });

			buttonPrev = new UI.Button(new UI.Rect2D { X = 4,	Y = 113, W = 17, H = 13 },	"<<");
			buttonPlay = new UI.Button(new UI.Rect2D { X = 22, Y = 113, W = 17, H = 13 }, "|>");
			buttonPause = new UI.Button(new UI.Rect2D { X = 40, Y = 113, W = 17, H = 13 }, "||");
			buttonStop = new UI.Button(new UI.Rect2D { X = 58, Y = 113, W = 17, H = 13 }, "O");
			buttonNext = new UI.Button(new UI.Rect2D { X = 76, Y = 113, W = 17, H = 13 }, ">>");

			buttonMinimize = new UI.Button(new UI.Rect2D { X = 467, Y = 2, W = 9, H = 9 }, "Minimize");
			buttonClose = new UI.Button(new UI.Rect2D { X = 477, Y = 2, W = 9, H = 9 }, "Close");


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
			buttonPlay.Click += BtnPlayClickHandler;
			buttonPause.Click += BtnPauseClickHandler;
			buttonStop.Click += BtnStopClickHandler;
			buttonNext.Click += BtnClickHandler;

			buttonMinimize.Click += BtnMinimizeHandler;
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

		}


		private void BtnCloseHandler(object sender, EventArgs e)
		{
			var a = this.Top;
			var b = this.Left;

			Settings.Instance.WindowX = this.Left;
			Settings.Instance.WindowY = this.Top;

			string s = Utils.XmlUtility.SerializeToXmlString(Settings.Instance);


			System.IO.File.WriteAllText("settings.xml", s);

			System.IO.File.WriteAllText("playlist.xml", Utils.XmlUtility.SerializeToXmlString(playlist));


			Application.Exit();
		}

		private void BtnMinimizeHandler(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}


		private void BtnPlayClickHandler(object sender, EventArgs e)
		{
			player.Play();
		}

		private void BtnPauseClickHandler(object sender, EventArgs e)
		{
			player.Pause();
		}

		private void BtnStopClickHandler(object sender, EventArgs e)
		{
			player.Stop();
		}

		private void BtnRepeatClickHandler(object sender, EventArgs e)
		{
			player.Repeat();
		}










		private void BtnClickHandler(object sender, EventArgs e)
		{
			//this.btnClicked = ((UI.Button)sender).Name;
		}


		private void VolumeChangeHandler(object sender, EventArgs e)
		{
			this.player.SetVolume(((UI.Slider)sender).Value);
		}

		private void ProgressChangeHandler(object sender, EventArgs e)
		{
			this.player.SetProgress(((UI.Slider)sender).Value);
		}



		private void PlaylistSelectHandler(object sender, EventArgs e)
		{
			UI.PlayListMenu<PlaylistItemModel> pm = (UI.PlayListMenu<PlaylistItemModel>)sender;

			player.LoadTrack(pm.GetSelection().Path);

			pm.GetSelection().Duration = (player.GetLength() > 359999) ? 0 : player.GetLength();

			pm.GetSelection().Name = player.GetName();
		}




		private void Main_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			sliderProgress.Value = player.GetProgress();
			sliderVolume.Value = player.GetVolume();

			this.Refresh();
		}

		private void Main_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			foreach (string file in files)
			{
				playlist.Add(new PlaylistItemModel
				{
					Name = file,
					Path = file,
					Duration = 0,
				});
			}
		}

		private void Main_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}
	}
}
