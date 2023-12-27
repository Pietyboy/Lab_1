using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Tests
{
    public class Task_2Tests
    {


        [Theory]
        [InlineData(-1, 0)]
        public void CurrectMatrixLength(int negativeSize, int zeroSize)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Task_2(negativeSize, negativeSize));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Task_2(zeroSize, zeroSize));
        }

        [Fact]
        public void ValidCountOfNegativeElements()
        {
            var a = new Task_2(10, 10);
            var actualCount = a.FindCountOfNegativeElementsInZeroStroke;

            int expectedCount = 0;
            int[] row = new int[a.GetMatrix.GetLength(1)];

            for (int i = 0; i < a.GetMatrix.GetLength(0); i++)
            {
                for (int j = 0; j <  a.GetMatrix.GetLength(1); j++)
                {
                    row[j] = a.GetMatrix[i, j];
                }

                if (Array.IndexOf(row, 0) != -1)
                {
                    foreach (var item in row)
                    {
                        if (item < 0) expectedCount++;
                    }
                }
            }

            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public void ValidSedlPoints()
        {
            var a = new Task_2(10,10);
            List<Point> expectedList = new();

            List<Point> actualList = a.FindSedlPoints();

            int[] row = new int[a.GetMatrix.GetLength(1)];
            int[] col = new int[a.GetMatrix.GetLength(0)];
            int minPointInRow;
            int indexMinPointInRow;

            for (int i = 0; i < a.GetMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetMatrix.GetLength(1); j++)
                {
                    row[j] = a.GetMatrix[i, j];
                }
                minPointInRow = row.Min();
                indexMinPointInRow = Array.IndexOf(row, minPointInRow);

                for (int j = 0; j < a.GetMatrix.GetLength(1); j++)
                {
                    if (a.GetMatrix[i, j] == minPointInRow)
                    {
                        for (int l = 0; l < a.GetMatrix.GetLength(0); l++)
                        {
                            col[l] = a.GetMatrix[l, j];

                        }
                        if (a.GetMatrix[i, j] == col.Max())
                        {
                            expectedList.Add(new Point(i, j));
                        }
                    }
                }
            }
            Assert.Equal(expectedList.Count, actualList.Count);
        }
    }
}
