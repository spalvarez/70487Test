using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staircase
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = Convert.ToInt32(Console.ReadLine());
            StringBuilder message = new StringBuilder("");
            for (int i = 0; i < height; i++)
            {
                message.Append("#");
                string output = String.Format("{0," + height + "}", message.ToString());
                Console.WriteLine(output);
            }
            Console.ReadLine();
        }
    }
}
