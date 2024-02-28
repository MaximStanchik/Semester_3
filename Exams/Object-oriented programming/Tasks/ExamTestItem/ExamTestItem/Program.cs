using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTestItem
{
    public interface IEnumerable
    {
        IEnumerator GetEnumerator();
    }
    public interface IEnumerator
    {
        object Current { get; }
        bool MoveNext();
        void Reset();
    }
    class Item
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public double Price { get; set; }
        public Item(string name, int id, double price)
        {
            this.Name = name;
            this.ID = id;
            this.Price = price;
        }
        public override int GetHashCode()
        {
            return this.ID;
        }
        public override string ToString()
        {
            return this.Name;
        }
        public void Print()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine($"Item:{this.Name}");
            Console.WriteLine($"ID:{this.ID}");
            Console.WriteLine($"Price:{this.Price}");
            Console.WriteLine("====================================================");
        }
        public void Skidon()
        {
            this.Price *= 0.5;
        }
    }
    class Shop/*:IEnumerable*/
    {
        public Queue<Item> q = new Queue<Item>();
        public void AddInShop(Item item)
        {
            q.Enqueue(item);
        }
        public void DeleteFromShop()
        {
            q.Dequeue().Print();
        }
        public void ClearShop()
        {
            q.Clear();
        }
        public static Item operator +(Shop shop,Item item1)
        {
            shop.AddInShop(item1);
            return item1;
        }
        public static Item operator -(Shop shop)
        {
            shop.DeleteFromShop();
            return shop.q.Dequeue();
        }
        //private class ShopEnumerator : IEnumerator
        //{
        //    private readonly string[] _data; // локальная копия данных 
        //    private int _position = -1; // текущая позиция в наборе 
        //    public ShopEnumerator(string[] values)
        //    {
        //        _data = new string[values.Length];
        //        Array.Copy(values, _data, values.Length);
        //    }
        //    public object Current
        //    {
        //        get { return _data[_position]; }
        //    }
        //    public bool MoveNext()
        //    {
        //        if (_position < _data.Length - 1)
        //        {
        //            _position++; return true;
        //        }
        //        return false;
        //    }
        //    public void Reset() { _position = -1; }
        //}
        //public IEnumerator GetEnumerator()
        //{
        //    return new ShopEnumerator();
        //}
    }
    class Manager
    {
        public string Name { get; set; }
        public Manager(string name)
        {
            this.Name = name;
        }
        public delegate void Sale();
        public event Sale sale;
        public void Enter()
        {
            if (sale != null)
            {
                sale();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Item item1 = new Item("Beer Heineken", 443312, 3.5);
            Item item2 = new Item("Crackers with taste of onion", 554225, 1.2);
            Item item3 = new Item("Box of cherry tomatoes", 784256, 4.3);
            Item item4 = new Item("Mayonnaise", 331670, 2.8);
            Item item5 = new Item("Box of eggs", 443894, 1.3);
            Item item6 = new Item("Beijing cabbage", 669075, 2.0);
            Item item7 = new Item("Chicken", 554498, 3.4);
            Item item8 = new Item("French potato", 672334, 2.8);
            Item item9 = new Item("Species", 345980, 0.9);
            Item item10 = new Item("Marlboro cigarettes", 666060, 7.3);
            Shop shop = new Shop();
            shop.AddInShop(item1);
            shop.AddInShop(item2);
            shop.AddInShop(item3);
            shop.AddInShop(item4);
            shop.AddInShop(item5);
            shop.AddInShop(item6);
            shop.AddInShop(item7);
            shop.AddInShop(item8);
            shop.AddInShop(item9);
            shop.AddInShop(item10);
            Manager manager = new Manager("Ryan Gosling");
            manager.sale += item1.Skidon;
            manager.Enter();
            manager.sale -= item1.Skidon;
            manager.sale += item5.Skidon;
            manager.Enter();
            manager.sale -= item5.Skidon;
            manager.sale += item8.Skidon;
            manager.Enter();
            shop.DeleteFromShop();
            shop.DeleteFromShop();
            shop.DeleteFromShop();
            shop.DeleteFromShop();
            shop.DeleteFromShop();
            shop.DeleteFromShop();
            shop.DeleteFromShop();
            shop.DeleteFromShop();
            double summary = shop.q.Where(n=>n.Name=="Marlboro cigarettes").Sum(n => n.Price);
            Console.WriteLine($"Marlboro cigarettes cost:{summary}");
        }
    }
}
