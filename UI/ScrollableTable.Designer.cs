namespace iPlay.UI
{
	partial class ScrollableTable
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.slider = new iPlay.UI.Slider();
			this.table = new iPlay.UI.Table();
			this.SuspendLayout();
			// 
			// slider
			// 
			this.slider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.slider.Location = new System.Drawing.Point(323, 0);
			this.slider.Name = "slider";
			this.slider.Orientation = iPlay.UI.Slider.SliderOrientation.Vertical;
			this.slider.Size = new System.Drawing.Size(7, 120);
			this.slider.TabIndex = 1;
			this.slider.Text = "slider1";
			this.slider.Value = 0F;
			// 
			// table
			// 
			this.table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.table.Location = new System.Drawing.Point(0, 0);
			this.table.Name = "table";
			this.table.Size = new System.Drawing.Size(323, 120);
			this.table.TabIndex = 2;
			this.table.Text = "table1";
			// 
			// ScrollableTable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.table);
			this.Controls.Add(this.slider);
			this.Name = "ScrollableTable";
			this.Size = new System.Drawing.Size(330, 120);
			this.ResumeLayout(false);

		}

		#endregion
		private Slider slider;
		public Table table;
	}
}
