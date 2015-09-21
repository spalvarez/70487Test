using System;

namespace ConsoleApplication1
{
    class Program
    {

        public static int SimpleArraySum(int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return sum;
        }

        public static void Main(String[] args)
        {
            int arraySize = Convert.ToInt32(Console.ReadLine());
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            int[] numbers = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                numbers[i] = Convert.ToInt32(split_elements[i]);
            }
            Console.WriteLine(SimpleArraySum(numbers));
            Console.ReadKey();
        }
    }
}
