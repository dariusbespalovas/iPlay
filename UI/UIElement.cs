using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPlay.UI
{
	public abstract class UIElement
	{
		public Rect2D Rect;

		public UIElement(Rect2D rect)
		{
			this.Rect = rect;
		}

		public abstract void Draw(System.Windows.Forms.PaintEventArgs e);
	}
}
