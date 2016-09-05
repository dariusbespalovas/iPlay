using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPlay.UI
{
	public class PlayListMenu<T> : UIElement
	{
		private Slider Scrollbar;

		private int SelectedRow;
		private int top;
		private int MarkedRow;
		private bool autoScroll;
		private bool is_mouseDown;
		private int lastMouse1, lastMouse2;
		private bool redraw = true;

		private List<T> RowList;
		private List<TableSetingsModel> TableSettings;

		public class TableSetingsModel
		{
			public string FieldName { get; set; }
			public int Width { get; set; }
		}



		#region drawing stuff
		//private SolidBrush BackgroudBrush = new SolidBrush(Color.FromArgb(131, 31, 31));
		//private Pen BorderPen = new Pen(Color.Orange);

		private SolidBrush BackgroudBrush = new SolidBrush(Color.FromArgb(31, 31, 31));
		private Pen BorderPen = new Pen(Color.FromArgb(31, 31, 31));
		#endregion

		//private bool UpdateLocations

		public PlayListMenu(Rect2D Rect, List<T> list, List<TableSetingsModel> TableSettings) : base(Rect)
		{
			this.RowList = list;
			this.TableSettings = TableSettings;

			Scrollbar = new UI.Slider(new UI.Rect2D { X = this.Rect.X, Y = this.Rect.Y, W = 7, H = this.Rect.H }, "Slider1", UI.Slider.SliderOrientation.Vertical);
			Scrollbar.Change += ScrollbarChange;


			this.Click += PlaylistClickedSingle;
			this.DoubleClick += PlaylistClickedDouble;
		}

		private void UpdateLocations()
		{
			Scrollbar.Rect.X = this.Rect.X + this.Rect.W - 7;
			Scrollbar.Rect.Y = this.Rect.Y;
		}


		private void ScrollbarChange(object sender, EventArgs e)
		{
			this.top = (int)(Scrollbar.Value * (RowList.Count-1));
			if (this.top < 0) this.top = 0;
		}

		private void PlaylistClickedSingle(object sender, EventArgs e)
		{
			HandleClickSelection(e, false);
		}

		private void PlaylistClickedDouble(object sender, EventArgs e)
		{
			HandleClickSelection(e, true);
		}


		private void HandleClickSelection(EventArgs e, bool IsDoubleClick)
		{
			if (((Events.MouseEvent)e).X >= Rect.X + 1 && ((Events.MouseEvent)e).X <= Rect.X + Rect.W - 13 &&
					((Events.MouseEvent)e).Y >= Rect.Y && ((Events.MouseEvent)e).Y <= Rect.Y + Rect.H)
			{
				for (int i = 0; i < (Rect.H - 4) / 13 && i + top < RowList.Count; i++)
				{
					if (((Events.MouseEvent)e).Y >= Rect.Y + 2 + (i * 13) && ((Events.MouseEvent)e).Y <= Rect.Y + 2 + (i * 13) + 12)
					{
						SelectedRow = top + i;
						if (IsDoubleClick)
							MarkedRow = SelectedRow;
					}
				}
			}
		}


		private void DrawRow(T t, int h)
		{
			int paintStart = 2;

			Font fnt = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 9, FontStyle.Regular);
			Brush brsh = new SolidBrush(Color.FromArgb(240, 240, 240));

			foreach (var v in TableSettings)
			{
				string txt = t.GetType().GetProperty(v.FieldName).GetValue(t, null).ToString();


				graphics.DrawString(txt, fnt, brsh, paintStart, h);

				paintStart += v.Width;

			}
		}

		public override void Draw(System.Windows.Forms.PaintEventArgs e)
		{
			UpdateLocations();

			graphics.FillRectangle(BackgroudBrush, 0, 0, Rect.W, Rect.H);
			graphics.DrawRectangle(BorderPen, 0, 0, Rect.W - 1, Rect.H - 1);








			//top = 2;
			//SelectedRow = 5;
			//MarkedRow = 7;





			if (redraw)
			{
				//Bitmap bmp(dimensions->width, dimensions->height);
				//Graphics *fromImg = Graphics::FromImage(&bmp);

				SolidBrush  brushNowPlaying = new SolidBrush(Color.FromArgb(60, 80, 100));
				//SolidBrush  brushFontColor(PLAYLIST_MENU_TEXT_COLOR);
				//SolidBrush  sbrushSliderBackground(PLAYLIST_MENU_SLIDER_BACKGROUND_COLOR);
				//SolidBrush  brushSlider(PLAYLIST_MENU_SLIDER_COLOR);
				//SolidBrush  brushBackground(PLAYLIST_MENU_BACKGROUND_COLOR);
				//Pen			penBorder(PLAYLIST_MENU_BORDER_COLOR);
				Pen penBorderSelected = new Pen(Color.FromArgb(120, 120, 120));
				//Pen			penLine(SLIDER_CENTER_LINE_COLOR);

				//FontFamily  fontFamily(L"Ventouse");

							

				//song
				for(int i = 0; i < (Rect.H-4)/13 && i+top < RowList.Count; i++)
				{

					//MusicFileData d;						
					//d = playlist->getSong(i+top);

					if(i + top == MarkedRow) { graphics.FillRectangle(brushNowPlaying, 2, 2 +(i*13), Rect.W - Scrollbar.Rect.W - 3, 12); /*lastPlayed = playlist->getCurrentSongId();*/ }
					if(i + top == SelectedRow) graphics.DrawRectangle(penBorderSelected, 2, 2 + (i * 13), Rect.W - Scrollbar.Rect.W - 4, 11);




					//if(d.length >= 36000) d.length = 0;

					//WCHAR *txt1 = new WCHAR[20];
					//_stprintf(txt1, _T("%d:%02d:%02d"), d.length / 60 / 60, d.length / 60 % 60, d.length % 60);
					//fromImg->DrawString(txt1, -1, font, RectF(2 + 220, (i*13), 50, 13), NULL ,&brushFontColor);
					//delete[] txt1;


					//WCHAR *txt = new WCHAR[260];
					//_stprintf(txt, _T("%d. %s"), top+i+1 , d.name.c_str());
					//fromImg->DrawString(txt, -1, font, RectF(2, (i*13), 218, 13), NULL ,&brushFontColor);
					//delete[] txt;

					this.DrawRow(RowList[i+top], i * 13);

					//graphics.DrawString("0:00:00", new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 9, FontStyle.Regular), new SolidBrush(Color.FromArgb(240, 240, 240)), 2 + 220, i * 13);

					//graphics.DrawString((i+top+1).ToString() + ". " /*+ playlist[i+top]*/, new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 9, FontStyle.Regular), new SolidBrush(Color.FromArgb(240, 240, 240)), 2, i*13);
				}



				//float pp = (float)top / (playlist->count() - (dimensions->height-4)/13);




				//int center = (int)((dimensions->height-(4.5*2)) * pp);


				//fromImg->DrawLine(&penLine, dimensions->width -6 , 0, dimensions->width-6, dimensions->height);

				//fromImg->DrawImage(sliderHeadBg, dimensions->width-9, center);

				//Graphics    graphics(hdc);
				//graphics.DrawImage(&bmp, dimensions->x, dimensions->y, dimensions->width, dimensions->height);

				//delete fromImg;

				//redraw = false;
			}
			//if(is_mouseDown) { calculate(); }






































			e.Graphics.DrawImageUnscaled(Bmp, Rect.X, Rect.Y);
			Scrollbar.Draw(e);
		}

		public override void HandleMouseEvents(Events.MouseEvent e)
		{
			if(!Scrollbar.CheckBoundingBox(e))
				base.HandleMouseEvents(e);

			//if (!Nodes.Any(a => a.CheckBoundingBox(e)))
			//	base.HandleMouseEvents(e);

			Scrollbar.HandleMouseEvents(e);
		}
	}
}




///*
// * #ifndef _PLAYLIST_MENU_H
//#define _PLAYLIST_MENU_H

//#include "GraphicElement.h"
//#include "playlist.h"

//class PlaylistMenu: public GraphicElement
//{
//private:
//	bool updated;

//	int selected;
//	int top;
//	int lastPlayed;

//	bool autoScroll;

//	bool is_mouseDown;

//	int lastMouse1, lastMouse2;
//	PlayList *playlist;

//	Bitmap *sliderHeadBg;

//	PrivateFontCollection *pfc;
//	Font *font;

//public:
//	PlaylistMenu(int x, int y, int width, int height, HWND hWnd, PlayList *p, WCHAR imgPath[], int imgX, int imgY): GraphicElement(x, y, width, height, hWnd)
//	{
//		selected = 0;
//		playlist = p;
//		lastPlayed = -1; 
//		autoScroll = true;
//		is_mouseDown = false;

//		lastMouse1 = lastMouse2 = -1;
		
//		top = 0;


		
//		pfc = new PrivateFontCollection();
//		pfc->AddFontFile(L"pf_ronda_seven.ttf");

//		// How many font families are in the private collection?
//	   int count = pfc->GetFamilyCount();

//	   // Allocate a buffer to hold the array of FontFamily objects returned by
//	   // the GetFamilies method.
//	   FontFamily* pFontFamily = (FontFamily*)malloc(count * sizeof(FontFamily));

//	   // Get the array of FontFamily objects.
//	   int found = 0;
//	   pfc->GetFamilies(count, pFontFamily, &found);

//	   font = NULL;
//	   if(found != 0)
//	   {

//			// Get the font family name.
//			WCHAR                 familyName[50];
//			pFontFamily[0].GetFamilyName(familyName);
 
//			// Pass the family name and the address of the private collection to a
//			// Font constructor.
//			font = new Font(familyName, 8, FontStyleRegular,
//								 UnitPixel, pfc);
//	   }



//		// Randa exe kelia
//		WCHAR buffer[MAX_PATH];
//		GetModuleFileNameW(NULL, buffer, sizeof(buffer));
//		wstring exeDir = buffer;
//		int place = exeDir.find_last_of('\\');
//		exeDir = exeDir.substr(0, place);
//		_wchdir(exeDir.c_str());

//		//wstring imPat = imgPath;
//		int counter = 0;
//		for(int i = place+1; i < MAX_PATH; i++)
//		{
//			buffer[i] = imgPath[counter];
//			if(imgPath[counter] == '\0')
//			{
//				break;
//			}
//			counter++;
//		}

//		sliderHeadBg = new Bitmap(width, height);
//		Bitmap *b = new Bitmap(buffer); //L"img\\bitmap.bmp"
//		Graphics *fromImgButtonBg = Graphics::FromImage(sliderHeadBg);
//		fromImgButtonBg->DrawImage(b, 0, 0, imgX, imgY, 7, 9, UnitPixel);

//		delete b;
//		delete fromImgButtonBg;

		
//		//updated = false;
//	}

//	~PlaylistMenu()
//	{
//		delete sliderHeadBg;
//		delete pfc;
//		delete font;
//	}



//	void Draw(HDC hdc) override
//	{
	
//		if(redraw)
//		{
//			Bitmap bmp(dimensions->width, dimensions->height);
//			Graphics *fromImg = Graphics::FromImage(&bmp);

//			SolidBrush  brushNowPlaying(PLAYLIST_MENU_PLAYING_SONG_COLOR);
//			SolidBrush  brushFontColor(PLAYLIST_MENU_TEXT_COLOR);
//			SolidBrush  sbrushSliderBackground(PLAYLIST_MENU_SLIDER_BACKGROUND_COLOR);
//			SolidBrush  brushSlider(PLAYLIST_MENU_SLIDER_COLOR);
//			SolidBrush  brushBackground(PLAYLIST_MENU_BACKGROUND_COLOR);
//			Pen			penBorder(PLAYLIST_MENU_BORDER_COLOR);
//			Pen			penBorderSelected(PLAYLIST_MENU_SELECTED_SONG_COLOR);
//			Pen			penLine(SLIDER_CENTER_LINE_COLOR);

//			FontFamily  fontFamily(L"Ventouse");
//			//Font        font(&fontFamily, 8, FontStyleRegular, UnitPixel);

//			// big block
//			fromImg->DrawRectangle(&penBorder, 0, 0, dimensions->width-1, dimensions->height-1);
//			fromImg->FillRectangle(&brushBackground, 1, 1, dimensions->width-2, dimensions->height-2);
	
//			// slider
//			fromImg->DrawRectangle(&penBorder,  dimensions->width-12, 0, 11, dimensions->height-1);
//			fromImg->FillRectangle(&sbrushSliderBackground, dimensions->width-11, 1, 10, dimensions->height-2);

//			//song
//			for(int i = 0; i < (dimensions->height-4)/13 && i+top < playlist->count(); i++)
//			{
	
//				MusicFileData d;						
//				d = playlist->getSong(i+top);

//				if(i+top == playlist->getCurrentSongId()) { fromImg->FillRectangle(&brushNowPlaying, 2, 2 +(i*13), dimensions->width - 4 - 11, 12); lastPlayed = playlist->getCurrentSongId(); }
//				if(i+top == selected) fromImg->DrawRectangle(&penBorderSelected, 2, 2 +(i*13), dimensions->width - 4 - 12, 11);


			

//				if(d.length >= 36000) d.length = 0;

//				WCHAR *txt1 = new WCHAR[20];
//				_stprintf(txt1, _T("%d:%02d:%02d"), d.length / 60 / 60, d.length / 60 % 60, d.length % 60);
//				fromImg->DrawString(txt1, -1, font, RectF(2 + 220, (i*13), 50, 13), NULL ,&brushFontColor);
//				delete[] txt1;


//				WCHAR *txt = new WCHAR[260];
//				_stprintf(txt, _T("%d. %s"), top+i+1 , d.name.c_str());
//				fromImg->DrawString(txt, -1, font, RectF(2, (i*13), 218, 13), NULL ,&brushFontColor);
//				delete[] txt;
//			}

//			// slaideris

			


//			float pp = (float)top / (playlist->count() - (dimensions->height-4)/13);
//			//int boxTop = (dimensions->height-9) * pp; 
//			//int imgTop = (dimensions->height-4) * pp; 



//			int center = (int)((dimensions->height-(4.5*2)) * pp);

//			//fromImg->FillRectangle(&brushSlider, dimensions->width-11, boxTop+1, 10, 8);
			
//			//fromImg->DrawRectangle(&penBorder,  dimensions->width-12, boxTop, 11, 9);

//			fromImg->DrawLine(&penLine, dimensions->width -6 , 0, dimensions->width-6, dimensions->height);

//			fromImg->DrawImage(sliderHeadBg, dimensions->width-9, center);


//			Graphics    graphics(hdc);
//			graphics.DrawImage(&bmp, dimensions->x, dimensions->y, dimensions->width, dimensions->height);

//			delete fromImg;
//			//updated = true;
//			redraw = false;
//		}
//		if(is_mouseDown) { calculate(); }
//	}

//	void Update()
//	{

//		if(lastPlayed >= top && lastPlayed <= top+(dimensions->height-4)/13 && autoScroll == true)
//		{
//			if(playlist->getCurrentSongId() <= top) top = playlist->getCurrentSongId();
//			if(playlist->getCurrentSongId() >= top + (dimensions->height-4)/13-1) top = playlist->getCurrentSongId() - (dimensions->height-4)/13 +1 ;
//		}

//		UpdateGraphics();

//		//updated = false;

//		/*RECT* lpRect = new RECT;

//		lpRect->top = dimensions->y;
//		lpRect->left = dimensions->x; 

//		lpRect-> bottom = dimensions->y+dimensions->height;
//		lpRect->right = dimensions->x+dimensions->width;


//		InvalidateRect(hWnd, lpRect, false);

//		delete[] lpRect;*/
//	}


//	int doubleClick()
//{
//	int r = -1; // pasirinkto punkto indeksas

//	LPPOINT p = new POINT;
//	GetCursorPos(p);
//	ScreenToClient(hWnd, p);

//	if (p->x >= dimensions->x + 1 && p->x <= dimensions->x + dimensions->width - 13 &&
//		p->y >= dimensions->y && p->y <= dimensions->y + dimensions->height)
//	{
//		for (int i = 0; i < (dimensions->height - 4) / 13 && i + top < playlist->count(); i++)
//		{

//			if (p->y >= dimensions->y + 2 + (i * 13) && p->y <= dimensions->y + 2 + (i * 13) + 12) { selected = top + i; r = top + i; }
//		}



//	}

//	/*if(p->x >= x + width-13 && p->x <= x + width &&
//		p->y >= y && p->y <= y + height)
//	{

//		float pp = (float)(p->y - y)/height;

//		top = (playlist->count()- (height-4)/13) * pp;

//		if(top >= playlist->count() - (height-4)/13) top = playlist->count() - (height-4)/13;
//		if(top < 0) top = 0;
//	}
//*/
//	Update();

//	delete[] p;

//	return r;
//}

//void scroll(int delta, bool sukti)
//{
//	//LPPOINT p = new POINT;
//	//GetCursorPos(p);
//	//ScreenToClient(hWnd, p);

//	if (checkBoundingBox() || sukti == true)
//	{
//		if (!sukti) top += delta;




//		if (sukti)
//		{
//			selected += delta;
//			if (selected < 0) selected = 0;
//			if (selected >= playlist->count()) selected = playlist->count() - 1;

//			if (selected < top) top = selected;
//			if (selected >= top + (dimensions->height - 4) / 13) top = selected - (dimensions->height - 4) / 13 + 1;
//		}

//		if (top >= playlist->count() - (dimensions->height - 4) / 13) top = playlist->count() - (dimensions->height - 4) / 13;
//		if (top < 0) top = 0;

//		//updated = false;
//		autoScroll = false;
//		Update();
//		autoScroll = true;
//	}
//	//delete[] p;
//}


//void MouseDown() override
//	{

//		LPPOINT p = new POINT;
//		GetCursorPos(p);
//		ScreenToClient(hWnd, p);


//		if(p->x >= dimensions->x + dimensions->width-13 && p->x <= dimensions->x + dimensions->width &&
//			p->y >= dimensions->y && p->y <= dimensions->y + dimensions->height)
//		{
//			is_mouseDown = true;

//			float pp = (float)(p->y - dimensions->y) / dimensions->height;

//top = (playlist->count()- (dimensions->height-4)/13) * pp;

//			if(top >= playlist->count() - (dimensions->height-4)/13) top = playlist->count() - (dimensions->height-4)/13;
//			if(top< 0) top = 0;
//		}

//		//update();

//		delete[] p;

//	}


//	void MouseUp() override
//	{
//		is_mouseDown = false;
//	}

//	void calculate()
//{
//	LPPOINT p = new POINT;
//	GetCursorPos(p);
//	ScreenToClient(hWnd, p);


//	if (p->y >= dimensions->y + 5 && p->y <= dimensions->y + dimensions->height - 5)
//	{
//		float pp = (float)((p->y - dimensions->y - 5)) / (dimensions->height - 2 * 5);
//		//float pp = (float)top / (playlist->count() - (dimensions->height-4)/13);

//		top = (playlist->count() - (dimensions->height - 4.5 * 2) / 13) * pp;



//		//float pp = (float)top / (playlist->count() - (dimensions->height-4)/13);
//		//int center = (int)((dimensions->height-(4.5*2)) * pp);


//		if (top >= playlist->count() - (dimensions->height - 4) / 13) top = playlist->count() - (dimensions->height - 4) / 13;
//		if (top < 0) top = 0;

//		/*int tmp = p->x - x - 10;
//		if(lastMousePoint1 != tmp) progress = (float)tmp/(width-2*10)*100;

//		lastMousePoint1 = lastMousePoint2;
//		lastMousePoint2 = tmp;*/
//	}
//	else
//	{

//		if (p->y < dimensions->y + 10) top = 0;
//		if (p->y > dimensions->y + dimensions->height - 10) top = (playlist->count() - (dimensions->height - 4) / 13);


//		/*
//		lastMousePoint1 = 0;
//		lastMousePoint2 = 1;*/
//	}

//	lastMouse1 = lastMouse2;
//	lastMouse2 = p->y;

//	if (lastMouse1 != lastMouse2) Update();


//	delete[] p;

//}

//void setTop(int tt)
//{
//	top = tt;
//	if (top >= playlist->count() - (dimensions->height - 4) / 13) top = playlist->count() - (dimensions->height - 4) / 13;
//	if (top < 0) top = 0;
//	Update();
//}

//int getSelection()
//{
//	return selected;
//}

//};

//#endif*/