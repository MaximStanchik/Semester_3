using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using List;
using Class2;
using Class3;

namespace ООП7
{
    internal class Program
    {
        public static class StatisticOperation
        {
            public static List<string> sum(List<string> list1, List<string> list2)
            {
                List<string> result = new List<string>();
                Node<string> current1 = list1.head;
                Node<string> current2 = list2.head;
                while (current1 != null && current2 != null)
                {
                    result.addNode(current1.Val + current2.Val);
                    current1 = current1.next;
                    current2 = current2.next;
                }
                return result;
            }
        }
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>();
            list1.addNode(1);
            list1.addNode(2);
            list1.Display();
            List<int> list2 = new List<int>();
            list2.addNode(1);
            list2.addNode(2);
            list2.Display();
            Console.WriteLine(list1 == list2);
            list1 = list1 + list2;
            list1.Display();
            list2--;
            list2.Display();
            list2--;
            list2.Display();
            List<int>.Developer developer1 = new List<int>.Developer();
            List<Car> car1 = new List<Car>();
            Car car = new Car("Tesla", "Electric", "Electric Engine", 500);
            car1.addNode(car);
            Car car2 = new Car("Audi", "Electric", "Electric Engine", 500);
            car1.addNode(car2);
            car1.Display();
            car1.SaveToFile();
        }

    }
}