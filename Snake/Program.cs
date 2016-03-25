using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
	class Program
	{
		static void Main(string[] args)
		{
			
			strt: Console.WindowWidth = 120;
			Console.WindowHeight = 31;
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Gray;

			Point start = new Point(10, 10, '#');
			Walls walls = new Walls(121, 29);
			Snake snake = new Snake(start, 10, Direction.RIGHT);
			Food food = new Food(120, 30, '#');
			Point f = food.CreateFood();
			Interface Score = new Interface();
			
			walls.Draw();
			snake.Draw();
			f.Draw();

 			while (true)
			{
				if (snake.isHitTail() || walls.isHit(snake))
				{
					Score.MenuDraw();
					WriteGameOver();
					ConsoleKeyInfo key = Console.ReadKey();
					switch(Score.menuAction(key.Key))
					{
						case MenuAction.EXIT: break;
						case MenuAction.RESTART: goto strt;
					}
				}
				if (snake.Eat(f))
				{
					f = food.CreateFood();
					f.Draw();
					Score.PointsUp();
				} else
				{
					snake.Move();
				}

				Thread.Sleep(100);

				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.Control(key.Key);
				}
				Score.Draw();
			}
		}

		static void WriteGameOver()
		{
			int xOffset = 45;
			int yOffset = 14;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
			WriteText("============================", xOffset, yOffset++);
		}

		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
	}
}
