﻿namespace iPlay
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
			this.UIUpdateTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// UIUpdateTimer
			// 
			this.UIUpdateTimer.Enabled = true;
			this.UIUpdateTimer.Interval = 10;
			this.UIUpdateTimer.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(488, 145);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Name = "Main";
			this.Text = "iPlay";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
			this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Main_MouseWheel);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_KeyPress);
			this.KeyPreview = true;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyPress2);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer UIUpdateTimer;
	}
}

