using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyString
{
    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            String[] tests = new String[testCases];
            for (int i = 0; i < testCases; i++)
            {
                tests[i] = Console.ReadLine();
            }
            foreach (String testCase in tests)
            {
                char[] stringA = testCase.ToCharArray();
                char[] stringB = (char[])stringA.Clone();
                Array.Reverse(stringB);

                bool isFunny = true;
                for (int i = 1; i < testCase.Length; i++)
                {
                    if (Math.Abs(stringA[i] - stringA[i - 1]) != Math.Abs(stringB[i] - stringB[i - 1]))
                    {
                        isFunny = false;
                        break;
                    }
                }
                if (isFunny)
                    Console.WriteLine("Funny");
                else
                    Console.WriteLine("Not Funny");
            }
        }
    }
}
