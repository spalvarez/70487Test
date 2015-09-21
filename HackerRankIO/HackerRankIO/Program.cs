using System;
class Solution
{
    public static int SolveMeSecond(int a, int b)
    {
        return a + b;
    }
    public static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        int val1, val2, sum;
        for (int i = 0; i < t; i++)
        {
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            val1 = Convert.ToInt32(split_elements[0]);
            val2 = Convert.ToInt32(split_elements[1]);
            sum = SolveMeSecond(val1, val2);
            Console.WriteLine(sum);
        }
    }
}