using System;
using System.Numerics;


namespace ExtraLongFactorials
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            BigInteger factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }
            Console.WriteLine(factorial);
        }
    }
}
