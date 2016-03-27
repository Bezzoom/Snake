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
			// Подготовка окна консоли к запуску, выставляем размеры,
			// очищаем,  ставим цвета по умолчанию в случае перезапуска
			strt:
			Interface Score = new Interface();
			Score.WindowPrepare();

// Создаем экземпляры классов
			Point start = new Point(10, 10, '#');
			Walls walls = new Walls(121, 29);
			Snake snake = new Snake(start, 10, Direction.RIGHT);
			Food food = new Food(120, 30, '#');
			Point f = food.CreateFood();


			// Рисуем всё. Стены, Саму змейку и первую точку
			walls.Draw();
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			snake.Draw();
			Console.ForegroundColor = ConsoleColor.White;
			f.Draw();
			Console.ForegroundColor = ConsoleColor.DarkYellow;

			// Цикл игры
			while (true)
			{
				if (snake.isHitTail() || walls.isHit(snake))	// столкновение со стеной или с собственным хвостом
				{
					Score.MenuDraw();
					WriteGameOver();
					ConsoleKeyInfo key = Console.ReadKey();
					switch(Score.menuAction(key.Key))			// обработка клавиш, после окончания игры
					{
						case MenuAction.UNDEFINED: break;
						case MenuAction.RESTART: goto strt;
						case MenuAction.EXIT: goto quit;
					}
				}
				if (snake.Eat(f))								// зОхавали точечку и выросли, +1 к очкам
				{
					f = food.CreateFood();
					Console.ForegroundColor = ConsoleColor.White;
					f.Draw();
					Console.ForegroundColor = ConsoleColor.DarkYellow;

					Score.PointsUp();
					snake.SpeedUp(Score.score);
				} 
				else											// Не зОхавали точку
				{
					snake.Move();
				}

				Thread.Sleep(snake.Speed);

				if (Console.KeyAvailable)						// Управление змеюкой
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.Control(key.Key);
				}
				Score.Draw();									// Отрисовка интерфейса. Очки и т.д.
			}
			quit:;
		}
		static void Quit()
		{
			Console.SetCursorPosition(3, 2);
			Console.WriteLine("Выходим...");
		}

// TODO идущие нижк фуекции перенести в класс Inerface 
// Отрисовка надписи "Игра окончена" 
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
