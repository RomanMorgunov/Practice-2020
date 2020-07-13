using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAP_WIDTH = 80;
            const int MAP_HEIGHT = 25;

            int score = 0;
            DrawScore(MAP_HEIGHT, score);

            Console.SetWindowSize(MAP_WIDTH, MAP_HEIGHT + 2);
            Console.SetBufferSize(MAP_WIDTH, MAP_HEIGHT + 2);

            Walls walls = new Walls(MAP_WIDTH, MAP_HEIGHT);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.Right);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(MAP_WIDTH, MAP_HEIGHT, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    DrawGameOver();
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                    score++;
                    DrawScore(MAP_HEIGHT, score);
                }
                else
                    snake.Move();

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    snake.HandleKey(Console.ReadKey().Key); 
                }
            }

            Console.ReadKey();
        }

        static void DrawGameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
        }

        static void DrawScore(int mapHeight, int score)
        {
            Console.SetCursorPosition(0, mapHeight + 1);
            Console.Write($"Score: {score}");
        }
    }
}
