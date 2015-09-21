using System;

namespace DiagonalDifference
{
    class Solution
    {
        static void Main(String[] args)
        {
            int matrixSize = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            //Read each row
            for (int i = 0; i < matrixSize; i++)
            {
                String elements = Console.ReadLine();
                String[] split_elements = elements.Split(' ');
                //read each column in the line
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = Convert.ToInt32(split_elements[j]);
                }
            }
            //Compute the sum
            int sum1 = 0;
            int sum2 = 0;
            for(int i = 0; i < matrixSize; i++)
            {
                sum1 += matrix[i, i];
                sum2 += matrix[i, matrixSize - i - 1];
            }
            Console.WriteLine(Math.Abs(sum1 - sum2));
            Console.ReadLine();
        }
    }
}
