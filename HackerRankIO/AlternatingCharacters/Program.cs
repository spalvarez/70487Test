using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternatingCharacters
{
    class Program
    {
        public static void findDeletions(char[] testChars)
        {
            int delCount = 0;
            for (int i = 0; i <= testChars.Length - 2; i++)
            {
                if (testChars[i] == testChars[i + 1])
                {
                    delCount++;
                }
            }
            Console.WriteLine(delCount);
        }

        static void Main(String[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                findDeletions(Console.ReadLine().ToCharArray());
            }
        }
    }
}
