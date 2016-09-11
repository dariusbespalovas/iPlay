using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPlay.UI
{
	public partial class ScrollableTable : UserControl
	{
		public ScrollableTable()
		{
			InitializeComponent();

			slider.ValueChanged += Slider_ValueChanged;
			table.ScrollChanged += Table_ScrollChanged;
		}

		private void Table_ScrollChanged(object sender, EventArgs e)
		{
			slider.Value = table.ScrollPosition;
		}

		private void Slider_ValueChanged(object sender, EventArgs e)
		{
			this.table.SetScrolPosition(slider.Value);
		}
	}
}
