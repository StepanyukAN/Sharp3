using System;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;

namespace AsyncFactorialAndSumm
{
    class Program
    {
        static void Main(string[] args)
        {
            //Можно вызвать либо Go(), либо GoAsync()
            Go();
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Я работаю в потоке {Thread.CurrentThread.ManagedThreadId}");
            }
            Console.ReadKey();
        }
        #region Через потоки
        private static void Go()
        {
            Console.WriteLine("Введите число");
            BigInteger number;

            while (!BigInteger.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Неверно введены данные");
                Console.WriteLine("Введите число");
            }
            Thread factorialThread = new Thread(new ParameterizedThreadStart(Factorial));
            Thread summThread = new Thread(new ParameterizedThreadStart(Summ));
            factorialThread.Start(number);
            summThread.Start(number);
        }

        /// <summary>Сумма</summary>
        /// <param name="obj">число</param>
        private static void Summ(object obj)
        {
            int number = int.Parse(obj.ToString());
            Console.WriteLine($"Вычисление суммы запущено в потоке {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(3000);
            BigInteger summ = new BigInteger();
            for (int i = 1; i <= number; i++)
            {
                summ += i;
            }
            Console.WriteLine($"Сумма {number} равна {summ}");
        }

        /// <summary>Факториал</summary>
        /// <param name="obj">число</param>
        private static void Factorial(object obj)
        {
            int number = int.Parse(obj.ToString());
            Console.WriteLine($"Вычисление факториала запущено в потоке {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(3000);
            BigInteger fact = new BigInteger(1);
            if (number != 0)
            {

                for (int i = 1; i <= number; i++)
                {
                    fact *= i;
                }
            }
            Console.WriteLine($"Факториал числа {number} равен {fact}");
        }
        #endregion

        #region Асинхронно
        public static async void GoAsync()
        {
            Console.WriteLine("Введите число");
            BigInteger number;

            while (!BigInteger.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Неверно введены данные");
                Console.WriteLine("Введите число");
            }

            await SummAndFactAsync(number);
           
            
        }

        private static async Task SummAndFactAsync(BigInteger number)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"Вычисление суммы запущено в потоке {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(3000);
                BigInteger summ = new BigInteger();
                for (int i = 1; i <= number; i++)
                {
                    summ += i;
                }
                Console.WriteLine($"Сумма {number} равна {summ}");
            });

            await Task.Run(() =>
            {
                Console.WriteLine($"Вычисление факториала запущено в потоке {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(3000);
                BigInteger fact = new BigInteger(1);
                if (number != 0)
                {

                    for (int i = 1; i <= number; i++)
                    {
                        fact *= i;
                    }
                }
                Console.WriteLine($"Факториал числа {number} равен {fact}");
            });
        }
        #endregion
    }
}
