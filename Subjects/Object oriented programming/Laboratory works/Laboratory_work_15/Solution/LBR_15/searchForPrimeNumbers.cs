using CheckingValues;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    internal static class SearchForPrimeNumbers
    {
        public static async Task PerformFirstTaskAsync()
        {
            int userSpecifiedValue;
            do
            {
                Console.WriteLine("Введите число больше или равное 2, до которого Вы хотите найти все простые числа:");
                userSpecifiedValue = InputValidator.ReadPositiveIntegerInput();

                if (userSpecifiedValue < 2)
                {
                    Console.WriteLine("Вы ввели число меньше двух");
                }
                else
                {
                    Console.WriteLine("Введите, пожалуйста, количество прогонов первого задания: ");
                    int numberOfRuns = InputValidator.ReadPositiveIntegerInput();

                    await Task.Run(() =>
                    {
                        Parallel.For(0, numberOfRuns, _ =>
                        {
                            MeasurePerformance(() =>
                            {
                                List<int> severalPrimeNumbers = FindPrimeNumbers(userSpecifiedValue);

                                Console.WriteLine("Простые числа в диапазоне [2;" + userSpecifiedValue + "]" + ":");

                                foreach (int primeNumber in severalPrimeNumbers)
                                {
                                    Console.Write(primeNumber + ",");
                                }
                                Console.WriteLine();
                            });
                        });
                    });

                    Console.WriteLine("Нажмите любую клавишу, чтобы выйти...");
                    Console.ReadKey();
                }
            } while (userSpecifiedValue < 2);
        }

        public static List<int> PerformAdditionalTask(int userSpecifiedValue)
        {

            bool[] isComposite = new bool[userSpecifiedValue + 1];

            for (int i = 2; i <= Math.Sqrt(userSpecifiedValue); i++)
            {
                if (!isComposite[i])
                {
                    for (int j = i * i; j <= userSpecifiedValue; j += i)
                    {
                        isComposite[j] = true;
                    }
                }
            }

            List<int> primeNumbers = new List<int>();

            MeasurePerformance(() =>
            {
                for (int i = 2; i <= userSpecifiedValue; i++)
                {
                    if (!isComposite[i])
                    {
                        primeNumbers.Add(i);
                    }
                }
            });

            return primeNumbers;
        }

        public static void MeasurePerformance(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action.Invoke();
            stopwatch.Stop();
            Console.WriteLine("Производительность выполнения: " + stopwatch.ElapsedMilliseconds + " мс");
        }

        public static List<int> FindPrimeNumbers(int userSpecifiedValue)
        {
            bool[] isComposite = new bool[userSpecifiedValue + 1];

            Parallel.For(2, (int)Math.Sqrt(userSpecifiedValue) + 1, i =>
            {
                if (!isComposite[i])
                {
                    for (int j = i * i; j <= userSpecifiedValue; j += i)
                    {
                        isComposite[j] = true;
                    }
                }
            });

            List<int> primeNumbers = new List<int>();
            for (int i = 2; i <= userSpecifiedValue; i++)
            {
                if (!isComposite[i])
                {
                    primeNumbers.Add(i);
                }
            }

            return primeNumbers;
        }
    }
}
