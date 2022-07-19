using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLife
{
    internal class Life
    {
        public readonly int rows;
        public readonly int columns;
        private bool[,] arr;
        public Life(int rows, int columns)      //первоначальное построение
        {
            this.rows = rows;
            this.columns = columns;
            arr = new bool[columns, rows];
            Random rand = new Random();
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    arr[x, y] = rand.Next(5) == 0;
                }
            }
        }
        public bool[,] LifeSpot()       //выявление всех клеток которые живы
        {
            var result = new bool[columns, rows];
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    result[x, y] = arr[x, y];
                }
            }
            return result;
        }
        public void NextLife()              //генерация новых клеток исходя из состояния старых
        {
            var newArr = new bool[columns, rows];
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    var sosed = CheckSosed(x, y);
                    var alive = arr[x, y];
                    if (!alive && sosed == 3)
                    {
                        newArr[x, y] = true;
                    }
                    else if (alive && (sosed < 2 || sosed > 3))
                    {
                        newArr[x, y] = false;
                    }
                    else
                    {
                        newArr[x, y] = arr[x, y];
                    }
                }
            }
            arr = newArr;

        }
        private int CheckSosed(int x, int y)            //проверка соседей клеток и по бокам и по диагонали
        {
            int count = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    var col = (x + i + columns) % columns;
                    var row = (y + j + rows) % rows;
                    var curentspot = col == x & row == y;
                    var alive = arr[col, row];
                    if (alive && !curentspot)
                    {
                        count++;
                    }

                }
            }
            return count;
        }
    }
}

