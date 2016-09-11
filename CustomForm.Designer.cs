namespace iPlay
{
	partial class CustomForm
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
			this.formPanel = new iPlay.UI.Panel();
			this.baseFormContentsPanel = new iPlay.UI.Panel();
			this.buttonMinimize = new iPlay.UI.Button();
			this.buttonClose = new iPlay.UI.Button();
			this.formPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// formPanel
			// 
			this.formPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.formPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.formPanel.Controls.Add(this.baseFormContentsPanel);
			this.formPanel.Controls.Add(this.buttonMinimize);
			this.formPanel.Controls.Add(this.buttonClose);
			this.formPanel.Location = new System.Drawing.Point(0, 0);
			this.formPanel.Name = "formPanel";
			this.formPanel.Size = new System.Drawing.Size(500, 500);
			this.formPanel.TabIndex = 0;
			this.formPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formPanel_MouseDown);
			this.formPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formPanel_MouseMove);
			this.formPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formPanel_MouseUp);
			// 
			// baseFormContentsPanel
			// 
			this.baseFormContentsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.baseFormContentsPanel.Location = new System.Drawing.Point(3, 12);
			this.baseFormContentsPanel.Name = "baseFormContentsPanel";
			this.baseFormContentsPanel.Size = new System.Drawing.Size(494, 485);
			this.baseFormContentsPanel.TabIndex = 2;
			// 
			// buttonMinimize
			// 
			this.buttonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMinimize.Location = new System.Drawing.Point(478, 2);
			this.buttonMinimize.Name = "buttonMinimize";
			this.buttonMinimize.Size = new System.Drawing.Size(9, 9);
			this.buttonMinimize.TabIndex = 1;
			this.buttonMinimize.Text = "button2";
			this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Location = new System.Drawing.Point(488, 2);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(9, 9);
			this.buttonClose.TabIndex = 0;
			this.buttonClose.Text = "button1";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// CustomForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 500);
			this.Controls.Add(this.formPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "CustomForm";
			this.Text = "CustomForm";
			this.formPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		protected UI.Panel formPanel;
		protected UI.Button buttonMinimize;
		protected UI.Button buttonClose;
		protected UI.Panel baseFormContentsPanel;
	}
}