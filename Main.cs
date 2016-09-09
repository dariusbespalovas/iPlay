﻿using iPlay.Player;
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

		UI.Slider sliderProgress = null;
		UI.Slider sliderVolume = null;

		public Main() : base(488, 145)
		{
			InitializeComponent();

			playlist = new List<PlaylistItemModel>();

			Settings.Instance.PlayerSettings = Utils.XmlUtility.DeserializeFromXmlString<PlayerSettings>(System.IO.File.ReadAllText("settings.xml"));

			try
			{
				playlist = Utils.XmlUtility.DeserializeFromXmlString<List<PlaylistItemModel>>(System.IO.File.ReadAllText(Settings.Instance.PlayerSettings.PlaylistFilePath));
			}
			catch(Exception e)
			{
			}

			this.StartPosition = FormStartPosition.Manual;
			this.Location = new Point(Settings.Instance.PlayerSettings.MainWindow.WindowX, Settings.Instance.PlayerSettings.MainWindow.WindowY);

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

			buttonPrev = new UI.Button(new UI.Rect2D { X = 4,	Y = 113, W = 17, H = 13 },	"<<");
			buttonPlay = new UI.Button(new UI.Rect2D { X = 22, Y = 113, W = 17, H = 13 }, "|>");
			buttonPause = new UI.Button(new UI.Rect2D { X = 40, Y = 113, W = 17, H = 13 }, "||");
			buttonStop = new UI.Button(new UI.Rect2D { X = 58, Y = 113, W = 17, H = 13 }, "O");
			buttonNext = new UI.Button(new UI.Rect2D { X = 76, Y = 113, W = 17, H = 13 }, ">>");

			sliderProgress = new UI.Slider(new UI.Rect2D { X = 4, Y = 102, W = 192, H = 7 }, "Slider1", UI.Slider.SliderOrientation.Horizontal);
			sliderVolume = new UI.Slider(new UI.Rect2D { X = 102, Y = 116, W = 94, H = 7 }, "Slider2", UI.Slider.SliderOrientation.Horizontal);

			UI.PlayListMenu<PlaylistItemModel> pm = new UI.PlayListMenu<PlaylistItemModel>(new UI.Rect2D { X = 198, Y = 4, W = 278, H = 108 }, playlist, playlistSetings);

			uiContainer.AddChild(pm)
				.AddChild(buttonPrev)
				.AddChild(buttonPlay)
				.AddChild(buttonPause)
				.AddChild(buttonStop)
				.AddChild(buttonNext)
				.AddChild(sliderProgress)
				.AddChild(sliderVolume);

			buttonPrev.Click += BtnClickHandler;
			buttonPlay.Click += BtnPlayClickHandler;
			buttonPause.Click += BtnPauseClickHandler;
			buttonStop.Click += BtnStopClickHandler;
			buttonNext.Click += BtnClickHandler;

			buttonMinimize.Click += BtnMinimizeHandler;
			buttonClose.Click += BtnCloseHandler;

			sliderVolume.Change += VolumeChangeHandler;
			sliderProgress.Change += ProgressChangeHandler;

			pm.SelectionChanged += PlaylistSelectHandler;
			pm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;

			this.Paint += new PaintEventHandler(Main_Paint);

			sliderProgress.Value = 0.8f;
		}

		private void BtnCloseHandler(object sender, EventArgs e)
		{
			Settings.Instance.PlayerSettings.MainWindow.WindowX = this.Left;
			Settings.Instance.PlayerSettings.MainWindow.WindowY = this.Top;

			System.IO.File.WriteAllText("settings.xml", Utils.XmlUtility.SerializeToXmlString(Settings.Instance.PlayerSettings));
			System.IO.File.WriteAllText(Settings.Instance.PlayerSettings.PlaylistFilePath, Utils.XmlUtility.SerializeToXmlString(playlist));

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
