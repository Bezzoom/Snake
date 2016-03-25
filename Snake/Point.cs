using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Point
	{
		public int x;
		public int y;
		public char dot;
		
		public Point(int x, int y, char dot)
		{
			this.x = x; this.y = y; this.dot = dot;
		}

		public Point(Point p)
		{
			this.x = p.x; this.y = p.y; this.dot = p.dot; 
		}
		public void Move(int offset, Direction direction)
		{
			switch (direction)
			{
				case Direction.UP:
					y = y - offset;
					break;
				case Direction.RIGHT:
					x = x + offset;
					break;
				case Direction.DOWN:
					y = y + offset;
					break;
				case Direction.LEFT:
					x = x - offset;
					break;
				default:
					break;
			}
		}
		public void Clear()
		{
			dot = ' ';
			Draw();
		}

		public void Draw()
		{
			Console.SetCursorPosition(x, y);
			Console.Write(dot);
		}

		public bool isHit(Point p)
		{
			return p.x == this.x && p.y == this.y;
		}
	}
}
