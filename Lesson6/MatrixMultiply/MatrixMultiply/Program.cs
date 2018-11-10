using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixMultiply
{
    class Program
    {
        /// <summary> Размерность матрицы </summary>
        private const int DIMENSION = 100;

        static void Main(string[] args)
        {
            int[,] A = CreateMatrix();
            //чтобы рандом успевал менять значения
            Thread.Sleep(500);
            int[,] B = CreateMatrix();
            int[,] C = Multiply(A, B);

            Print(C);

            Console.ReadKey();
        }

        /// <summary>Вывод мматрицы в консоль</summary>
        /// <param name="c">матрица</param>
        private static void Print(int[,] c)
        {
            for (int i = 0; i < DIMENSION; i++)
            {
                for (int j = 0; j < DIMENSION; j++)
                {
                    Console.Write($"| {c[i,j]} |");
                }
                Console.WriteLine();
            }
        }

        /// <summary>Метод умножения матриц(на матрицах 2х2 считает корректно)</summary>
        /// <param name="a">матрица 1</param>
        /// <param name="b">матрица 2</param>
        /// <returns>результат умножения матриц</returns>
        private static int [,] Multiply(int[,] a, int[,] b)
        {
            int[,] matrix = new int[DIMENSION, DIMENSION];
            int result;
            Parallel.For(0, DIMENSION, row =>
              {
                  for (int col = 0; col < DIMENSION; col++)
                  {
                      result = 0;
                      for (int i = 0; i < DIMENSION; i++)
                      {
                          result += a[row, i] * b[i, col];
                      }

                      matrix[row, col] += result;
                  }
                 
              });
            return matrix;
        }

        /// <summary>Создание матрицы</summary>
        /// <returns>Возвращает матрицу, заполненную числами от 0 до 9 </returns>
        static int[,] CreateMatrix()
        {
            int[,] matrix = new int[DIMENSION, DIMENSION];
            Random random = new Random();
            for (int i = 0; i < DIMENSION; i++)
            {
                for (int j = 0; j < DIMENSION; j++)
                {
                    matrix[i, j] = random.Next(0, 10);
                }
            }
            return matrix;
        }
    }
}
