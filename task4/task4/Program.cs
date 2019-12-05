using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listWithNumber = new List<int>() { 5 };
            Console.WriteLine(Modificate(listWithNumber, (a) => a[0] * a[0]));
            Modificate(listWithNumber, (a) => a[0] * a[0] * a[0]);
            Modificate(listWithNumber, (a) => -a[0]);

            List<int> listOfNumbers = new List<int>() { 1, 534, 12, 7, 4, 0, 456 };
            foreach (var element in Filter<int>(listOfNumbers, (x) => x > 13).ToList())
                Console.Write(element + " ");

            Console.WriteLine("\n" + Compose<int>(10, (x) => x * x, (x) => x * x * x));
        }

        private static int Modificate(List<int> argument, Func<List<int>, int> function)
        {
            return function(argument);
        }

        private static IEnumerable<T> Filter<T>(IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(x => predicate(x));
        }

        private static T Compose<T>(T argument, Func<T, T> firstFunction, Func<T, T> secondFunction)
        {
            return secondFunction(firstFunction(argument));
        }
    }
}
