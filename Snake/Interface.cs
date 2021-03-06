﻿using System;
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

		public Interface()
		{
			this.score = 0;
			this.label = "Ваши очки: ";
			this.menu = "Esc - Выход\tEnter - Повтор";
		}

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
				default:
					action = MenuAction.UNDEFINED;
					break;
			}
			return action;
		}

		public void MenuDraw(char v)
		{
			Console.SetCursorPosition(3, 29);
			Console.WriteLine("{0}", menu);
		}

		public void WindowPrepare()
		{
			Console.WindowWidth = 120;
			Console.WindowHeight = 31;
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
		}

		public void MenuGameOver()
		{
			int xOffset = 45;
			int yOffset = 14;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
			WriteText("============================", xOffset, yOffset++);
		}

		private void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
	}
}
