using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtopianTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            int[] tests = new int[testCases];
            int treeHeight = 1;
            for (int i = 0; i < testCases; i++)
            {
                tests[i] = Convert.ToInt32(Console.ReadLine());
            }

            foreach (int testCase in tests)
            {
                treeHeight = 1;
                if (testCase > 0)
                {
                    for (int i = 0; i < testCase; i++)
                    {
                        if (i % 2 == 0)
                        {
                            treeHeight *= 2;
                        }
                        else
                        {
                            treeHeight++;
                        }
                    }
                }
                Console.WriteLine(treeHeight);
            }
        }
    }
}
