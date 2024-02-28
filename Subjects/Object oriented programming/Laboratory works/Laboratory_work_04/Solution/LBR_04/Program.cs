using System;

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car { Name = "Toyota Camry", MaxSpeed = 200, NumberOfDoors = 4 };
        Train train = new Train { Name = "Sapsan", MaxSpeed = 300, NumberOfCars = 10 };

        INameable[] objects = { car, train, new Car { Name = "Honda Civic", MaxSpeed = 180, NumberOfDoors = 4 }, new Train { Name = "Lastochka", MaxSpeed = 250, NumberOfCars = 8 } };

        Printer printer = new Printer();

        foreach (INameable obj in objects)
        {
            printer.Print(obj);
        }

        Console.ReadKey();
    }
}