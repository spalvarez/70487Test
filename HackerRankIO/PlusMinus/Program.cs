using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusMinus
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = Convert.ToInt32(Console.ReadLine());
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            double posNums = 0, negNums = 0, zeroes = 0;
            for (int i = 0; i < arraySize; i++)
            {
                if (Convert.ToInt32(split_elements[i]) > 0)
                {
                    posNums++;
                }
                else if (Convert.ToInt32(split_elements[i]) == 0)
                {
                    zeroes++;
                }
                else if (Convert.ToInt32(split_elements[i]) < 0)
                {
                    negNums++;
                }
            }
            Console.WriteLine(posNums / arraySize);
            Console.WriteLine(negNums / arraySize);
            Console.WriteLine(zeroes / arraySize);
        }
    }
}
