using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Hline : Figure
	{
		public Hline(int xLeft, int xRight, int y, char dot)
		{
			pList = new List<Point>();
			for (int i = xLeft; i <= xRight; i++)
			{
				Point obj = new Point(i, y, dot);
				pList.Add(obj);
			}
		}
	}
}
