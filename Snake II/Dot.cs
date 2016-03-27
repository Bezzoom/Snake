using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Snake_II
{
	class Dot
	{
		public int x, y, width;
		PictureBox f;

		public Dot(PictureBox f, int x, int y)
		{
			this.x = x;
			this.y = y;
			width = 10;

			this.f = f;
		}
		public Dot(Dot d)
		{
			this.x = d.x;
			this.y = d.y;
			width = 10;
			this.f = d.f;
		}

		public void Move(int offset, ControlActions direction)
		{
			offset = offset * 12;
			switch (direction)
			{
				case ControlActions.UP:
					y = y - offset;
					break;
				case ControlActions.RIGHT:
					x = x + offset;
					break;
				case ControlActions.DOWN:
					y = y + offset;
					break;
				case ControlActions.LEFT:
					x = x - offset;
					break;
				default:
					break;
			}
		}

		public void Draw()
		{
			Pen p = new Pen(Color.Black);
			Graphics g = Graphics.FromHwnd(f.Handle);
			g.DrawRectangle(p, x, y, width, width);

			g.Dispose();
			p.Dispose();
		}
	}
}
