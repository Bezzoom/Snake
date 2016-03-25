using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Vline : Figure
	{
		public Vline(int x, int yTop, int yBottom, char dot)
		{
			pList = new List<Point>();
			for (int i = yTop; i <= yBottom; i++)
			{
				Point obj = new Point(x, i, dot);
				pList.Add(obj);
			}
		}
	}
}
