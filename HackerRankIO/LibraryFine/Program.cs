using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFine
{
    class Program
    {
        static void Main(string[] args)
        {
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            DateTime actualReturnDate = DateTime.Parse(split_elements[1] + "/" + split_elements[0] + "/" + split_elements[2]);
            elements = Console.ReadLine();
            split_elements = elements.Split(' ');
            DateTime expectedReturnDate = DateTime.Parse(split_elements[1] + "/" + split_elements[0] + "/" + split_elements[2]);
            int fine = 0;
            if (actualReturnDate <= expectedReturnDate)
            {
                fine = 0;
            }
            else if (actualReturnDate.Year - expectedReturnDate.Year > 0)
            {
                fine = 10000;
            }
            else if (actualReturnDate.Month - expectedReturnDate.Month > 0)
            {
                fine = (actualReturnDate.Month - expectedReturnDate.Month) * 500;
            }
            else
            {
                fine = (actualReturnDate.Day - expectedReturnDate.Day) * 15;
            }
            Console.WriteLine(fine);
        }
    }
}
