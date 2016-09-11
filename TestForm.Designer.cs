namespace iPlay
{
	partial class TestForm
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
			this.customContainer1 = new iPlay.UI.Panel();
			this.customContainer2 = new iPlay.UI.Panel();
			this.button1 = new iPlay.UI.Button();
			this.customContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// customContainer1
			// 
			this.customContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.customContainer1.Controls.Add(this.button1);
			this.customContainer1.Controls.Add(this.customContainer2);
			this.customContainer1.Location = new System.Drawing.Point(12, 12);
			this.customContainer1.Name = "customContainer1";
			this.customContainer1.Size = new System.Drawing.Size(560, 274);
			this.customContainer1.TabIndex = 0;
			// 
			// customContainer2
			// 
			this.customContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.customContainer2.Location = new System.Drawing.Point(3, 3);
			this.customContainer2.Name = "customContainer2";
			this.customContainer2.Size = new System.Drawing.Size(554, 188);
			this.customContainer2.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(26, 229);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 307);
			this.Controls.Add(this.customContainer1);
			this.Name = "TestForm";
			this.Text = "TestForm";
			this.customContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private UI.Panel customContainer1;
		private UI.Panel customContainer2;
		private UI.Button button1;
	}
}