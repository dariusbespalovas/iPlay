namespace iPlay
{
	partial class Main
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
			this.button1 = new iPlay.UI.Button();
			this.volumeSlider = new iPlay.UI.Slider();
			this.positionSlider = new iPlay.UI.Slider();
			this.button3 = new iPlay.UI.Button();
			this.button4 = new iPlay.UI.Button();
			this.button5 = new iPlay.UI.Button();
			this.button6 = new iPlay.UI.Button();
			this.scrollableTable1 = new iPlay.UI.ScrollableTable();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panelV = new iPlay.UI.Panel();
			this.formPanel.SuspendLayout();
			this.baseFormContentsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// formPanel
			// 
			this.formPanel.Size = new System.Drawing.Size(488, 145);
			// 
			// buttonMinimize
			// 
			this.buttonMinimize.Location = new System.Drawing.Point(466, 2);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(476, 2);
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// baseFormContentsPanel
			// 
			this.baseFormContentsPanel.Controls.Add(this.panelV);
			this.baseFormContentsPanel.Controls.Add(this.scrollableTable1);
			this.baseFormContentsPanel.Controls.Add(this.button6);
			this.baseFormContentsPanel.Controls.Add(this.button5);
			this.baseFormContentsPanel.Controls.Add(this.button4);
			this.baseFormContentsPanel.Controls.Add(this.button3);
			this.baseFormContentsPanel.Controls.Add(this.positionSlider);
			this.baseFormContentsPanel.Controls.Add(this.volumeSlider);
			this.baseFormContentsPanel.Controls.Add(this.button1);
			this.baseFormContentsPanel.Size = new System.Drawing.Size(482, 130);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(163, 196);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			// 
			// volumeSlider
			// 
			this.volumeSlider.Location = new System.Drawing.Point(98, 114);
			this.volumeSlider.Name = "volumeSlider";
			this.volumeSlider.Orientation = iPlay.UI.Slider.SliderOrientation.Horizontal;
			this.volumeSlider.Size = new System.Drawing.Size(88, 7);
			this.volumeSlider.TabIndex = 2;
			this.volumeSlider.Text = "slider1";
			this.volumeSlider.Value = 0F;
			// 
			// positionSlider
			// 
			this.positionSlider.Location = new System.Drawing.Point(9, 101);
			this.positionSlider.Name = "positionSlider";
			this.positionSlider.Orientation = iPlay.UI.Slider.SliderOrientation.Horizontal;
			this.positionSlider.Size = new System.Drawing.Size(177, 7);
			this.positionSlider.TabIndex = 5;
			this.positionSlider.Text = "slider1";
			this.positionSlider.Value = 0F;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(6, 111);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(17, 13);
			this.button3.TabIndex = 6;
			this.button3.Text = "button3";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(29, 111);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(17, 13);
			this.button4.TabIndex = 7;
			this.button4.Text = "button4";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(52, 111);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(17, 13);
			this.button5.TabIndex = 8;
			this.button5.Text = "button5";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(75, 111);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(17, 13);
			this.button6.TabIndex = 9;
			this.button6.Text = "button6";
			// 
			// scrollableTable1
			// 
			this.scrollableTable1.Location = new System.Drawing.Point(196, 4);
			this.scrollableTable1.Name = "scrollableTable1";
			this.scrollableTable1.Size = new System.Drawing.Size(283, 120);
			this.scrollableTable1.TabIndex = 10;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// panelV
			// 
			this.panelV.Location = new System.Drawing.Point(10, 4);
			this.panelV.Name = "panelV";
			this.panelV.Size = new System.Drawing.Size(176, 91);
			this.panelV.TabIndex = 11;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(488, 145);
			this.Name = "Main";
			this.Text = "Main";
			this.formPanel.ResumeLayout(false);
			this.baseFormContentsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private UI.Button button1;
		private UI.Slider volumeSlider;
		private UI.Slider positionSlider;
		private UI.Button button3;
		private UI.Button button6;
		private UI.Button button5;
		private UI.Button button4;
		private UI.ScrollableTable scrollableTable1;
		private System.Windows.Forms.Timer timer1;
		private UI.Panel panelV;
	}
}