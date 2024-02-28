using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExamTestUser
{
    public class User
    {
        private string email;
        private string password;
        public enum Status { signin, signout};
        public Status stat;
        public string Email
        {
            set
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(value);
                if (match.Success)
                {
                    this.email = value;
                }
                else
                {
                    throw new FormatException("Invalid email");
                }
            }
            get
            {
                return this.email;
            }
        }
        protected string Password
        {
            set
            {
                Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
                Match match = regex.Match(value);
                if (match.Success)
                {
                    this.password = value;
                }
                else
                {
                    throw new FormatException("Invalid password");
                }
            }
            get
            {
                return this.password;
            }
        }
        public User(string email,string password,Status status)
        {
            this.email = email;
            this.password = password;
            this.stat = status;
        }
        public override string ToString()
        {
            return this.email;
        }
        public override int GetHashCode()
        {
            return this.password.Length;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public int CompareTo(User user1)
        {
            if (this.email == user1.email)
            {
                return -1;
            }
            return 1;
        }
        public void Print()
        {
            Console.WriteLine($"Email:{this.email}");
            Console.WriteLine($"Password:{this.password}");
            Console.WriteLine($"Status:{this.stat}");
        }
    }
    class WebNet
    {
        public LinkedList<User> github = new LinkedList<User>();
        public void AddUser(User user)
        {
            github.AddFirst(user);
        }
        public void DeleteUser(User user)
        {
            user.stat = User.Status.signout;
            github.Remove(user);
        }
        public void PrintAllUsers()
        {
            Console.WriteLine("========================GitHub Users=========================");
            foreach(var el in github)
            {
                Console.WriteLine("=============================================================");
                el.Print();
                Console.WriteLine("=============================================================");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("navithebloomer@gmail.com","PaNT3r@",User.Status.signin);
            User user2 = new User("jazzl0ver@gmail.com", "MiNi1123", User.Status.signin);
            User user3 = new User("polskamoc@mail.com", "KuRW@Mac", User.Status.signout);
            User user4 = new User("misatoisthebestwaifu@gmail.com","3v4ng3li0n",User.Status.signout);
            User user5 = new User("coregrindentertainment@gmail.com", "cor3101grind", User.Status.signin);
            user1.CompareTo(user2);
            user3.CompareTo(user4);
            user5.CompareTo(user1);
            WebNet webnet = new WebNet();
            webnet.AddUser(user1);
            webnet.AddUser(user2);
            webnet.AddUser(user4);
            webnet.AddUser(user3);
            webnet.AddUser(user5);
            webnet.DeleteUser(user2);
            webnet.PrintAllUsers();
            IEnumerable<User> inSource = webnet.github.Where(n=>n.stat==User.Status.signin);
            foreach(var el in inSource)
            {
                Console.WriteLine($"{el.Email} is on source");
            }
            JsonSerializer jsr = new JsonSerializer();
            using(StreamWriter sw=new StreamWriter("fileJSON.json",false))
            using(JsonWriter jsw=new JsonTextWriter(sw))
            {
                jsr.Serialize(jsw, user1);
                jsr.Serialize(jsw, user2);
                jsr.Serialize(jsw, user3);
                jsr.Serialize(jsw, user4);
                jsr.Serialize(jsw, user5);
            }
        }
    }
}
