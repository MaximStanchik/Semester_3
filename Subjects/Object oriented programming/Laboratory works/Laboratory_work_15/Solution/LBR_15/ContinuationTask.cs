using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinuationTask
{
    internal static class MethodsForImplementingTwoVariantsOfTheTask
    {
        public static void PerformFourthTaskInFirstVariant()
        {
            Task<int> initialTask = Task.Run(() => ComputeValue());

            initialTask.Wait();

            int result = initialTask.GetAwaiter().GetResult();
            Console.WriteLine($"Результат: {result}");

            Console.WriteLine("Основная задача завершена.");

            Console.ReadLine();
        }
        public static void PerformFourthTaskInSecondVariant()
        {
            Task<int> initialTask = Task.Run(() => ComputeValue());

            initialTask.Wait();

            int result = initialTask.GetAwaiter().GetResult();
            Console.WriteLine($"Результат: {result}");

            Console.WriteLine("Основная задача завершена.");

            Console.ReadLine();
        }
        static int ComputeValue()
        {
            Console.WriteLine("Выполняется вычисление...");
            Task.Delay(2000).Wait();
            return 42;
        }
    }
}
