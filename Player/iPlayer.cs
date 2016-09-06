﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPlay.Player
{
	public interface iPlayer
	{
		void Play(string Path);
		
		void SetVolume(float Value);
		void SetProgress(float Value);

		float GetVolume();
		float GetProgress();
	}
}
