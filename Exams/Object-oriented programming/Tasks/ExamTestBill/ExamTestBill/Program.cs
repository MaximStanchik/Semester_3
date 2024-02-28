using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExamTestBill
{
    interface INumber
    {
        int Number { get; set; }
    }
    class MuchMoney : Exception
    {
        public MuchMoney() { }
        public override string Message =>"Wallet is overflowed";
    }
    class NoToDeleteFromWallet : Exception
    {
        public NoToDeleteFromWallet() { }
        public override string Message => "No money...";
    }
    class Bill:INumber
    {
        private int number;
        public int Number
        {
            set
            {
                if (value < 0 || (value != 10 && value != 20 && value != 50 && value != 100))
                {
                    throw new Exception("Wrong value of number");
                }
                this.number = value;
            }
            get
            {
                return this.number;
            }
        }
        public Bill(int number)
        {
            this.Number = number;
        }
    }
    class Wallet<T> where T : Bill
    {
        List<T> wallet = new List<T>();
        int summary = 0;
        public void AddMoney(T val)
        {
            wallet.Add(val);
            summary += val.Number;
            if (summary > 100)
            {
                throw new MuchMoney();
            }
        }
        public void DeleteMoney()
        {
            if (wallet.Count == 0)
            {
                throw new NoToDeleteFromWallet();
            }
            wallet.Sort((x,y)=>x.Number.CompareTo(y.Number));
            summary -= wallet.ElementAt(0).Number;
            wallet.RemoveAt(0);
        }
        public void Print()
        {
            using (StreamWriter sw=new StreamWriter("file.txt"))
            {
                sw.WriteLine("======================Contains======================");
                foreach(T elem in wallet)
                {
                    sw.WriteLine(elem.Number+"$");
                }
                sw.WriteLine($"Summary:{summary}$");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bill bill1 = new Bill(20);
            Bill bill2 = new Bill(20);
            Bill bill3 = new Bill(50);
            Bill bill4 = new Bill(10);
            Bill bill5 = new Bill(20);
            Wallet<Bill> wallet = new Wallet<Bill>();
            wallet.AddMoney(bill1);
            wallet.AddMoney(bill2);
            wallet.AddMoney(bill3);
            wallet.AddMoney(bill4);
            wallet.DeleteMoney();
            wallet.DeleteMoney();
            wallet.AddMoney(bill5);
            wallet.DeleteMoney();
            wallet.DeleteMoney();
            wallet.AddMoney(bill1);
            wallet.Print();
        }
    }
}
