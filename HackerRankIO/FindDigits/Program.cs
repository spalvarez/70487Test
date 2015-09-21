using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDigits
{
    class Program
    {
        static void Main(String[] args)
        {
            int numCases = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numCases; i++)
            {
                string strNumber = Console.ReadLine();
                char[] nums = strNumber.ToCharArray();
                int num = Int32.Parse(strNumber);
                int counter = 0;
                for (int j = 0; j < strNumber.Length; j++)
                {
                    int testNum = Int32.Parse(nums[j].ToString());
                    if (testNum != 0 && num % testNum == 0)
                    {
                        counter++;
                    }
                }

                Console.WriteLine(counter);
            }
        }
    }
}
