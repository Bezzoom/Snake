using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Figure
	{
		protected List<Point> pList;

		public void Draw()
		{
			foreach (var dot in pList)
			{
				dot.Draw();
			}
		}

		internal bool isHit(Figure snake)
		{
			foreach (var p in pList)
			{
				if (snake.isHit(p)) return true;
			}
			return false;
		}

		private bool isHit(Point point)
		{
			foreach (var p in pList)
			{
				if (p.isHit(point))
					return true;
			}
			return false;
		}
	}
}
