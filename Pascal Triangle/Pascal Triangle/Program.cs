using System;
using System.Linq;
using System.Collections.Generic;


namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumber = int.Parse(Console.ReadLine());

            var triangle = new long[inputNumber][];

            for (int rows = 0; rows < inputNumber; rows++)
            {
                triangle[rows] = new long[rows + 1];
            }

            for (int row = 0; row < inputNumber; row++)
            {
                var array = new long[row + 1];

                for (int col = 0; col < array.Length; col++)
                {
                    if (col == 0 || col == array.Length - 1)
                    {
                        array[col] = 1;
                    }
                    else
                    {
                        array[col] = triangle[row - 1][col] + triangle[row - 1][col - 1];
                    }
                    triangle[row] = array;
                }
            }

            foreach (var arr in triangle)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
