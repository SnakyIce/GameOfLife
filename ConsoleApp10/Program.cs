using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace MyLife
{
    public static class Programm
    {
        public static void Main()
        {
            Console.ReadLine();
            Console.SetCursorPosition(0, 0);
            var life = new Life(83, 315);
            Console.ForegroundColor = ConsoleColor.Red;
            while (true)
            {
                var arr = life.LifeSpot();
                Console.SetCursorPosition(0, 0);
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                    var cha = new char[arr.GetLength(0)];
                    for (int x = 0; x < arr.GetLength(0); x++)
                    {
                        if (arr[x, y])
                            cha[x] = '*';
                        else
                            cha[x] = ' ';
                    }
                    Console.WriteLine(cha);
                }

                life.NextLife();
            }
        }
    }
}