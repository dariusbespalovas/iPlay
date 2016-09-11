using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPlay.UI
{
	public class VLC : UIElement
	{
		public Vlc.DotNet.Core.VlcMediaPlayer player;

		protected System.Drawing.Bitmap VlcBmp;

		#region drawing stuff
		//private SolidBrush BackgroudBrush = new SolidBrush(Color.FromArgb(131, 31, 31));
		private Pen BorderPen = new Pen(Color.FromArgb(21, 121, 21));
		//private SolidBrush testBrush = new SolidBrush(Color.FromArgb(200, 31, 31));
		#endregion

		public VLC(Rect2D rect) : base(rect)
		{
			this.VlcBmp = new System.Drawing.Bitmap(500, 500);

			player = new Vlc.DotNet.Core.VlcMediaPlayer(new DirectoryInfo(@"D:\LibVlc"));
			player.SetMedia(new FileInfo("J:\\Video\\Klipai\\√Bestamvsofalltime ▪ Aevum AMV.mp4"));

			//player.VideoHostControlHandle = this.Handle;



			//v.Video.Tracks.Current.
			player.Play();

			//VlcBmp.
		}


		private void PlayVideo(object sender, EventArgs e)
		{
			//player.SetMedia(new FileInfo("J:\\Video\\Klipai\\√Bestamvsofalltime ▪ Aevum AMV.mp4"));
			//player.Play();
		}


		public override void Draw(Graphics g)
		{
			


			//vlcControl1.Invalidate();
			//vlcControl1.Update();
			//vlcControl1.Refresh();
			//vlcControl1.Show();


			//player.DrawToBitmap(VlcBmp, new Rectangle(0, 0, 500, 500));


			//graphics.FillRectangle(BackgroudBrush, 0, 0, RectScreenSpace.W, RectScreenSpace.H);
			graphics.DrawRectangle(BorderPen, 0, 0, RectScreenSpace.W - 1, RectScreenSpace.H - 1);

			//graphics.FillRectangle(testBrush, 0 + RectScreenSpace.W / 3, 0 + RectScreenSpace.H / 3, RectScreenSpace.W / 3, RectScreenSpace.H / 3);

			//graphics.DrawString(Name, new Font(new FontFamily(GenericFontFamilies.SansSerif), 7, FontStyle.Regular), new SolidBrush(Color.FromArgb(240, 240, 240)), 0, 0);


			g.DrawImageUnscaled(Bmp, RectScreenSpace.X, RectScreenSpace.Y);
			//g.DrawImageUnscaled(VlcBmp, RectScreenSpace.X, RectScreenSpace.Y);

		}

	}
}
