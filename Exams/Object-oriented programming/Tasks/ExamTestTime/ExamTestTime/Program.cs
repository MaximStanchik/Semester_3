using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace ExamTestTime
{
    public class Time
    {
        //1
        private int hours;
        public int Hours
        {
            set
            {
                if (value < 0 || value > 24)
                {
                    throw new Exception("Wrong value of hours");
                }
                hours = value;
            }
            get
            {
                return hours;
            }
        }
        private int minutes;
        public int Minutes
        {
            set
            {
                if (value < 0 || value >= 60)
                {
                    throw new Exception("Wrong value of minutes");
                }
                minutes = value;
            }
            get
            {
                return minutes;
            }
        }
        private int seconds;
        public int Seconds
        {
            set
            {
                if (value < 0 || value >= 60)
                {
                    throw new Exception("Wrong value of seconds");
                }
                seconds = value;
            }
            get
            {
                return seconds;
            }
        }
        public Time(int hours, int minutes, int seconds)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }
        public int CompareTo(Time t1)//2
        {
            if (Hours == t1.Hours && Minutes == t1.Minutes)
            {
                return 0;
            }
            if (Hours > t1.Hours)
            {
                return 1;
            }
            else return -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Time time1 = new Time(14, 31, 56);
            Time time2 = new Time(18, 52, 45);
            Time time3 = new Time(3, 45, 24);
            Time time4 = new Time(20, 9, 17);
            Time time5 = new Time(6, 32, 56);
            Time time6 = new Time(1, 25, 9);
            //2
            Console.WriteLine(time1.CompareTo(time2));
            //3
            Time[] timeArr = { time1, time2, time3, time4, time5, time6 };
            IEnumerable<Time> Night = timeArr.OrderBy(n => n.Hours).Where(n => n.Hours >= 0 && n.Hours <= 5);
            IEnumerable<Time> Morning = timeArr.OrderBy(m => m.Hours).Where(m => m.Hours >= 6 && m.Hours <= 12);
            IEnumerable<Time> Day = timeArr.OrderBy(p => p.Hours).Where(p => p.Hours >= 13 && p.Hours <= 17);
            IEnumerable<Time> Evening = timeArr.OrderBy(k => k.Hours).Where(k => k.Hours >= 18 && k.Hours <= 23);
            using (StreamWriter fs = new StreamWriter("fileTime.txt", false))
            {
                fs.WriteLine("------------------------Night------------------------");
                foreach (var elem in Night)
                {
                    fs.WriteLine($"{elem.Hours}h{elem.Minutes}m{elem.Seconds}s");
                }
                fs.WriteLine("-----------------------Morning-----------------------");
                foreach (var elem in Morning)
                {
                    fs.WriteLine($"{elem.Hours}h{elem.Minutes}m{elem.Seconds}s");
                }
                fs.WriteLine("-------------------------Day-------------------------");
                foreach (var elem in Day)
                {
                    fs.WriteLine($"{elem.Hours}h{elem.Minutes}m{elem.Seconds}s");
                }
                fs.WriteLine("-----------------------Evening-----------------------");
                foreach (var elem in Evening)
                {
                    fs.WriteLine($"{elem.Hours}h{elem.Minutes}m{elem.Seconds}s");
                }
            }
            //4
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(@"FileJSON.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, time2);
            }
        }
    }
}
