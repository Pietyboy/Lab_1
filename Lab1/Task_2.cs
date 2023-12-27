using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    // Часть 2

    /*Дана целочисленная прямоугольная матрица. Определить:
              количество отрицательных элементов в тех строках, которые содержат хотя бы один нулевой элемент
              номера строк и столбцов всех седловых точек матрицы.*/

    /*Примечание
    Матрица А имеет седловую точку Ау, если Аy является минимальным элементом в t-й строке и максимальным — в j-м столбце.*/


    public class Task_2
    {
        private readonly int[,] matrix;
        public Task_2(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0) throw new ArgumentOutOfRangeException(nameof(rows) + "or" + nameof(cols));

            matrix = new int[rows, cols];
            var rnd = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(-10, 10);
                }
            }
        }

        public int[,] GetMatrix
        {
            get
            {
                return matrix;
            }
        }

        public int FindCountOfNegativeElementsInZeroStroke()
        {
            int counter;
            int countOfElements = 0;
            bool zeroElement;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                counter = 0;
                zeroElement = false;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0) { counter++; }
                    if (!zeroElement && matrix[i, j] == 0) { zeroElement = true; }
                }

                if (zeroElement)
                {
                    /*Console.WriteLine("В " + i + " строке находится " + counter + " отрицательных элементов");*/
                    countOfElements += counter;
                }
            }

            return countOfElements;
        }

        public List<Point> FindSedlPoints()
        {
            List<Point> result = new();

            int min_in_row;
            int max_in_col;
            int col;

            bool noPoints = true;
            bool currectPoint;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                min_in_row = matrix[i, 0];
                max_in_col = min_in_row;
                col = 0;
                currectPoint = true;

                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (min_in_row > matrix[i, j])
                    {
                        min_in_row = matrix[i, j];
                        max_in_col = min_in_row;
                        col = j;
                    }
                }
                if (col != matrix.GetLength(1))
                {
                    for (int j = col + 1; j < matrix.GetLength(1); j++)
                    {
                        if (min_in_row == matrix[i, j])
                        {
                            for (int l = 0; l < matrix.GetLength(0); l++)
                            {
                                if (max_in_col < matrix[l, j])
                                {
                                    currectPoint = false;
                                    break;
                                }
                            }
                            if (currectPoint)
                            {
                                noPoints = false;
                                /*Console.WriteLine("Седловая точка находится в строке " + row + " в столбце " + col);*/
                                result.Add(new Point(i, j));
                            }
                        }
                    }
                }

                for (int l = 0; l < matrix.GetLength(0); l++)
                {
                    if (max_in_col < matrix[l, col])
                    {
                        currectPoint = false;
                        break;
                    }
                }
                if (currectPoint)
                {
                    noPoints = false;
                    /*Console.WriteLine("Седловая точка находится в строке " + row + " в столбце " + col);*/
                    result.Add(new Point(i, col));
                }
            }
            if (noPoints)
            {
                Console.WriteLine("Седловых точек в матрице нет");
            }
            return result;
        }
    }

    public class Point
    {
        private int x;
        private int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetX
        {
            get { return x; }
        }

        public int GetY
        {
            get { return y; }
        }
    }
}
