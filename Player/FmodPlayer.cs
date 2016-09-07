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

		private float Volume = 0f;
		private bool Paused = false;
		private bool RepeatEnabled = false;
		private bool IsUpToDate = true;
		private bool is_ok = true;
		private string Name = "";

		public FmodPlayer()
		{
			FMOD.Factory.System_Create(out _fmod);
			_fmod.init(32, INITFLAGS.NORMAL, (IntPtr)0);
		}

		public bool LoadTrack(string Path)
		{
			if (is_ok)
			{
				is_ok = false;

				if (_channel != null) _channel.stop();
				if (_sound != null) _sound.release();

				_fmod.createStream(Path, MODE.LOOP_BIDI | MODE._2D | MODE.ACCURATETIME, out this._sound);
				_fmod.playSound(_sound, null, false, out _channel);

				//channel->addDSP(FMOD_CHANNELCONTROL_DSP_TAIL, dsp);
				_channel.setVolume(this.Volume);

				this.Name = Path;
			}

			is_ok = true;

			return IsPlaying();
		}


		public void SetVolume(float Value)
		{
			this.Volume = Value;
			if (_channel != null) _channel.setVolume(Value);
		}


		public void SetProgress(float Value)
		{
			if (_channel == null || _sound == null) return;

			uint len = 0;
			_sound.getLength(out len, TIMEUNIT.MS);
			_channel.setPosition((uint)(len*Value), TIMEUNIT.MS);
		}


		public float GetVolume()
		{
			//float vol = 0;
			//if (_channel != null) { _channel.getVolume(out vol); return vol; }

			return this.Volume;
		}

		public float GetProgress()
		{
			if (_sound != null && _channel != null)
			{
				uint len = 0;
				uint pos = 0;

				_sound.getLength(out len, TIMEUNIT.MS);
				_channel.getPosition(out pos, TIMEUNIT.MS);

				if (pos == 0) return 0f;

				return (float)pos / len;
			}

			return 0f;
		}


		public string GetName()
		{
			string fullName = "N/A";

			if (is_ok && IsPlaying())
			{
				string artist = GetTag("ARTIST");
				string title = GetTag("TITLE");

				fullName = artist + (string.IsNullOrEmpty(artist) ? "" : " - ") + title;

				fullName = string.IsNullOrEmpty(fullName) ? this.Name : fullName;
			}

			return fullName;
		}

		public bool IsPlaying()
		{
			bool isPlay = false;

			if(_channel != null)
				_channel.isPlaying(out isPlay);

			return isPlay;
		}


		public int GetLength()
		{
			uint lenght = 0;

			if (_sound != null)
			{
				_sound.getLength(out lenght, TIMEUNIT.MS);
			}

			return (int)(lenght / 1000);
		}


		private string GetTag(string tagName)
		{
			string tagResult = "";

			FMOD.TAG tag;

			_sound.getTag(tagName, 0, out tag);

			//switch (tag.datatype)
			//{
			//	case FMOD.TAGDATATYPE.INT:
			//		//return wstring(AsString(*((int *) tag.data)));
			//		OutputDebugStringA("INT\n"); break;
			//	case FMOD.TAGDATATYPE.FLOAT:
			//		//return wstring(AsString(*((float *) tag.data)));
			//		OutputDebugStringA("FLOAT\n"); break;
			//	case FMOD.TAGDATATYPE.STRING:
			//		//return ToUnicode((const char *) tag.data, CHARSET_WIN1250);// + atoi(GetUserLocale(LOCALE_IDEFAULTANSICODEPAGE)) - 1250);
			//		//OutputDebugStringA("STRING\n"); break;
			//		break;
			//	case FMOD.TAGDATATYPE.STRING_UTF16:
			//	case FMOD.TAGDATATYPE.STRING_UTF16BE:
			//	case FMOD.TAGDATATYPE.STRING_UTF8:
			//		OutputDebugStringA("WSTRING\n"); break;
			//	//return FromUnicode(WString((const wchar *) tag.data));
			//	//return wstring((const wchar *) tag.data);

			//	//tag.data;
			//}











			if (tag.datatype == FMOD.TAGDATATYPE.STRING)
			{
				tagResult = System.Runtime.InteropServices.Marshal.PtrToStringAuto(tag.data);
			}











			return tagResult;
		}
	}
}
