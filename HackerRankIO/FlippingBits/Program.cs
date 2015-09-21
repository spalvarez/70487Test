using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlippingBits
{
    class Program
    {
        static void Main(String[] args)
        {
            int numCases = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numCases; i++)
            {
                uint number = Convert.ToUInt32(Console.ReadLine());
                //Just XOR with MaxValue to flip the bits
                uint flippedInt = number ^ UInt32.MaxValue;
                Console.WriteLine(flippedInt);
            }
        }
    }
}
