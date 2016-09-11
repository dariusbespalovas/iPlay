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
			this.panel1 = new iPlay.UI.Panel();
			this.button2 = new iPlay.UI.Button();
			this.button1 = new iPlay.UI.Button();
			this.slider1 = new iPlay.UI.Slider();
			this.volumeSlider = new iPlay.UI.Slider();
			this.formPanel.SuspendLayout();
			this.baseFormContentsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// formPanel
			// 
			this.formPanel.Size = new System.Drawing.Size(971, 626);
			// 
			// buttonMinimize
			// 
			this.buttonMinimize.Location = new System.Drawing.Point(949, 2);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(959, 2);
			// 
			// baseFormContentsPanel
			// 
			this.baseFormContentsPanel.Controls.Add(this.volumeSlider);
			this.baseFormContentsPanel.Controls.Add(this.slider1);
			this.baseFormContentsPanel.Controls.Add(this.button2);
			this.baseFormContentsPanel.Controls.Add(this.panel1);
			this.baseFormContentsPanel.Controls.Add(this.button1);
			this.baseFormContentsPanel.Size = new System.Drawing.Size(965, 611);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(959, 576);
			this.panel1.TabIndex = 0;
			this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Location = new System.Drawing.Point(84, 585);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "button2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Location = new System.Drawing.Point(3, 585);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 9000;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// slider1
			// 
			this.slider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.slider1.Location = new System.Drawing.Point(165, 585);
			this.slider1.Name = "slider1";
			this.slider1.Orientation = iPlay.UI.Slider.SliderOrientation.Horizontal;
			this.slider1.Size = new System.Drawing.Size(680, 23);
			this.slider1.TabIndex = 9001;
			this.slider1.Text = "slider1";
			this.slider1.Value = 0F;
			this.slider1.ValueChanged += new System.EventHandler(this.slider1_ValueChanged);
			// 
			// volumeSlider
			// 
			this.volumeSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.volumeSlider.Location = new System.Drawing.Point(851, 585);
			this.volumeSlider.Name = "volumeSlider";
			this.volumeSlider.Orientation = iPlay.UI.Slider.SliderOrientation.Horizontal;
			this.volumeSlider.Size = new System.Drawing.Size(111, 23);
			this.volumeSlider.TabIndex = 9002;
			this.volumeSlider.Text = "slider2";
			this.volumeSlider.Value = 0F;
			this.volumeSlider.ValueChanged += new System.EventHandler(this.volumeSlider_ValueChanged);
			// 
			// VideoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(971, 626);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "VideoForm";
			this.Text = "VideoForm";
			this.formPanel.ResumeLayout(false);
			this.baseFormContentsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private UI.Panel panel1;
		private UI.Button button2;
		private UI.Button button1;
		private UI.Slider slider1;
		private UI.Slider volumeSlider;
	}
}