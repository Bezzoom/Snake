using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Snake : Figure
	{
		Direction Direction;

		public Snake(Point Tail, int Length, Direction Direction)
		{
			this.Direction = Direction;
			pList = new List<Point>();

			for (int i = 0; i < Length; i++)
			{
				Point p = new Point(Tail);
				p.Move(i, this.Direction);
				pList.Add(p);
			}
		}

		internal void Move()
		{
			Point tail = pList.First();
			pList.Remove(tail);
			Point head = GetNextPoint();
			pList.Add(head);

			tail.Clear();
			head.Draw();
		}

		internal bool isHitTail()
		{
			var head = pList.Last();

			for (int i = 0; i < pList.Count - 2; i++)
			{
				if (head.isHit(pList[i])) return true;
			}
			return false;
		}

		public Point GetNextPoint()
		{
			Point head = pList.Last();
			Point nextPoint = new Point(head);
			nextPoint.Move(1, Direction);
			return nextPoint;
		}

		internal bool Eat(Point f)
		{
			Point head = GetNextPoint();
			if (head.isHit(f))
			{
				f.dot = head.dot;
				pList.Add(f);
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Control(ConsoleKey key)
		{
			switch (key)
			{
				case ConsoleKey.LeftArrow:
					Direction = Direction.LEFT;
					break;
				case ConsoleKey.UpArrow:
					Direction = Direction.UP;
					break;
				case ConsoleKey.RightArrow:
					Direction = Direction.RIGHT;
					break;
				case ConsoleKey.DownArrow:
					Direction = Direction.DOWN;
					break;
			}
		}
	}
}
