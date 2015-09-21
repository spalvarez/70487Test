using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTutorial
{
    class Program
    {
        static void Main(String[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int arraySize = Convert.ToInt32(Console.ReadLine());
            int[] numArray = new int[arraySize];
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            for (int i = 0; i < arraySize; i++)
            {
                numArray[i] = Convert.ToInt32(split_elements[i]);
            }

            List<int> intList = new List<int>(numArray);
            int result = intList.IndexOf(number);

            Console.WriteLine(result);
        }
    }
}
