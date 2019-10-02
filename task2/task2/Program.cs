using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //==========================================================================================================================================================================
            //Task 2.1
            //Напишите функцию для нахождения заданного значения в упорядоченном массиве целых чисел методом двоичного поиска.
            int[] arrayFirst = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40};
            Random random = new Random();
            int key = random.Next(arrayFirst[0], arrayFirst[arrayFirst.Length - 1]);

            Console.WriteLine("Result task 2.1");
            Console.WriteLine("Normal  = " + SearchNumber(arrayFirst, key));
            Console.WriteLine("Rec = " + SearchNumberRec(arrayFirst, key, 0, arrayFirst.Length));
            //==========================================================================================================================================================================

            Console.WriteLine("\n");

            //==========================================================================================================================================================================
            //Task 2.5
            //Напишите программу для нахождения минимального из чисел, являющихся максимальными в каждой из строк заданной прямоугольной матрицы.
            int[,] arraySecond = { { 1, 2, 3, 4, 5, 6, 7, 8}, { 2, 3, 4, 5, 6, 7, 8, 9}, { 3, 4, 5, 6, 7, 8, 9, 10}, { 4, 5, 6, 7, 8, 9, 10, 11} };
            Console.WriteLine("Result task 2.5");
            Console.WriteLine("Normal = " + MaxMinNumber(arraySecond, 11).ToString());
            Console.WriteLine("Rec = " + MaxMinNumberRec(arraySecond, 0, 0, 11, arraySecond.Length).ToString());
            //==========================================================================================================================================================================
        }

        //Task 2.1
        //==========================================================================================================================================================================

        static int SearchNumber(int[] array, int key)
        {
            int left = 0;
            int right = array.Length;

            while (true)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == key)
                    return mid;

                if (array[mid] > key)
                    right = mid;
                else
                    left = mid + 1;
            }
        }

        static int SearchNumberRec(int[] array, int key, int left, int right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == key)
                return mid;

            else if (array[mid] > key)
                return SearchNumberRec(array, key, left, mid);
            else
                return SearchNumberRec(array, key, mid + 1, right);
        }

        //Task 2.5
        //==========================================================================================================================================================================

        static int MaxMinNumber(int[,] array, int max)
        {
            int maxLine = 0;
            int min = max;

            for(int x = 0; x < array.GetUpperBound(0) + 1; x++)
            {
                for(int y = 0; y < array.Length / (array.GetUpperBound(0) + 1); y++)
                {
                    if(array[x, y] > maxLine)
                    {
                        maxLine = array[x, y];
                    }
                }

                if(min > maxLine)
                {
                    min = maxLine;
                }
            }

            return min;
        }

        static int MaxMinNumberRec(int[,] array, int numberRows, int numberColumn, int min, int arrayLength)
        {
            if (numberRows == array.GetUpperBound(0) && numberColumn == ((array.Length / (array.GetUpperBound(0) + 1)) - 1))
            {
                return min;
            }
            else
            {
                if (numberColumn >= ((array.Length / (array.GetUpperBound(0) + 1)) - 1))
                {
                    if (min > array[numberRows, numberColumn])
                    {
                        min = array[numberRows, numberColumn];
                    }

                    return MaxMinNumberRec(array, numberRows + 1, 0, min, arrayLength);
                }
                else
                {
                    return MaxMinNumberRec(array, numberRows, numberColumn + 1, min, arrayLength);
                }
            }
        }
    }
}
