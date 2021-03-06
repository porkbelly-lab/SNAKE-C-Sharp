using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zmeikaC
{
    class Program
    {
       
            static void Main(string[] args)
        {
         

            Walls walls = new Walls(80, 25);
            walls.Draw();


           

            // tochka
            Point p = new Point(4, 5, '*');
            snake snake = new snake(p, 4, Direction.RIGHT);
            snake.Drow();
            // eda
            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                   
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
        }
    }
}
