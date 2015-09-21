using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(String[] args) {
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine(date.ToString("%HH:mm:ss"));
            }
        }
    }
}
