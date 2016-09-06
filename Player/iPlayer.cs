using System;
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


// MarshalANSI1.cpp
// compile with: /clr
//#pragma once
//# include <string>
//# include <windows.h>
//# include <sstream>
//# include <iostream>
//# include "fmod.h"
//# include "fmod.hpp"
//# include "fmod_dsp.h"
//# include "fmod_errors.h"

//#pragma comment (lib, "fmod_vc.lib")

//using namespace std;

//class MediaPlayControler
//{
//	private:
//	FMOD::System* system;
//	FMOD::Sound* sound;
//	FMOD::Channel* channel;
//	FMOD::ChannelGroup* channelGroup;
//	FMOD::DSP* dsp;

//	FMOD_DSP_PARAMETER_FFT* fft;
//	const char* ChannelGroupName;

//	bool is_ok;     // leidimas / draudimas kai kurioms funkcijoms vygdyti
//					// true reiksme buna kai yra uzkrautas takelis
//					// false jeigu takelis netinkamas arba jis yra keiciamas kitu takeliu.
//					// false atveju funkcijos kurios valdo takelio grojima ar gauna jo informacija nieko nepriima ir nieko negrazina
//					// tam kad nebutu crashu

//	float volume;   // cia savaime suprantama saugoma garso lygis. 
//	float position;
//	bool paused;    // ar uzdeta pauze?
//	bool isRepeatEnabled;

//	wstring filePath;

//	bool isUpToDate;

//	public:
//	// konstruktorius
//	MediaPlayControler()
//	{
//		FMOD::System_Create(&system);
//		system->init(1, FMOD_INIT_NORMAL, 0);

//		ChannelGroupName = "cGroup1";

//		system->createChannelGroup(ChannelGroupName, &channelGroup);
//		system->createDSPByType(FMOD_DSP_TYPE_FFT, &dsp);

//		dsp->setParameterInt(FMOD_DSP_FFT_WINDOWTYPE, FMOD_DSP_FFT_WINDOW_TRIANGLE);


//		// defaultai
//		volume = 1.0;
//		position = 0.0;
//		paused = false;
//		is_ok = false;
//		isRepeatEnabled = false;

//		isUpToDate = false;
//	}

//	// destruktorius
//	~MediaPlayControler()
//	{
//		if (channel != NULL) channel->stop();
//		if (channelGroup != NULL) channelGroup->release();
//		if (sound != NULL) sound->release();
//		if (dsp != NULL) dsp->release();
//		if (system != NULL) system->release();
//	}

//	// uzkrauna faila ir is karto paleidzia ji groti
//	// fileName - pilnas arba dalinis (nuo vygdomojo failo) kelias iki audio failo
//	bool load(wstring fileName);

//	// paleidzia garso takelio atkurima
//	void play();

//	// sustabdo takelio atkurima
//	void pause();

//	// sustabdo garso takelio atkurima ir atsuka iki priekio
//	void stop();

//	void repeat();

//	// nustato nuo kurios vietos atkurt garso takeli
//	// p - pozicija nuo 0.0 iki 1.0 Reiksmes virsijancios ribas grazinamos iki ribiniu reiksmiu
//	void setProgres(float p);

//	// nustato garso takelio atkurimo garsa
//	// v - garsumo lygis nuo 0.0 iki 1.0 Reiksmes virsijancios ribas grazinamos iki ribiniu reiksmiu
//	void setVolume(float v);

//	// NEREALIZUOTA FUNKCIJA
//	string getTime();

//	// gauna nustatytaji garso lygi
//	// @return - float nuo 0.0 iki 1.0
//	float getVolume();

//	// gauna takelio prograso lygi
//	// @return - float nuo 0.0 iki 1.0
//	float getProgres();

//	// gauna ar takelis sustabdytas
//	// @return - true/false
//	bool getPaused();

//	// gauna takelio ilgi
//	// @return - takelio ilgis milisekundemis
//	unsigned int getLength();

//	// gauna grojamos takelio vietos laika
//	// @return - takelio vieta milisekundemis
//	unsigned int getPos();

//	// gauna dainos pavadinima jei nuskaito arba grazina failo varda
//	// @return - takelio pavadinimas
//	wstring getName();

//	// grazina ar failas grojamas ir apskritai ar ji imanoma renderinti (tinka atrinkt geriem failam bei nustatyt takelio pabaigai)
//	// @return - true/false 
//	bool isPlaying();

//	bool getRepeatEnabled();

//	bool isUpdated();

//	void getSpectrum(float* fl, int num);


//	wstring GetTag(const char* tagname);
//	wstring GetTag(FMOD::Sound* sound, const char* tagname);
//};


//# include "../h/MediaPlayControler.h"

//// uzkrauna ir paleidzia grot daina
//bool MediaPlayControler::load(wstring fileName)
//{
//	if (is_ok)
//	{// sunaikint viska
//		is_ok = false;  // uzblokuoja kitu funkciju vygdyma

//		if (channel != NULL) channel->stop();  // jeigu takelis groja ji stabdo
//		if (sound != NULL) sound->release(); // jeigu takelis uzkrautas ji sunaikina
//	}
//	//system->createSound(fileName.c_str(), FMOD_DEFAULT, 0, &sound); 
//	filePath = fileName;
//	// Wstring to string
//	string s(fileName.begin(), fileName.end());
//	s.assign(fileName.begin(), fileName.end());


//	system->createStream(s.c_str(), /*FMOD_HARDWARE |*/ FMOD_LOOP_BIDI | FMOD_2D | FMOD_ACCURATETIME, 0, &sound);
//	system->playSound(sound, channelGroup, false, &channel);

//	channel->addDSP(FMOD_CHANNELCONTROL_DSP_TAIL, dsp);
//	channel->setVolume(this->volume); // nustato defaultine garso reiksme (nes kas kart uzkraunant takeli nustato 100%)

//	is_ok = true; // leidzia vykti kitoms funkcijoms
//	isUpToDate = false;
//	return isPlaying();
//}

//// paleidzia takeli groti
//void MediaPlayControler::play()
//{
//	if (is_ok)
//	{
//		channel->setPaused(false);
//		this->paused = false;
//	}
//}

//// sustabdo grojima
//void MediaPlayControler::pause()
//{
//	if (is_ok)
//	{
//		channel->setPaused(true);
//		this->paused = true;
//	}
//}

//// sustabdo grojima is nustato progresa i 0
//void MediaPlayControler::stop()
//{
//	if (is_ok)
//	{
//		pause();
//		channel->setPosition(0, FMOD_TIMEUNIT_MS);
//	}
//}

//void MediaPlayControler::repeat()
//{
//	this->isRepeatEnabled = !this->isRepeatEnabled;
//}

//// nustato norima progresa
//void MediaPlayControler::setProgres(float p)
//{
//	if (is_ok && (p >= 0.0 && p <= 1.0))
//	{
//		unsigned int length = 0;
//		sound->getLength(&length, FMOD_TIMEUNIT_MS);

//		channel->setPosition((unsigned int)(length * p), FMOD_TIMEUNIT_MS);
//		play();
//	}
//}

//// nustato garsa
//void MediaPlayControler::setVolume(float v)
//{
//	if (v < 0.0) v = 0;
//	if (v > 1.0) v = 1;

//	this->volume = v;

//	if (is_ok)
//	{
//		channel->setVolume(this->volume);
//	}
//}

//// gauna esama garso reiksme
//float MediaPlayControler::getVolume()
//{
//	return this->volume;
//}

//// gauna esama takelio progresa float nuo 0 iki 1
//float MediaPlayControler::getProgres()
//{
//	return (float)getPos() / getLength();
//}

//// ar uzdeta pauze
//bool MediaPlayControler::getPaused()
//{
//	return this->paused;
//}

//// gauna takelio ilgi milisekundemis
//unsigned int MediaPlayControler::getLength()
//{
//	unsigned int length = 0;
//	sound->getLength(&length, FMOD_TIMEUNIT_MS);
//	return length;
//}

//// gauna takelio progresa milisekundemis
//unsigned int MediaPlayControler::getPos()
//{
//	unsigned int pos = 0;
//	channel->getPosition(&pos, FMOD_TIMEUNIT_MS);
//	return pos;
//}

//// grazina true jeigu takelis grojamas. false jeigu grojimas baigesi arba failas netinkamas
//bool MediaPlayControler::isPlaying()
//{
//	bool is;
//	channel->isPlaying(&is);
//	return is;
//}

//bool MediaPlayControler::getRepeatEnabled()
//{
//	return this->isRepeatEnabled;
//}

//// pagrazina takelio pavadinima. Jei tokio neranda tai tada failo pavadinima
//wstring MediaPlayControler::getName()
//{
//	//char *name = new char[255];
//	//wstring fullName = L"";
//	wstring fullName(MAX_PATH, L'\0');
//	fullName = L"";

//	if (is_ok && isPlaying())
//	{

//		wstring artist = GetTag(sound, "ARTIST");
//		wstring title = GetTag(sound, "TITLE");


//		bool none = true;
//		if (artist.length() > 0)
//		{
//			none = false;
//			for (int i = 0; i < artist.length() - 1; i++)
//			{
//				fullName += artist[i];
//			}
//			fullName += L" - ";
//		}
//		if (title.length() > 0)
//		{
//			none = false;
//			for (int i = 0; i < title.length() - 1; i++)
//			{
//				fullName += title[i];
//			}
//		}

//		if (none)
//		{
//			char* name = new char[255];
//			sound->getName(name, 255);
//			for (int i = 0; i < 255; i++)
//			{
//				fullName += name[i];
//				if (name[i] == '\0') break;
//			}
//			delete[] name;
//		}






//		if (fullName[0] == L'\0')
//		{


//			//int lastSlash = 0;
//			//int lastPoint = filePath.length();
//			//for(int i = 0; i < lastPoint; i ++)
//			//{
//			//	if(filePath[i] == L'\\')
//			//	{
//			//		lastSlash = i;
//			//	}
//			//	if(filePath[i] == L'\0') break;
//			//}
//			//	

//			//for(int i = lastSlash; i < lastPoint; i ++)
//			//{
//			//		
//			//	if(filePath[i] == L'.')
//			//	{
//			//		lastPoint = i; //break;
//			//	}
//			//	if(filePath[i] == L'\0') break;
//			//}



//			int lastSlash = filePath.find_last_of(L'\\');
//			int lastPoint = filePath.find_last_of('.');

//			fullName = L"";

//			for (int i = lastSlash + 1; i < lastPoint; i++)
//			{
//				fullName += filePath[i];
//				//fullName += L"lol";
//				//fullName += L'a';
//			}

//		}

//	}


//	return fullName;
//}

//void MediaPlayControler::getSpectrum(float* fl, int num)
//{
//	for (int i = 0; i < num; i++)
//	{
//		fl[i] = 0.0;
//	}

//	if (is_ok)
//	{
//		dsp->setParameterInt(FMOD_DSP_FFT_WINDOWSIZE, num);
//		dsp->getParameterData(FMOD_DSP_FFT_SPECTRUMDATA, (void**)&fft, nullptr, nullptr, 0);

//		if (fft->length != 0 && fft->numchannels != 0 && num == fft->length / fft->numchannels)
//		{
//			for (int channel = 0; channel < fft->numchannels; channel++)
//			{
//				for (int bin = 0; bin < fft->length / fft->numchannels; bin++)
//				{
//					fl[bin] += fft->spectrum[channel][bin];
//				}
//			}
//		}

//		for (int i = 0; i < num; i++)
//		{
//			fl[i] = fl[i] / 2;
//		}
//	}
//}


//bool MediaPlayControler::isUpdated()
//{
//	bool r = isUpToDate;
//	isUpToDate = true;
//	return r;
//}



//wstring MediaPlayControler::GetTag(const char* tagname)
//{
//	return GetTag(sound, tagname);
//}

//wstring MediaPlayControler::GetTag(FMOD::Sound* sound, const char* tagname)
//{
//	FMOD_TAG tag;
//	sound->getTag(tagname, 0, &tag);
//	/*if(CheckError(result, 0))
//		return Null;*/

//	switch (tag.datatype)
//	{
//		case FMOD_TAGDATATYPE_INT:
//			//return wstring(AsString(*((int *) tag.data)));
//			OutputDebugStringA("INT\n"); break;
//		case FMOD_TAGDATATYPE_FLOAT:
//			//return wstring(AsString(*((float *) tag.data)));
//			OutputDebugStringA("FLOAT\n"); break;
//		case FMOD_TAGDATATYPE_STRING:
//			//return ToUnicode((const char *) tag.data, CHARSET_WIN1250);// + atoi(GetUserLocale(LOCALE_IDEFAULTANSICODEPAGE)) - 1250);
//			//OutputDebugStringA("STRING\n"); break;
//			break;
//		case FMOD_TAGDATATYPE_STRING_UTF16:
//		case FMOD_TAGDATATYPE_STRING_UTF16BE:
//		case FMOD_TAGDATATYPE_STRING_UTF8:
//			OutputDebugStringA("WSTRING\n"); break;
//			//return FromUnicode(WString((const wchar *) tag.data));
//			//return wstring((const wchar *) tag.data);

//			//tag.data;
//	}

//	//*((wstring *) tag.data);



//	//wstring ((const wchar *)tag.data);

//	//PtrToStringChars(tag.data);
//	//wstring *ws;// = new wstring[255];

//	//ws = reinterpret_cast<wstring*>(tag.data);
//	//ws = (string*) tag.data;

//	//OutputDebugStringA("t\n");
//	if (tag.datatype == FMOD_TAGDATATYPE_STRING)
//	{
//		void* p = tag.data;

//		string b = "";

//		//int counter = 0;
//		/*for(int i = 0; i < tag.datalen; i ++)
//		{
//			if(o[i] != '\0')
//			b += &o[i];
//		}*/

//		string str;
//		/*stringstream ss;
//		ss << &o[0];
//		ss >> bb;*/

//		//bb = bb + "\n";
//		//char b[] = "sdfsf";
//		//string r = &o[tag.datalen-1];
//		//bb = &o[0];

//		str = &static_cast<char*>(p)[0];
//		str += "\n";

//		//OutputDebugStringA(str.c_str());


//		std::wstring str2(str.length(), L'\0'); // Make room for characters

//		// Copy string to wstring.
//		std::copy(str.begin(), str.end(), str2.begin());
//		//delete p;
//		return str2;
//	}
//	return L"";
//	//return *((wstring *) tag.data);
//}
