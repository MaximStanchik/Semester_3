using IMoveAndSmart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class3
{
    public abstract class Transport
    {
        private protected string model;

        public Transport(string Model)
        {
            model = Model;
        }

    }
    public class Car : Transport, IMoveable
    {
        private string typeOfAuto;
        private int year;
        private Engine CarEngine;
        private class Engine
        {
            private string typeOfEngine;
            private int horsePower;
            public Engine(string TypeOfEngine, int HorsePower)
            {
                typeOfEngine = TypeOfEngine;
                horsePower = HorsePower;
            }
            public string TypeOfEngine
            {
                get { return typeOfEngine; }
                set { typeOfEngine = value; }
            }
            public int HorsePower
            {
                get { return horsePower; }
                set { horsePower = value; }
            }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;
                Engine otherEngine = (Engine)obj;
                return typeOfEngine == otherEngine.typeOfEngine && horsePower == otherEngine.horsePower;
            }
        }
        public Car(string Model, string TypeOfAuto, string TypeOfEngine, int HorsePower)
            : base(Model)
        {
            typeOfAuto = TypeOfAuto;
            CarEngine = new Engine(TypeOfEngine, HorsePower);

        }
        public void Move()
        {
            Console.WriteLine($"{model} is movinh");
        }
        public void Stop()
        {
            Console.WriteLine($"{model} is stoped");
        }
        public void MaxSpeed() => Console.WriteLine("MaxSpeed is 60");
        public void MinSpeed() => Console.WriteLine("Minspeed is 0");
        public string TypeOfAuto
        {
            get { return typeOfAuto; }
            set { typeOfAuto = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public override string ToString()
        {
            return $"Type: {typeOfAuto}, Year: {year}, Engine: {CarEngine.TypeOfEngine}, Horsepower: {CarEngine.HorsePower}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Car otherCar = (Car)obj;
            return model == otherCar.model && year == otherCar.Year && this.CarEngine.Equals(otherCar.CarEngine);

        }
    }
}