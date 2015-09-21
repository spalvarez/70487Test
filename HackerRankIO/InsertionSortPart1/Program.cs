using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortPart1
{
    class Program
    {
        static void insertionSort(int[] ar)
        {
            if (ar.Length == 1)
            {
                Console.WriteLine(ar[0]);
                return;
            }
            int newNum = ar[ar.Length - 1];
            for (int i = ar.Length - 2; i >= 0; i--)
            {
                if (ar[i] > newNum)
                {
                    ar[i + 1] = ar[i];
                    Console.WriteLine(String.Join(" ", ar));
                    if (i == 0)
                    {
                        ar[0] = newNum;
                        Console.WriteLine(String.Join(" ", ar));
                    }

                }

                else
                {
                    ar[i + 1] = newNum;
                    Console.WriteLine(String.Join(" ", ar));
                    break;
                }
            }

        }
        /* Tail starts here */
        static void Main(String[] args)
        {

            int _ar_size;
            _ar_size = Convert.ToInt32(Console.ReadLine());
            int[] _ar = new int[_ar_size];
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
            {
                _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
            }

            insertionSort(_ar);
        }
    }
}
