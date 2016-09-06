using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMOD;

namespace iPlay.Player
{
	public class FmodPlayer : iPlayer
	{
		private FMOD.System _fmod = null;
		private FMOD.Sound _sound = null;
		private FMOD.Channel _channel = null;

		public FmodPlayer()
		{
			FMOD.Factory.System_Create(out _fmod);
			_fmod.init(32, INITFLAGS.NORMAL, (IntPtr)0);
		}

		public void Play(string Path)
		{
			var a = _fmod.createStream(Path, MODE.ACCURATETIME, out this._sound);

			var b = _fmod.playSound(_sound, null, false, out _channel);



			var c = _channel.setVolume(0.1f);

			//_sound = new Sound();

			//_channel = new Channel();


			//throw new NotImplementedException();
		}


		public void SetVolume(float Value)
		{
			if (_channel != null) _channel.setVolume(Value);
		}


		public void SetProgress(float Value)
		{
			uint len = 0;
			_sound.getLength(out len, TIMEUNIT.MS);

			_channel.setPosition((uint)(len*Value), TIMEUNIT.MS);
		}
	}
}
