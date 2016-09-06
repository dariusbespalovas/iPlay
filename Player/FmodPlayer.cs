using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nFMOD;

namespace iPlay.Player
{
	public class FmodPlayer : iPlayer
	{
		private FmodSystem _fmod = null;
		private Sound _sound = null;
		private Channel _channel = null;

		public FmodPlayer()
		{
			_fmod = new FmodSystem();
		}

		public void Play(string Path)
		{
			_fmod.CreateStream("path", SoundMode.AccurateTime);

			//_sound = new Sound();

			//_channel = new Channel();


			throw new NotImplementedException();
		}
	}
}
