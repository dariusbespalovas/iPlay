using iPlay.Player;
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
	public partial class Main : CustomForm
	{
		private List<PlaylistItemModel> playlist = null;

		private VideoForm videoForm = null;

		private iPlayer player;
		private iPlayer fmodPlayer = new FmodPlayer();
		private iPlayer vlcPlayer = new VlcPlayer();

		public Main()
		{
			InitializeComponent();

			playlist = new List<PlaylistItemModel>();

			Settings.Instance.PlayerSettings = Utils.XmlUtility.DeserializeFromXmlString<PlayerSettings>(System.IO.File.ReadAllText("settings.xml"));

			try
			{
				playlist = Utils.XmlUtility.DeserializeFromXmlString<List<PlaylistItemModel>>(System.IO.File.ReadAllText(Settings.Instance.PlayerSettings.PlaylistFilePath));
			}
			catch (Exception e)
			{
			}

			this.StartPosition = FormStartPosition.Manual;
			this.Location = new Point(Settings.Instance.PlayerSettings.MainWindow.WindowX, Settings.Instance.PlayerSettings.MainWindow.WindowY);

			List<UI.Table.TableSetingsModel> playlistSetings = new List<UI.Table.TableSetingsModel>
			{
				new UI.Table.TableSetingsModel()
				{
					FieldName = "Name",
					Width = 218,
					Alignment = StringAlignment.Near
				},

				new UI.Table.TableSetingsModel()
				{
					FieldName = "DurationFormated",
					Width = 55,
					Alignment = StringAlignment.Far
				}
			};

			scrollableTable1.table.SetData(playlist.Cast<object>().ToList());
			scrollableTable1.table.SetSettings(playlistSetings);

			scrollableTable1.AllowDrop = true;
			scrollableTable1.DragDrop += ScrollableTable1_DragDrop;
			scrollableTable1.DragEnter += ScrollableTable1_DragEnter;
			scrollableTable1.table.SelectionChanged += Table_SelectionChanged;

			volumeSlider.ValueChanged += VolumeSlider_ValueChanged;
			positionSlider.ValueChanged += PositionSlider_ValueChanged;
		}

		private void PositionSlider_ValueChanged(object sender, EventArgs e)
		{
			player.SetProgress(((UI.Slider)sender).Value);
		}

		private void VolumeSlider_ValueChanged(object sender, EventArgs e)
		{
			player.SetVolume(((UI.Slider)sender).Value);
		}

		private void Table_SelectionChanged(object sender, EventArgs e)
		{
			PlaylistItemModel playlistItemModel = (PlaylistItemModel)(((UI.Table)sender).GetSelection());

			if (player != null)
			{
				player.Stop();
			}

			if(playlistItemModel.Path.EndsWith(".mp3"))
			{
				player = this.fmodPlayer;
			}
			else
			{
				player = this.vlcPlayer;
				ShowVideoForm();
			}


			player.LoadTrack(playlistItemModel.Path);
			player.SetVolume(volumeSlider.Value);
			player.Play();

			//pm.GetSelection().Duration = (player.GetLength() > 359999) ? 0 : player.GetLength();

			//pm.GetSelection().Name = player.GetName();
		}

		private void ScrollableTable1_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}

		private void ScrollableTable1_DragDrop(object sender, DragEventArgs e)
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

			scrollableTable1.table.SetData(playlist.Cast<object>().ToList());

			scrollableTable1.Refresh();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			new VideoForm().Show();
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			Settings.Instance.PlayerSettings.MainWindow.WindowX = this.Left;
			Settings.Instance.PlayerSettings.MainWindow.WindowY = this.Top;

			System.IO.File.WriteAllText("settings.xml", Utils.XmlUtility.SerializeToXmlString(Settings.Instance.PlayerSettings));
			System.IO.File.WriteAllText(Settings.Instance.PlayerSettings.PlaylistFilePath, Utils.XmlUtility.SerializeToXmlString(playlist));

			Application.Exit();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (player != null && player.IsPlaying())
			{
				positionSlider.Value = player.GetProgress();
				volumeSlider.Value = player.GetVolume();
			}
		}

		private void ShowVideoForm()
		{
			if((videoForm == null || videoForm.IsDisposed))
			{
				videoForm = new VideoForm();
				videoForm.FormClosing += VideoForm_VideoClosed;
			}


			videoForm.Show();

			((VlcPlayer)player).SetVideoOutHandle(videoForm.GetVideoPanelHandle());

			
		}

		private void VideoForm_VideoClosed(object sender, EventArgs e)
		{
			((VlcPlayer)player).SetVideoOutHandle(panelV.Handle);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			((VlcPlayer)player).SetVideoOutHandle(panelV.Handle);
		}
	}
}
