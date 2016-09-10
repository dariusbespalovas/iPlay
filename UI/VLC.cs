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
		private Vlc.DotNet.Forms.VlcControl vlcControl1;

		#region drawing stuff
		//private SolidBrush BackgroudBrush = new SolidBrush(Color.FromArgb(131, 31, 31));
		private Pen BorderPen = new Pen(Color.FromArgb(21, 121, 21));
		//private SolidBrush testBrush = new SolidBrush(Color.FromArgb(200, 31, 31));
		#endregion

		public VLC(Rect2D rect) : base(rect)
		{
			this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();

			((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();

			this.vlcControl1.AllowDrop = true;
			this.vlcControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom));
			this.vlcControl1.BackColor = System.Drawing.Color.Black;
			this.vlcControl1.Location = new System.Drawing.Point(0, 0);
			this.vlcControl1.Name = "vlcControl1";
			this.vlcControl1.Size = new System.Drawing.Size(500, 500);
			this.vlcControl1.Spu = -1;
			this.vlcControl1.TabIndex = 0;
			this.vlcControl1.Text = "vlcControl1";
			this.vlcControl1.VlcLibDirectory = null;
			this.vlcControl1.VlcMediaplayerOptions = null;
			this.vlcControl1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
			this.vlcControl1.BackColor = Color.Yellow;
			this.Click += PlayVideo;

			((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();


			
		}

		private void vlcControl1_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
		{
			var currentAssembly = Assembly.GetEntryAssembly();
			var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
			if (currentDirectory == null)
				return;
			if (AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86)
				e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"Y:\-=GOOGLE CODE PROJEKTAI=-\GIT\iPlay\packages\Meta.Vlc.Lib.16.05.01\content\LibVlc"));
			else
				e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"Y:\-=GOOGLE CODE PROJEKTAI=-\GIT\iPlay\packages\Meta.Vlc.Lib.16.05.01\content\LibVlc"));

			if (!e.VlcLibDirectory.Exists)
			{
				var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
				folderBrowserDialog.Description = "Select Vlc libraries folder.";
				folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
				folderBrowserDialog.ShowNewFolderButton = true;
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
				}
			}
		}

		private void PlayVideo(object sender, EventArgs e)
		{
			vlcControl1.SetMedia(new FileInfo("J:\\Video\\Klipai\\√Bestamvsofalltime ▪ Aevum AMV.mp4"));
			//vlcControl1.SetMedia(new Uri("http://r8---sn-p5qlsnsz.googlevideo.com/videoplayback?ip=159.253.144.86&mime=video%2Fmp4&source=youtube&mm=31&mn=sn-p5qlsnsz&pl=24&id=o-AJPwZMxa8FEHRYl67cBP2jFFdVBQy5vgUdbMlrrUFKHL&ms=au&mt=1473448324&mv=m&expire=1473470419&upn=rcZR3lrbNzM&key=yt6&ipbits=0&ratebypass=yes&itag=22&initcwndbps=2952500&dur=3809.581&nh=IgpwcjAzLmlhZDA3KgkxMjcuMC4wLjE&sver=3&sparams=dur%2Cei%2Cid%2Cinitcwndbps%2Cip%2Cipbits%2Citag%2Clmt%2Cmime%2Cmm%2Cmn%2Cms%2Cmv%2Cnh%2Cpl%2Cratebypass%2Csource%2Cupn%2Cexpire&lmt=1471303980134852&ei=cwvTV66SBdSUWLaykuAO&signature=E177FCFB9BF8BCF0FD71D08CA982D00FF1509012.8EDE0CAD0D6E309B1760187DD5538D66B4AB06FE&title=Summer+Ibiza+Mix+2016+-+Best+Of+Deep+House+Sessions+Music+2016+Chill+Out+Mix+by+Drop+G"));

			//vlcControl1.SetMedia(new Uri("http://redirector.googlevideo.com/videoplayback?lmt=1472452628172564&expire=1473473973&ratebypass=yes&gcr=us&upn=JChcgCG9ipo&key=yt6&nh=IgpwcjAzLmlhZDA3KgkxMjcuMC4wLjE&ip=159.253.144.86&ipbits=0&initcwndbps=3563750&pl=24&sparams=dur%2Cei%2Cgcr%2Cid%2Cinitcwndbps%2Cip%2Cipbits%2Citag%2Clmt%2Cmime%2Cmm%2Cmn%2Cms%2Cmv%2Cnh%2Cpl%2Cratebypass%2Csource%2Cupn%2Cexpire&ei=VRnTV9mzDNeBWZLmlrgB&itag=22&mime=video%2Fmp4&id=o-ANetzXcK1A5AmyWLNWPAimF4QjIIsmUDfaiIfDNrUYfT&dur=249.382&mm=31&mn=sn-p5qlsnsr&sver=3&source=youtube&ms=au&mt=1473451577&mv=m&signature=9B74EF3D85653F2ACBA23A464B57E523939A16C5.E322B1F699EB998AF4852C47B6CF9434ED1257BE&title=Fever+The+Ghost+-+SOURCE+%28official+music+video%29"));

			vlcControl1.Play();
		}


		public override void Draw(Graphics g)
		{
			


			vlcControl1.Invalidate();
			//vlcControl1.Update();
			//vlcControl1.Show();

			vlcControl1.DrawToBitmap(Bmp, new Rectangle(0, 0, Rect.W, Rect.H));

			

			//graphics.FillRectangle(BackgroudBrush, 0, 0, RectScreenSpace.W, RectScreenSpace.H);
			graphics.DrawRectangle(BorderPen, 0, 0, RectScreenSpace.W - 1, RectScreenSpace.H - 1);

			//graphics.FillRectangle(testBrush, 0 + RectScreenSpace.W / 3, 0 + RectScreenSpace.H / 3, RectScreenSpace.W / 3, RectScreenSpace.H / 3);

			//graphics.DrawString(Name, new Font(new FontFamily(GenericFontFamilies.SansSerif), 7, FontStyle.Regular), new SolidBrush(Color.FromArgb(240, 240, 240)), 0, 0);


			g.DrawImageUnscaled(Bmp, RectScreenSpace.X, RectScreenSpace.Y);

		}

	}
}
