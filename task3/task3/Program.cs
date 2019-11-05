using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Переменная с неизменяемым значением
            const string constString = "I am Vadim";
            
            //Функция чистая, так как: при одних и тех же значения переменных результат не меняется, а так же срабатывание функции не влияет на какое-либо состояние за пределами
            Console.WriteLine(Sum(4, 7));

            //Функция принимает функцию первого порядка, так как она передается в качестве аргумента и может быть представлена в виду объекта, с помощью делегатов
            Func<int, int, int> funcOfFirstOrder = (a, b) => a + b;

            //Функция высшего порядка, принимает функцию как аргумент и возвращает функцию как аргумент
            FunctionOfHighestOrder(funcOfFirstOrder)(constString, Sum(20, 5));

            //Func<int, Func<int, int>> curryMultiply = multiply.Curry(); В C# отсутствует каррирование
            Func<int, int, int> multiply = (x, y) => x * y;

            //Меморизация работает, если объект, который хранит кэш, находится за пределами функции
            Dictionary<int, int> cache = new Dictionary<int, int>();
            Func<int, int> addTen = (number) =>
            {
                if (!cache.Keys.Contains(number))
                    cache.Add(number, number + 10);
                return cache[number];
            };
            Console.WriteLine(addTen(10));
            Console.WriteLine(addTen(10));
            //Возможна только ленивая инициализация объекта
            Lazy<object> lazyObject = new Lazy<object>();
            //Map
            Enumerable.Range(1, 10).Select(a => "{a}");
            //Reduce
            Enumerable.Range(1, 10).Aggregate(0, (acc, x) => acc + x);
            //Filter
            Enumerable.Range(1, 10).Where(a => a > 5);
        }

        //Лямбда
        private static int Sum(int a, int b) => a + b;

        private static Action<string, int> FunctionOfHighestOrder(Func<int, int, int> sum)
        {
            Console.WriteLine(sum(10, 5));
            return OutputSumWithName;
        }

        private static void OutputSumWithName(string name, int sum)
        {
            Console.WriteLine(@"Hello {0}, sum of this numbers is {1}", name, sum);
        }
    }
}
