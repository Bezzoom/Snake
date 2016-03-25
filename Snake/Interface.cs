using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Interface
	{
		public int score;
		string label;
		string menu;

		MenuAction action;

		public Interface(int score)
		{
			this.score = score;
			this.label = "Ваши очки: ";
			this.menu = "Esc - Выход\tEnter - Повтор";
		}
		public Interface() : this(0) { }

		public void Draw()
		{
			Console.SetCursorPosition(3, 1);
			Console.WriteLine("{0}{1}", label, score);
		}
		public void PointsUp()
		{
			score++;
		}
		public void MenuDraw()
		{
			Console.SetCursorPosition(3, 29);
			Console.WriteLine("{0}", menu);
		}
		public MenuAction menuAction(ConsoleKey key)
		{
			switch (key)
			{
				case ConsoleKey.Enter:
					action = MenuAction.RESTART;
					break;
				case ConsoleKey.Escape:
					action = MenuAction.EXIT;
					break;
			}
			return action;
		}
	}
}
