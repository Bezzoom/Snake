using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Food
	{
		int mapWidth;
		int mapHeight;
		char dot;

		Random random = new Random();
		public Food(int mapWidth, int mapHeight,char dot)
		{
			this.mapHeight = mapHeight;
			this.mapWidth = mapWidth;
			this.dot = dot;
		}

		public Point CreateFood()
		{
			int x = random.Next(2, mapWidth - 1);
			int y = random.Next(5, mapHeight - 4);
			return new Point(x, y, dot);

		}
	}
}
