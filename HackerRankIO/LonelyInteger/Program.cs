using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LonelyInteger
{
    class Program
    {
        static int lonelyinteger(int[] a)
        {
            int result = 0;
            if (a.Length == 1)
                return a[0];

            while (a.Length > 0)
            {
                List<int> numList = new List<int>(a);
                while (numList.Count > 0)
                {
                    int testNum = numList[0];
                    numList.RemoveAt(0);
                    if (numList.Contains(testNum))
                    {
                        numList.Remove(testNum);
                    }
                    else
                    {
                        result = testNum;
                        break;
                    }
                }
            }
            return result;
        }
        static void Main(String[] args)
        {
            int res;

            int _a_size = Convert.ToInt32(Console.ReadLine());
            int[] _a = new int[_a_size];
            int _a_item;
            String move = Console.ReadLine();
            String[] move_split = move.Split(' ');
            for (int _a_i = 0; _a_i < move_split.Length; _a_i++)
            {
                _a_item = Convert.ToInt32(move_split[_a_i]);
                _a[_a_i] = _a_item;
            }
            res = lonelyinteger(_a);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
