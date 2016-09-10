namespace iPlay
{
	partial class VideoForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
			this.UIUpdateTimer = new System.Windows.Forms.Timer(this.components);
			// 
			// UIUpdateTimer
			// 
			this.UIUpdateTimer.Enabled = true;
			this.UIUpdateTimer.Interval = 10;
			this.UIUpdateTimer.Tick += new System.EventHandler(this.timer1_Tick);

			((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();
			this.SuspendLayout();
			// 
			// vlcControl1
			// 
			this.vlcControl1.AllowDrop = true;
			this.vlcControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.vlcControl1.BackColor = System.Drawing.Color.Black;
			this.vlcControl1.Location = new System.Drawing.Point(12, 17);
			this.vlcControl1.Name = "vlcControl1";
			this.vlcControl1.Size = new System.Drawing.Size(260, 220);
			this.vlcControl1.Spu = -1;
			this.vlcControl1.TabIndex = 0;
			this.vlcControl1.Text = "vlcControl1";
			this.vlcControl1.VlcLibDirectory = null;
			this.vlcControl1.VlcMediaplayerOptions = null;
			this.vlcControl1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);

			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Text = "VideoForm";

			this.Controls.Add(this.vlcControl1);

			((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();
			this.ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Timer UIUpdateTimer;

		private Vlc.DotNet.Forms.VlcControl vlcControl1;
	}
}