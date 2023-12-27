namespace Lab_1
{
    // Часть 1

    // в массиве из N вещественных элементов
    // 1 - произведение положительных элементов
    // 2 - сумму элементов массива, расположенных до минимального элемента
    // упорядочить по возрастанию отдельно элементы, стоящие на четных местах, и элементы, стоящие на нечетных местах
    public class Task_1
    {
        private readonly double[] arr;

        public Task_1(int size)
        {
            if (size < 0 || size == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            var rnd = new Random();

            arr = new double[size];

            for (int i = 0; i < size; i++)
            {
                arr[i] = Math.Round((rnd.NextDouble() * 2 - 1) * 10, 2);
                Console.WriteLine("[" + i + "]: " + arr[i]);
            }
        }

        public IReadOnlyList<double> Vector
        {
            get { return arr; }
        }

        public double MultiplicationPositiveEl()
        {
            double mult = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    mult *= arr[i];
                }
            }
            return mult;
        }

        public double SumBeforeMin()
        {
            double sum = 0;
            double min = Array.IndexOf(arr, arr.Min());
            if (min == 0)
            {
                return sum;
            }
            for (int i = 0; i < min; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        public double[] Sort()
        {
            double temp = 0;

            for (int i = 0; i < arr.Length - 2; i ++)
            {
                for (int j = i; j < arr.Length; j += 2)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }

    }
}
