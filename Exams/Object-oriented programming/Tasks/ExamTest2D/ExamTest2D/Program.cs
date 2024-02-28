using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTest2D
{
    class DeleteException : Exception
    {
        public DeleteException()
        {

        }
        public override string Message => "No points to delete";
    }
    class Point2D
    {
        public delegate void Changer();
        public event Changer Change;
        public void Enter()
        {
            if (Change != null)
            {
                Change();
            }
        }
        public double X { get; set; }
        public double Y { get; set; }
        public Point2D(double x,double y)
        {
            this.X = x;
            this.Y = y;
        }
        public void ChangeSign()
        {
            if (this.X > 0 && this.Y < 0) {
                this.X = -this.X;
            }
            else if (this.X < 0 && this.Y > 0)
            {
                this.Y = -this.Y;
            }
            else
            {
                this.X = -this.X;
                this.Y = -this.Y;
            }
        }
    }
    class Path2D
    {
        public double pathXY { get; set; }
        public Path2D(Point2D point2D1,Point2D point2D2)
        {
            this.pathXY = Math.Sqrt(Math.Pow(point2D2.X - point2D1.X, 2) + Math.Pow(point2D2.Y - point2D1.Y, 2));
        }
        List<Point2D> path = new List<Point2D>();
        public Path2D(List<Point2D> path)
        {
            this.path=path;
        }
        public void Add(Point2D p2d)
        {
            path.Add(p2d);
        }
        public void Delete(Point2D p2d)
        {
            if (path.Count == 0)
            {
                throw new DeleteException();
            }
            path.Remove(p2d);
        }
        public void Clear()
        {
            path.Clear();
        }
        public static bool operator ==(Path2D p1,Path2D p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Path2D p1, Path2D p2)
        {
            return p1.Equals(p2);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public (int f,int s,int t,int ff) CountPoints(List<Point2D> listing)
        {
            int q1, q2, q3, q4;
            q1 = q2 = q3 = q4 = 0;
            foreach(var i in listing)
            {
                if (i.X > 0 && i.Y > 0) q1++;
                else if (i.X < 0 && i.Y > 0) q2++;
                else if (i.X < 0 && i.Y < 0) q3++;
                else if (i.X > 0 && i.Y < 0) q4++;
            }
            Console.WriteLine($"{q1} {q2} {q3} {q4}");
            return (q1, q2, q3, q4);
        }
    }
    static class Reflector
    {
        public static void ConstructorsAndFields(object thisclass)
        {
            Type t1 = thisclass.GetType();
            ConstructorInfo[] ci = t1.GetConstructors();
            FieldInfo[] fi = t1.GetFields();
            Console.WriteLine("====================Constructors=======================");
            foreach (var el in ci)
            {
                Console.WriteLine(el.Name);
            }
            Console.WriteLine("=======================Fields==========================");
            foreach (var el in fi)
            {
                Console.WriteLine(el.Name);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point2D point2D1 = new Point2D(32, 41);
            Point2D point2D2 = new Point2D(-43, 54);
            Point2D point2D3 = new Point2D(-69, -1);
            Point2D point2D4 = new Point2D(90, -87);
            Path2D path2d1 = new Path2D(point2D1, point2D2);
            Path2D path2d2 = new Path2D(point2D1, point2D3);
            Path2D path2d3 = new Path2D(point2D1, point2D4);
            Path2D path2d4 = new Path2D(point2D4, point2D2);
            List<Point2D> l = new List<Point2D>();
            Path2D list2d = new Path2D(l);
            List<Path2D> paths = new List<Path2D>();
            list2d.Add(point2D1);
            list2d.Add(point2D2);
            list2d.Add(point2D3);
            list2d.Add(point2D4);
            list2d.Delete(point2D4);
            list2d.CountPoints(l);
            paths.Add(path2d1);
            paths.Add(path2d2);
            paths.Add(path2d3);
            paths.Add(path2d4);
            point2D1.Change += point2D1.ChangeSign;
            point2D1.Enter();
            Console.WriteLine("===========My Points=============");
            foreach (var el in l)
            {
                Console.WriteLine($"({el.X};{el.Y})");
            }
            Console.WriteLine("===========My Paths=============");
            foreach (var el in paths)
            {
                Console.WriteLine($"{el.pathXY}");
            }
            Reflector.ConstructorsAndFields(path2d1);
        }
    }
}
