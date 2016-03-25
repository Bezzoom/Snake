using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Walls
	{
		List<Figure> wallList;

		public Walls(int mapWidth, int mapHeight)
		{
			wallList = new List<Figure>();

			Hline TopLine = new Hline(0, mapWidth - 2, 3, '#');
			Hline BottomLine = new Hline(0, mapWidth - 2, mapHeight - 1, '#');
			Vline LeftLine = new Vline(0, 3, mapHeight - 1, '#');
			Vline RightLine = new Vline(mapWidth - 2, 3, mapHeight - 1, '#');

			wallList.Add(TopLine);
			wallList.Add(BottomLine);
			wallList.Add(LeftLine);
			wallList.Add(RightLine);
		}

		internal bool isHit(Figure snake)
		{
			foreach (var wall in wallList)
			{
				if (wall.isHit(snake))
				{
					return true;
				}
			}
			return false;
		}

		public void Draw()
		{
			foreach (var wall in wallList)
			{
				wall.Draw();
			}
		}
	}
}
