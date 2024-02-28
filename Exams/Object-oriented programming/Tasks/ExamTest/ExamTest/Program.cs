using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTest
{
    interface IClearnble
    {
        void Clearn();
    }
    public class Stud
    {
        public string name { get; set; }
        public int groupNum { get; set; }
        public int course { get; set; }
        public enum Special { poit, isit, mobile };
        public int[] exam { get; set; }
        public Special special;
        public Stud(string name, int groupNum, int course, Special spec,int[] examen){
            this.name = name;
            this.groupNum = groupNum;
            this.course = course;
            this.special = spec;
            this.exam = examen;
        }
        public (int max,int min, double aver) GetResults(int[] exam)//2
        {
            var result = (max: exam.Max(), min: exam.Min(), aver: exam.Average());
            return result;
        }
        public void Print()
        {
            string spec;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Group: {groupNum}");
            Console.WriteLine($"Course: {course}");
            Console.WriteLine($"Specialization: {special}");
            Console.Write($"Examination Marks: ");
            foreach (var marks in exam)
            {
                Console.Write(marks + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
        }
    }
    public class Group:IClearnble//3, interface 5
    {
        public List<Stud> collect=new List<Stud>();
        public void AddElem(Stud stud)
        {
            collect.Add(stud);
        }
        public void PrintCollection()
        {
            foreach(var elem in collect)
            {
                elem.Print();
            }
        }
        public void Clearn()//5
        {
            try
            {
                if (collect.Count == 0)
                {
                    throw new Exception("You cannot clear empty collection!!!");
                }
                else
                {
                    collect.Clear();
                    Console.WriteLine($"The collection was cleared! Count:{collect.Count}");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] examStud1 = { 7, 8, 9 };
            int[] examStud2 = { 6, 7, 5 };
            int[] examStud3 = { 9, 8, 8 };
            int[] examStud4 = { 4, 6, 7 };
            int[] examStud5 = { 9, 9, 5 };
            int[] examStud6 = { 9, 7, 9 };
            int[] examStud7 = { 5, 6, 4 };
            int[] examStud8 = { 7, 7, 7 };
            int[] examStud9 = { 6, 4, 9 };
            int[] examStud10 = { 5, 7, 8 };
            Stud stud1 = new Stud("Ayano Aishi", 4, 1, Stud.Special.poit,examStud1);
            Stud stud2 = new Stud("Elias Petersson", 2, 2, Stud.Special.isit, examStud2);
            Stud stud3 = new Stud("Rei Ayanami", 7, 1, Stud.Special.mobile, examStud3);
            Stud stud4 = new Stud("Corey Taylor", 1, 3, Stud.Special.isit, examStud4);
            Stud stud5 = new Stud("Jane Doe", 6, 2, Stud.Special.poit, examStud5);
            Stud stud6 = new Stud("John Doe", 4, 3, Stud.Special.poit, examStud6);
            Stud stud7 = new Stud("Mario Lemieux", 8, 3, Stud.Special.mobile, examStud7);
            Stud stud8 = new Stud("Hanzo Hattori", 5, 1, Stud.Special.poit, examStud8);
            Stud stud9 = new Stud("Musashi Miyamoto", 2, 3, Stud.Special.isit, examStud9);
            Stud stud10 = new Stud("Yae Miko", 1, 3, Stud.Special.isit, examStud10);
            Group group = new Group();
            group.AddElem(stud1);
            group.AddElem(stud2);
            group.AddElem(stud3);
            group.AddElem(stud5);
            group.AddElem(stud10);
            group.PrintCollection();
            IEnumerable<Stud> subgroup =
                group.collect.Where(n => (int)n.special == 0).OrderByDescending(n => n.GetResults(n.exam).aver).Take(1).Concat(group.collect.Where(n => (int)n.special == 1).OrderByDescending(n => n.GetResults(n.exam).aver).Take(1));
            IEnumerable<Stud> newGroup =
                group.collect.Where(n => (int)n.special == 2).OrderByDescending(n => n.GetResults(n.exam).aver).Take(1).Concat(subgroup);
            Console.WriteLine("============Best in each specialization============");
            foreach(var t in newGroup)
            {
                t.Print();
            }
            group.Clearn();
            group.Clearn();
        }
    }
}
