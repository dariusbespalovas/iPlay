using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPlay.UI
{
	public partial class Table : Control
	{
		#region EventHandlers
		public event EventHandler SelectionChanged;
		public event EventHandler MarkerChanged;
		public event EventHandler ScrollChanged;
		#endregion

		private int MarkedRow;
		private int TopListRow;
		private int SelectedRow;
		private bool AutoScroll;

		public float ScrollPosition
		{
			get
			{
				return (float)TopListRow / (RowList.Count-1);
			}
		}

		private List<object> RowList;
		private List<TableSetingsModel> TableSettings;

		private StringFormat stringFormat = new StringFormat();

		public class TableSetingsModel
		{
			public string FieldName { get; set; }
			public int Width { get; set; }
			public StringAlignment Alignment { get; set; }
		}

		#region drawing stuff
		//private SolidBrush BackgroudBrush = new SolidBrush(Color.FromArgb(131, 31, 31));
		//private Pen BorderPen = new Pen(Color.Orange);

		private SolidBrush BackgroudBrush = new SolidBrush(Color.FromArgb(31, 31, 31));
		private Pen BorderPen = new Pen(Color.FromArgb(31, 31, 31));

		#endregion


		public Table()
		{
			InitializeComponent();

			this.RowList = new List<object>();

			this.DoubleBuffered = true;

			this.Click += Table_Click;
			this.DoubleClick += Table_DoubleClick;
			this.MouseWheel += Table_MouseWheel;
		}

		private void Table_MouseWheel(object sender, MouseEventArgs e)
		{
			this.TopListRow -= e.Delta * System.Windows.Forms.SystemInformation.MouseWheelScrollLines / 120;

			if (TopListRow < 0) TopListRow = 0;
			if (TopListRow > RowList.Count - 1) TopListRow = RowList.Count - 1;

			ScrollChanged?.Invoke(this, e);

			this.Invalidate();
		}

		//private void UpdateScrollbarValue()
		//{
		//	this.Scrollbar.Value = ((float)this.TopListRow / (this.RowList.Count - 1));
		//}

		public void SetScrolPosition(float value)
		{
			int lastVal = this.TopListRow;

			this.TopListRow = (int)(value * (RowList.Count - 1));
			if (this.TopListRow < 0) this.TopListRow = 0;

			if(this.TopListRow != lastVal)
				this.Invalidate();
		}

		private void Table_DoubleClick(object sender, EventArgs e)
		{
			HandleClickSelection(e, true);
		}

		private void Table_Click(object sender, EventArgs e)
		{
			HandleClickSelection(e, false);
		}

		private void HandleClickSelection(EventArgs e, bool IsDoubleClick)
		{
			if (((MouseEventArgs)e).X >= ClientRectangle.X + 1 && ((MouseEventArgs)e).X <= ClientRectangle.X + ClientRectangle.Width - 13 &&
					((MouseEventArgs)e).Y >= ClientRectangle.Y && ((MouseEventArgs)e).Y <= ClientRectangle.Y + ClientRectangle.Height)
			{
				for (int i = 0; i < (ClientRectangle.Height - 4) / 13 && i + TopListRow < RowList.Count; i++)
				{
					if (((MouseEventArgs)e).Y >= ClientRectangle.Y + 2 + (i * 13) && ((MouseEventArgs)e).Y <= ClientRectangle.Y + 2 + (i * 13) + 12)
					{
						int LastSelection = MarkedRow;
						MarkedRow = TopListRow + i;
						if (IsDoubleClick && LastSelection == MarkedRow)
						{
							SelectedRow = MarkedRow;
							SelectionChanged?.Invoke(this, e);
						}
					}
				}
				this.Invalidate();
			}
		}



		public void SetData(List<object> list)
		{
			this.RowList = list;
		}

		public void SetSettings(List<TableSetingsModel> TableSettings)
		{
			this.TableSettings = TableSettings;
		}

		private void DrawRow(object t, int h, PaintEventArgs pe)
		{
			int paintStart = 2;

			Font fnt = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 9, FontStyle.Regular);
			Brush brsh = new SolidBrush(Color.FromArgb(240, 240, 240));

			foreach (var v in TableSettings)
			{
				string txt = t.GetType().GetProperty(v.FieldName).GetValue(t, null).ToString();


				//graphics.DrawString(txt, fnt, brsh, paintStart, h);

				stringFormat.Alignment = v.Alignment;

				pe.Graphics.DrawString(txt, fnt, brsh, new RectangleF(paintStart, h, v.Width, 13), this.stringFormat);

				paintStart += v.Width;

			}
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			pe.Graphics.FillRectangle(BackgroudBrush, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
			pe.Graphics.DrawRectangle(BorderPen, 0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);

			SolidBrush brushNowPlaying = new SolidBrush(Color.FromArgb(60, 80, 100));
			Pen penBorderSelected = new Pen(Color.FromArgb(120, 120, 120));

			//song
			for (int i = 0; i < (ClientRectangle.Height - 4) / 13 && i + TopListRow < RowList.Count; i++)
			{
				if (i + TopListRow == SelectedRow) { pe.Graphics.FillRectangle(brushNowPlaying, 2, 2 + (i * 13), ClientRectangle.Width - 0 - 3, 12); }
				if (i + TopListRow == MarkedRow) pe.Graphics.DrawRectangle(penBorderSelected, 2, 2 + (i * 13), ClientRectangle.Width - 0 - 4, 11);

				this.DrawRow(RowList[i + TopListRow], i * 13, pe);
			}
		}
	}
}
