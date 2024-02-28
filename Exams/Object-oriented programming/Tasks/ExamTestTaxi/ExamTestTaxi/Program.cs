using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExamTestTaxi
{
    class Location
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public int speed { get; set; }
        public Location(double l,double lon,int speed)
        {
            this.lat = l;
            this.lon = lon;
            this.speed = speed;
        }
    }
    class Taxi
    {
        public string number { get; set; }
        public Location loc { get; set; }
        public enum Status { busy,free}
        public Status status;
        public Taxi(string num,Location local,Status stat)
        {
            this.number = num;
            this.loc = local;
            this.status = stat;
        }
        public void PrintInFile()
        {
            using(StreamWriter sw=new StreamWriter("NearestTaxi.txt", false))
            {
                sw.WriteLine($"Number:{this.number}");
                sw.WriteLine($"Way Length:{Math.Sqrt(Math.Pow(this.loc.lat, 2) + Math.Pow(this.loc.lon, 2))}km");
                sw.WriteLine($"Speed:{this.loc.speed}km/h");
                sw.WriteLine($"Status:{this.status}");
            }
        }
    }
    class Park<T> where T : class
    {
        public List<T> parking = new List<T>();
        public void AddInPark(T elem)
        {
            parking.Add(elem);
        }
        public void DeleteFromPark(T elem)
        {
            parking.Remove(elem);
        }
        public void ClearPark()
        {
            parking.Clear();
        }
        public void Find(Predicate<T>func, T elem)
        {
            if (func(elem))
            {
                Console.WriteLine("This taxi is ours");
            }
            else
            {
                Console.WriteLine("This taxi is not ours");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Taxi taxi1 = new Taxi("CB 41352", new Location(36.5, 42.1, 80), Taxi.Status.busy);
            Taxi taxi2 = new Taxi("JKE A968", new Location(98.3, 20.4, 97), Taxi.Status.free);
            Taxi taxi3 = new Taxi("TZI 7065", new Location(1.4, 89.7, 86), Taxi.Status.busy);
            Taxi taxi4 = new Taxi("GIO 3422", new Location(35.7, 90.7, 69), Taxi.Status.free);
            Taxi taxi5 = new Taxi("TJR O720", new Location(35.9, 91.7, 58), Taxi.Status.busy);
            Park<Taxi> parking = new Park<Taxi>();
            parking.AddInPark(taxi1);
            parking.AddInPark(taxi2);
            parking.AddInPark(taxi3);
            parking.AddInPark(taxi4);
            parking.AddInPark(taxi5);
            parking.DeleteFromPark(taxi3);
            Predicate<Taxi> taxiFind = (Taxi) => parking.parking.Contains(Taxi);
            parking.Find(taxiFind, taxi4);
            IEnumerable<Taxi> length = parking.parking.OrderBy(n => Math.Sqrt(Math.Pow(n.loc.lat, 2) + Math.Pow(n.loc.lon, 2)));
            Taxi mini = length.First();
            mini.PrintInFile();
        }
    }
}
