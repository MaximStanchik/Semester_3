using Microsoft.SqlServer.Server;
using IMoveAndSmart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Class2
{
    public abstract class SmartBeing : ISmart
    {
        private protected string name;
        private protected int age;
        public abstract void Think();
        public abstract void Speak();
        public abstract void Display();

    }
    public class Human : SmartBeing
    {
        public Human(string Name, int Age)
        {
            name = Name;
            age = Age;
        }
        public override void Think() => Console.WriteLine("The human is thinking...");
        public override void Speak() => Console.WriteLine("The human is speaking!!!");

        public override void Display()
        {
            Console.WriteLine($"Name:{name} Age:{age}");
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
    public class Transformer : SmartBeing, IMoveable
    {
        private string name;
        private int age;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public Transformer(string Name, int Age)
        {
            name = Name;
            age = Age;
        }
        public override void Think() => Console.WriteLine("The transformer is thinking...");
        public override void Speak() => Console.WriteLine("The  transformer is speaking!!!");
        public void Move()
        {
            Console.WriteLine($"transformer is moving");
        }
        public void Stop()
        {
            Console.WriteLine($"transformer is stoped");
        }
        public void MaxSpeed() => Console.WriteLine("MaxSpeed is 60");
        public void MinSpeed() => Console.WriteLine("Minspeed is 0");
        public override void Display()
        {
            Console.WriteLine($"Name:{name} Age:{age}");
        }
    }
}