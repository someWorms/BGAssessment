namespace Sorter
{
    /// <summary>
    /// Console client for perform soring algorithm
    /// Handles user input and validation apart from <c>Sorter</c>.
    /// </summary>
    internal class Program
    {
        const int MAX_SIZE = 10;

        static void Main(string[] args)
        {
            int elemCount = GetElementCount();

            if (elemCount == 0)
                Environment.Exit(0);

            double[] data = ReadInputToArray(elemCount);

            ConsoleArrayOutput(data);

            Sort.VerifyAndSort(data);

            ConsoleArrayOutput(data);
        }

        private static int GetElementCount()
        {
            while (true)
            {
                Console.WriteLine("Enter elements (digit from 0 till 10) count for an array. Enter 0 to exit.");

                if (!int.TryParse(Console.ReadLine(), out var count))
                    continue;

                if (count > MAX_SIZE && count < 0)
                    continue;

                return count;
            }
        }

        private static double[] ReadInputToArray(int elemCount)
        {
            double[] data;

            while (true)
            {
                Console.WriteLine("Enter elements as string, using ';' as delimeter.");
                string dataInput = Console.ReadLine() ?? "";

                if (string.IsNullOrEmpty(dataInput) || string.IsNullOrWhiteSpace(dataInput))
                    continue;

                try
                {
                    data = dataInput.Split(';').Select(double.Parse).ToArray();
                }
                catch (FormatException ex)
                {
                    _ = ex;
                    Console.WriteLine("Your input contains non digit value");
                    continue;
                }
                if (data.Length != elemCount)
                {
                    Console.WriteLine("The number of elements to be sorted does not correspond count of elements provided");
                    continue;
                }

                return data;
            }
        }

        private static void ConsoleArrayOutput(IEnumerable<double> data)
        {
            Console.WriteLine();
            foreach (var item in data)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
