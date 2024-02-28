using System.Threading.Tasks;
using System.Threading;
using System;
using System.Collections.Concurrent;

namespace SuppliersAndBuyersOfEquipment
{
    internal static class BuyingAndSellingGoods
    {
        static readonly BlockingCollection<string> warehouse = new BlockingCollection<string>();
        public static void PerformTheSeventhTask()
        {
            Task[] tasks = new Task[15];

            for (int i = 0; i < 5; i++)
            {
                int supplierId = i + 1;
                tasks[i] = Task.Run(() => Supplier(supplierId));
            }

            for (int i = 0; i < 10; i++)
            {
                int customerId = i + 1;
                tasks[i + 5] = Task.Run(() => Customer(customerId));
            }

            Task.WaitAll(tasks);

            Console.WriteLine("Все покупатели ушли.");
        }
        static void Supplier(int supplierId)
        {
            Random random = new Random();

            while (true)
            {
                string product = $"Товар {supplierId}-{Guid.NewGuid().ToString().Substring(0, 4)}";

                warehouse.Add(product);

                Console.WriteLine($"Поставщик {supplierId} добавил товар: {product}");

                Thread.Sleep(random.Next(1000, 3000));
            }
        }
        static void Customer(int customerId)
        {
            while (true)
            {
                string product = warehouse.Take();

                Console.WriteLine($"Покупатель {customerId} купил товар: {product}");

                Thread.Sleep(1000);
            }
        }

    }
}