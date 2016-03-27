using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Snake_II
{
	class Game
	{
		PictureBox Canvas;

		public Game(PictureBox canvas)
		{
			Canvas = canvas;
		}

		public void Start()
		{
			Snake snake = new Snake(Canvas, 26, 26, 5);
			snake.Draw();

			while (true)
			{
				snake.Move();
				snake.Redraw();
				Thread.Sleep(200);
			}

		}

		public void Load()
		{
			Canvas.Visible = true;
			HorizontalLine topLine = new HorizontalLine(Canvas, 2, 2, 32);
			VerticalLine leftLine = new VerticalLine(Canvas, 2, 2, 17);
			HorizontalLine bottombLine = new HorizontalLine(Canvas, 2, 194, 32);
			VerticalLine rightLine = new VerticalLine(Canvas, 374, 2, 17);

			topLine.Draw();
			leftLine.Draw();
			bottombLine.Draw();
			rightLine.Draw();

			this.Start();
		}

		public void Redraw()
		{

		}
	}
}
