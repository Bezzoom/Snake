using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake_II
{
	class Snake
	{
		int X, Y, Length;

		PictureBox Canvas;
		List<Dot> snake;

		public Snake(PictureBox f, int x, int y, int length)
		{
			X = x; Y = y; Length = length;
			Canvas = f;

			snake = new List<Dot>();
			int pad = 0;
			for (int i = 0; i < Length; i++)
			{
				Dot dot = new Dot(f, X + (10 * i) + pad, Y);
				snake.Add(dot);
				pad = pad + 2;
			}
		}

		public void Move()
		{
			Dot tail = snake.First();
			snake.Remove(tail);
			Dot head = GetNextDot();
			snake.Add(head);
		}
		private Dot GetNextDot()
		{
			var dot = snake.Last();
			Dot ndot = new Dot(dot);
			ndot.Move(1, ControlActions.RIGHT);
			return ndot;
		}
		public void Draw()
		{
			foreach (var dot in snake)
			{
				dot.Draw();
			}
		}

		public void Redraw()
		{
			SolidBrush p = new SolidBrush(Color.Gainsboro);
			Graphics g = Graphics.FromHwnd(Canvas.Handle);
			g.FillRectangle(p, 13, 13, 361, 181);

			g.Dispose();
			p.Dispose();

			this.Draw();
		}
	}
}
