﻿namespace iPlay
{
	partial class _OldMain
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
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(488, 145);
			this.Name = "Main";
			this.Text = "iPlay";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer UIUpdateTimer;
	}
}
