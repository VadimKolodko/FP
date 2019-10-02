using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 1.1
            //Треугольник Паскаля.
            Console.WriteLine("Result task 1.1 = " + PascalTriangle(1, 2));

            //Task 1.2
            //Подсчет комбинаций.
            Console.WriteLine("Result task 1.2 = " + NumberOfSums(4));
        }

        //Task 1.1
        //=========================================================================
        private static int PascalTriangle(int k, int n)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        private static int Factorial(int factor)
        {
            if (factor == 0)
                factor++;
            return factor == 1 ? factor : factor * Factorial(factor - 1);
        }

        //Task 1.2
        //=========================================================================
        private static int NumberOfSums(int number)
        {
            return number <= 1 ? 0 : number / 2 + (number == 2 ? 0 : 1);
        }
    }
}
