using System;
using System.Linq;

namespace Lab_1 
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine();
            Console.WriteLine("Часть 2");
            Console.WriteLine("Введите количество строк:");
            int N = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количесвто столбцов:");
            int M = int.Parse(Console.ReadLine());

            Task_2 matrix = new(N, M);
            Console.WriteLine("Исходная матрица:");
            PrintMatrix(matrix.GetMatrix);

            PrintList(matrix.FindSedlPoints());
        }

        static void PrintVector(IEnumerable<double> vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0,3}", "[" + matrix[i, j] + "]"));
                }
                Console.WriteLine();
            }
        }

        static void PrintList(List<Point> list)
        {
            Console.WriteLine("Седловые точки:");
            for(int i = 0; i< list.Count;i++)
            {
                Console.WriteLine("[" + list[i].GetX + ", " + list[i].GetY + "]");
            }
        }
    }
}