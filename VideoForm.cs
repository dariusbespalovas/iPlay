using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPlay
{
	public partial class VideoForm : CustomForm
	{
		public VideoForm() : base(500, 500)
		{
			InitializeComponent();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.Refresh();
		}
	}
}
