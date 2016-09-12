using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPlay
{
	public partial class VideoForm : CustomForm
	{
		//public Vlc.DotNet.Core.VlcMediaPlayer player;
		public event EventHandler VideoClosed;

		public VideoForm()
		{
			InitializeComponent();

			//player = new Vlc.DotNet.Core.VlcMediaPlayer(new DirectoryInfo(@"D:\LibVlc"));
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//player.SetMedia(new FileInfo("J:\\Video\\Klipai\\LITTLE BIG - HATEFUL LOVE.mp4"));

			//player.VideoHostControlHandle = this.panel1.Handle;

			//player.PositionChanged += Player_PositionChanged;
			

			//v.Video.Tracks.Current.
			//player.Play();

			//volumeSlider.Value = player.Audio.Volume / 100;
		}

		private void Player_PositionChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs e)
		{
			//slider1.Value = player.Position;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			//if (player.IsPlaying())
			//	player.Pause();
			//else
			//	player.Play();
		}

		private void slider1_ValueChanged(object sender, EventArgs e)
		{
			//player.Position = slider1.Value;
		}

		private void panel1_DoubleClick(object sender, EventArgs e)
		{
			//if (player.IsPlaying())
			//	player.Pause();
			//else
			//	player.Play();
		}

		private void volumeSlider_ValueChanged(object sender, EventArgs e)
		{
			//player.Audio.Volume = (int)(volumeSlider.Value * 100);
		}

		public IntPtr GetVideoPanelHandle()
		{
			return this.panel1.Handle;
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			VideoClosed?.Invoke(this, e);
		}
	}
}
