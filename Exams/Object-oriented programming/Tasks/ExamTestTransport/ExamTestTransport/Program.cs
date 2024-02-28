using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTestTransport
{
    interface IAirable
    {
        void Fly();
        void Check();
    }
    public interface IAirHostess
    {
        void Check();
    }
    abstract class Transport
    {
        protected string brand { get; set; }
        public TimeSpan time { get; set; }
        protected string color { get; set; }
        public string point { get; set; }
    }
    class Air : Transport,IAirable,IAirHostess
    {
        public int Speed { get; set; }
        public int CountOfPassengers { get; set; }
        public enum Status { fly,ready,stop };
        internal Status statusquo;
        public Air(string brand,string color, TimeSpan time, string point, int speed,int cop,Status status)
        {
            this.brand = brand;
            this.color = color;
            this.time = time;
            this.point = point;
            this.Speed = speed;
            this.CountOfPassengers = cop;
            this.statusquo = status;
        }
        public void Fly()
        {
            switch (this.statusquo)
            {
                case Status.fly: Console.WriteLine("Flying");break;
                default: throw new Exception("Wrong status");
            }
        }
        public void Check()
        {
            if (this.statusquo == Status.ready && this.CountOfPassengers > 0 && this.Speed > 0)
            {
                this.statusquo = Status.fly;
            }
            if (this.CountOfPassengers == 0 && this.Speed == 0)
            {
                this.statusquo = Status.stop;
            }
            if (this.CountOfPassengers > 0 && this.Speed == 0)
            {
                this.statusquo = Status.ready;
            }
        }
        void IAirHostess.Check()
        {
            if (this.CountOfPassengers >= 20 && this.CountOfPassengers <= 100)
            {
                Console.WriteLine("Ready");
            }
        }
        public void Print()
        {
            Console.WriteLine($"Brand:{this.brand}");
            Console.WriteLine($"Color:{this.color}");
            Console.WriteLine($"Time:{this.time}");
            Console.WriteLine($"Move to:{this.point}");
            Console.WriteLine($"Passengers:{this.CountOfPassengers}");
            Console.WriteLine($"Speed:{this.Speed}");
            Console.WriteLine($"Status:{this.statusquo}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================Welcome to Zhmysh Flex-Air==========================");
            Random randomizer = new Random();
            Air air1 = new Air("Tulip", "White-Red-White", new TimeSpan(randomizer.Next(0, 23), randomizer.Next(0, 60), 0), "Amsterdam", 100, 32, Air.Status.fly);
            Air air2 = new Air("Sakura", "Pink-white-red", new TimeSpan(randomizer.Next(0, 23), randomizer.Next(0, 60), 0), "Osaka", 320, 80, Air.Status.ready);
            Air air3 = new Air("Cornflower", "White-Blue", new TimeSpan(randomizer.Next(0, 23), randomizer.Next(0, 60), 0), "Tallin", 0, 50, Air.Status.fly);
            Air air4 = new Air("Maple Leaf", "Black-Red-White", new TimeSpan(randomizer.Next(0, 23), randomizer.Next(0, 60), 0), "Toronto", 500, 0, Air.Status.stop);
            Air air5 = new Air("Lily", "White-Yellow-Blue", new TimeSpan(randomizer.Next(0, 23), randomizer.Next(0, 60), 0), "Paris", 0, 0, Air.Status.fly);
            Air air6 = new Air("Orchid", "White-Purple", new TimeSpan(randomizer.Next(0, 23), randomizer.Next(0, 60), 0), "Singapoore", 0, 100, Air.Status.ready);
            List<Air> airlines = new List<Air>();
            air1.Check();
            air2.Check();
            air3.Check();
            air4.Check();
            air5.Check();
            air6.Check();
            airlines.Add(air1);
            airlines.Add(air2);
            airlines.Add(air3);
            airlines.Add(air4);
            airlines.Add(air5);
            airlines.Add(air6);
            foreach (var zhmyshki in airlines)
            {
                Console.WriteLine("=====================================================");
                zhmyshki.Print();
                Console.WriteLine("=====================================================");
            }
            air1.Fly();
            air2.Fly();
            ((IAirHostess)air3).Check();
            ((IAirHostess)air4).Check();
            ((IAirHostess)air5).Check();
            ((IAirHostess)air6).Check();
            int flyingCount = airlines.Count(n => n.statusquo == Air.Status.fly);
            double flyingAverageSpeed = airlines.Where(n=>n.statusquo==Air.Status.fly).Average(n => n.Speed);
            Console.WriteLine($"{flyingCount} planes are flying");
            Console.WriteLine($"Their average speed: {flyingAverageSpeed}");
        }
    }
}
