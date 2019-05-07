using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static Random rnd = new Random();

        static int [,] MakeRandomArr(int n)
        {
            int[,] arr = new int[n,n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    arr[i, j] = rnd.Next(-10, 10);
            return arr;
        }

        static int[,] MakeUsersArr(int n)
        {
            int[,] arr = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    arr[i, j] = ReadAnswer();
                }

            return arr;
        }

        static int[] FindRows(int[,]arr)
        {
            bool ok = false;
            int[] res = new int[0];
            for(int i=0;i<arr.GetLength(0);i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j] == arr[i, 0]) ok = true;
                    else
                    {
                        ok = false;
                        break;
                    }
                if (ok)
                {
                    Array.Resize(ref res, res.Length + 1);
                    res[res.Length - 1] = i;
                }
            }
            return res;
        }

        static void Main(string[] args)
        {
            int n = 0;
            int m = 0;
            int[,] arr = new int[0, 0];
            int[] result = new int[0];
            do
            {
                Console.WriteLine("Введите порядок матрицы");
                n = ReadAnswer();
            } while (n < 0);

            do
            {
                Console.WriteLine(@"1. Формирование матрицы с клавиатуры
2. Формирование матрицы датчиком случайных чисел");
                m = ReadAnswer();
            } while (!(m == 1 || m == 2));

            if (m == 1) arr = MakeUsersArr(n);
            else arr = MakeRandomArr(n);

            result = FindRows(arr);

            if (result.Length != 0)
                for (int i = 0; i < result.Length; i++)
                    Console.Write(result[i] + " ");
            else Console.WriteLine("Очевидно, строк с одинаковыми элементами нет");

        }

        static int ReadAnswer()
        {
            int a = 0;
            bool ok = false;
            do
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                    ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Пожалуйста, введите целое число.");
                    ok = false;
                }
            } while (!ok);
            return a;
        }

    }
}
