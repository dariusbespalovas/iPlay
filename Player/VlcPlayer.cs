using System;
using System.Linq;

namespace iPlay.Player
{
	public class VlcPlayer : iPlayer
	{
		public Vlc.DotNet.Core.VlcMediaPlayer player;
		private string Name = "";
		public bool RepeatEnabled;

		public VlcPlayer()
		{
			player = new Vlc.DotNet.Core.VlcMediaPlayer(new System.IO.DirectoryInfo(@"D:\LibVlc"));
		}

		public int GetLength()
		{
			return (int)player.Length;
		}

		public string GetName()
		{
			return this.Name;
		}

		public float GetProgress()
		{
			return player.Position;
		}

		public float GetVolume()
		{
			return player.Audio.Volume / 100.0f;
		}

		public bool IsPlaying()
		{
			return 	player.IsPlaying();
		}

		public bool LoadTrack(string Path)
		{
			this.Name = Path.Split(new char[1] { '\\' }).Reverse().ToArray()[0];
			player.SetMedia(new System.IO.FileInfo(Path));
			return true;
		}

		public void Pause()
		{
			player.Pause();
		}

		public void Play()
		{
			player.Play();
		}

		public void Repeat()
		{
			this.RepeatEnabled = !this.RepeatEnabled;
		}

		public void SetProgress(float Value)
		{
			player.Position = Value;
		}

		public void SetVolume(float Value)
		{
			player.Audio.Volume = (int)(Value * 100);
		}

		public void Stop()
		{
			player.Stop();
		}

		public void SetVideoOutHandle(IntPtr handle)
		{
			player.VideoHostControlHandle = IntPtr.Zero;
			player.VideoHostControlHandle = handle;
		}

	}
}
