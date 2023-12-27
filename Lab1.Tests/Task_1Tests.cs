using Lab_1;


namespace Lab_1.Tests
{
    public class Task_1Tests
    {

        [Theory]
        [InlineData(-1, 0)]
        public void CurrectVectorLength(int negativeSize, int zeroSize)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Task_1(negativeSize));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Task_1(zeroSize));
        }

        [Fact]
        public void PositiveElementsInVector()
        {
            var a = new Task_1(100);
            Assert.Contains(a.Vector, x => x > 0);
        }

        [Fact]
        public void ValidMultiplication()
        {
            var a = new Task_1(100);
            Assert.Equal(a.MultiplicationPositiveEl(), a.Vector.Where(i => i > 0).Aggregate((x, y) => x*y));
        }

        [Fact]
        public void IsSumValid()
        {
            var a = new Task_1(100);
            var arr = a.Vector.ToArray();

            var minIndex = Array.IndexOf(arr, arr.Min());

            var result = a.SumBeforeMin();

            if (minIndex == 0)
            {
                Assert.Equal(0, result);
            }

            var sum = arr.Take(minIndex).Sum();

            Assert.Equal(result, sum);
        }

        [Fact]
        public void IsSortValid()
        {
            var a = new Task_1(10);
            double[] arr = a.Vector.ToArray();

            double[] evenElements = new double[arr.Length % 2 == 0 ? arr.Length / 2 : arr.Length / 2 + 1];
            double[] oddsElements = new double[arr.Length / 2];

            int j = 0;
            int l = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    evenElements[j] = arr[i];
                    j++;
                }
                if (i % 2 != 0)
                {
                    oddsElements[l] = arr[i];
                    l++;
                }
            }

            j = 0;
            l = 0;

            Array.Sort(evenElements);
            Array.Sort(oddsElements);

            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    arr[i] = evenElements[j];
                    j++;
                }

                if (i % 2 != 0)
                {
                    arr[i] = oddsElements[l];
                    l++;
                }
            }

            Assert.Equal(a.Sort(), arr);
        }
    }
}