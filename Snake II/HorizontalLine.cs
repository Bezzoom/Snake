using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_II
{
	class HorizontalLine
	{
		int X, Y, Length;
		Dot[] Line;
		PictureBox Canvas;

		public HorizontalLine(PictureBox f, int x, int y, int length)
		{
			X = x; Y = y; Length = length;
			Canvas = f;

			Line = new Dot[length];
			int pad = 0;
			for (int i = 0; i < Length; i++)
			{
				Line[i] = new Dot(f, X + (10 * i) + pad, Y);
				pad = pad + 2;
			}
		}

		public void Draw()
		{
			foreach (var dot in Line)
			{
				dot.Draw();
			}
		}
	}
}
