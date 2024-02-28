using System;
using System.Collections.Generic;
using System.Linq;
interface INameable
{
    string Name { get; set; }
    double Cost { get; set; }
    double FuelConsumption { get; set; }
}

sealed class Car : Vehicle, INameable
{
    public int NumberOfDoors { get; set; }
    public new double Cost { get; set; }
    public new double FuelConsumption { get; set; }

    public override void PrintInfo()
    {
        Console.WriteLine($"Car: {Name}, max speed: {MaxSpeed} km/h, number of doors: {NumberOfDoors}");
    }
    
    public override double CalculateTravelTime(double distance)
    {
        return distance / MaxSpeed;
    }

    public override string ToString()
    {
        return $"Object type: {GetType()}, name: {Name}, max speed: {MaxSpeed} km/h, number of doors: {NumberOfDoors}, cost: {Cost}, fuel consumption: {FuelConsumption} L/100km";
    }
}

class Train : Vehicle
{
    public int NumberOfCars { get; set; }

    public override void PrintInfo()
    {
        Console.WriteLine($"Train: {Name}, max speed: {MaxSpeed} km/h, number of cars: {NumberOfCars}");
    }

    public override double CalculateTravelTime(double distance)
    {
        return distance / (MaxSpeed * 0.8);
    }

    public override string ToString()
    {
        return $"Object type: {GetType()}, name: {Name}, max speed: {MaxSpeed} km/h, number of cars: {NumberOfCars}";
    }
}

class Printer
{
    public void Print(INameable obj)
    {
        Console.WriteLine(obj.ToString());
    }
}

abstract class Vehicle : INameable
{
    public string Name { get; set; }
    public int MaxSpeed { get; set; }
    public double FuelConsumption { get; set; }
    public double Cost { get; set; }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Vehicle: {Name}, max speed: {MaxSpeed} km/h");
    }

    public abstract double CalculateTravelTime(double distance);

    public virtual double CalculateCost()
    {
        return 0;
    }

    public override string ToString()
    {
        return $"Object type: {GetType()}, name: {Name}, max speed: {MaxSpeed} km/h";
    }
}

class TransportContainer
{
    private List<INameable> transportList;

    public TransportContainer()
    {
        transportList = new List<INameable>();
    }

    public void AddTransport(INameable transport)
    {
        transportList.Add(transport);
    }

    public void RemoveTransport(INameable transport)
    {
        transportList.Remove(transport);
    }

    public void PrintTransportList()
    {
        foreach (INameable transport in transportList)
        {
            Console.WriteLine(transport.ToString());
        }
    }

    public List<INameable> GetTransportList()
    {
        return transportList;
    }
}

class TransportController
{
    private TransportContainer transportContainer;
    private List<INameable> userVehicles;

    public TransportController(TransportContainer container)
    {
        transportContainer = container;
        userVehicles = new List<INameable>();
    }


    public double CalculateTotalCost()
    {
        double totalCost = userVehicles.Sum(transport => transport.Cost);
        return totalCost;
    }

    public void SortCarsByFuelConsumption()
    {
        var sortedCars = transportContainer.GetTransportList()
            .OfType<Car>()
            .OrderBy(car => car.FuelConsumption);

        foreach (var car in sortedCars)
        {
            Console.WriteLine(car.ToString());
        }
    }

    public void FindTransportBySpeedRange(int minSpeed, int maxSpeed)
    {
        var transportInRange = transportContainer.GetTransportList()
            .Where(transport => transport is Vehicle && ((Vehicle)transport).MaxSpeed >= minSpeed && ((Vehicle)transport).MaxSpeed <= maxSpeed);

        foreach (var transport in transportInRange)
        {
            Console.WriteLine(transport.ToString());
        }
    }

    public void SortCarsByCost()
    {
        var sortedCars = transportContainer.GetTransportList()
            .OfType<Car>()
            .OrderBy(car => car.Cost);

        foreach (var car in sortedCars)
        {
            Console.WriteLine(car.ToString());
        }
    }

    public void AddTrain()
    {
        Train train = CreateTrain();
        transportContainer.AddTransport(train);
        userVehicles.Add(train);
    }

    static Train CreateTrain()
    {
        Console.WriteLine("Enter train details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Max speed (km/h): ");
        int maxSpeed;
        try
        {
            maxSpeed = int.Parse(Console.ReadLine());
            if (maxSpeed < 0)
            {
                throw new InvalidTransportDataException("Max speed cannot be negative.");
            }
        }
        catch (InvalidTransportDataException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer value for max speed.");
            return null;
        }
        Console.Write("Number of cars: ");
        int numberOfCars;
        try
        {
            numberOfCars = int.Parse(Console.ReadLine());
            if (numberOfCars < 0)
            {
                throw new InvalidTransportDataException("Number of cars cannot be negative.");
            }
        }
        catch (InvalidTransportDataException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer value for number of cars.");
            return null;
        }
        return new Train { Name = name, MaxSpeed = maxSpeed, NumberOfCars = numberOfCars };
    }

    static Car CreateCar()
    {
        Console.WriteLine("Enter car details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Max speed (km/h): ");
        int maxSpeed;
        try
        {
            maxSpeed = int.Parse(Console.ReadLine());
            if (maxSpeed < 0)
            {
                throw new InvalidTransportDataException("Max speed cannot be negative.");
            }
        }
        catch (InvalidTransportDataException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer value for max speed.");
            return null;
        }
        Console.Write("Number of doors: ");
        int numberOfDoors;
        try
        {
            numberOfDoors = int.Parse(Console.ReadLine());
            if (numberOfDoors < 0)
            {
                throw new InvalidTransportDataException("Number of doors cannot be negative.");
            }
        }
        catch (InvalidTransportDataException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer value for number of doors.");
            return null;
        }
        Console.Write("Cost: ");
        double cost;
        try
        {
            cost = double.Parse(Console.ReadLine());
            if (cost < 0)
            {
                throw new InvalidTransportDataException("Cost cannot be negative.");
            }
        }
        catch (InvalidTransportDataException)
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric value for cost.");
            return null;
        }
        Console.Write("Fuel consumption (L/100km): ");
        double fuelConsumption;
        try
        {
            fuelConsumption = double.Parse(Console.ReadLine());
            if (fuelConsumption < 0)
            {
                throw new InvalidTransportDataException("Fuel consumption cannot be negative.");
            }
        }
        catch (InvalidTransportDataException)
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric value for fuel consumption.");
            return null;
        }
        return new Car { Name = name, MaxSpeed = maxSpeed, NumberOfDoors = numberOfDoors, Cost = cost, FuelConsumption = fuelConsumption };
    }



    public void AddCar()
    {
        Car car = CreateCar();
        transportContainer.AddTransport(car);
        userVehicles.Add(car);
    }
}

public class InvalidTransportDataException : Exception
{
    public InvalidTransportDataException(string message) : base(message)
    {
    }
}

class Program
{
    static Train CreateTrain()
    {
        Console.WriteLine("Enter train details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Max speed (km/h): ");
        int maxSpeed;
        try
        {
            maxSpeed = int.Parse(Console.ReadLine());
            if (maxSpeed < 0)
            {
                throw new InvalidTransportDataException("Max speed cannot be negative.");
            }
        }
        catch (InvalidTransportDataException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer value for max speed.");
            return null;
        }
        Console.Write("Number of cars: ");
        int numberOfCars;
        try
        {
            numberOfCars = int.Parse(Console.ReadLine());
            if (numberOfCars < 0)
            {
                throw new InvalidTransportDataException("Number of cars cannot be negative.");
            }
        }
        catch (InvalidTransportDataException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer value for number of cars.");
            return null;
        }
        return new Train { Name = name, MaxSpeed = maxSpeed, NumberOfCars = numberOfCars };
    }

    static Car CreateCar()
    {
        Console.WriteLine("Enter car details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Max speed (km/h): ");
        int maxSpeed;
        try
        {
            maxSpeed = int.Parse(Console.ReadLine());
            if (maxSpeed < 0)
            {
                throw new InvalidTransportDataException("Max speed cannot be negative.");
            }
        }
        catch (InvalidTransportDataException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer value for max speed.");
            return null;
        }
        Console.Write("Number of doors: ");
        int numberOfDoors;
        try
        {
            numberOfDoors = int.Parse(Console.ReadLine());
            if (numberOfDoors < 0)
            {
                throw new InvalidTransportDataException("Number of doors cannot be negative.");
            }
        }
        catch (InvalidTransportDataException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer value for number of doors.");
            return null;
        }
        Console.Write("Cost: ");
        double cost;
        try
        {
            cost = double.Parse(Console.ReadLine());
            if (cost < 0)
            {
                throw new InvalidTransportDataException("Cost cannot be negative.");
            }
        }
        catch (InvalidTransportDataException)
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric value for cost.");
            return null;
        }
        Console.Write("Fuel consumption (L/100km): ");
        double fuelConsumption;
        try
        {
            fuelConsumption = double.Parse(Console.ReadLine());
            if (fuelConsumption < 0)
            {
                throw new InvalidTransportDataException("Fuel consumption cannot be negative.");
            }
        }
        catch (InvalidTransportDataException)
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric value for fuel consumption.");
            return null;
        }
        return new Car { Name = name, MaxSpeed = maxSpeed, NumberOfDoors = numberOfDoors, Cost = cost, FuelConsumption = fuelConsumption };
    }

    static void Main(string[] args)
    {
        TransportContainer container = new TransportContainer();
        TransportController controller = new TransportController(container);

        while (true)
        {
            try
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add a car");
                Console.WriteLine("2. Add a train");
                Console.WriteLine("3. Sort cars by fuel consumption");
                Console.WriteLine("4. Sort cars by cost");
                Console.WriteLine("5. Find transport by speed range");
                Console.WriteLine("6. Calculate total cost");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Invalid input. Please enter a valid integer value for choice: ");
                }

                switch (choice)
                {
                    case 1:
                        controller.AddCar();
                        break;
                    case 2:
                        controller.AddTrain();
                        break;
                    case 3:
                        controller.SortCarsByFuelConsumption();
                        break;
                    case 4:
                        controller.SortCarsByCost();
                        break;
                    case 5:
                        Console.Write("Enter minimum speed: ");
                        int minSpeed;
                        while (!int.TryParse(Console.ReadLine(), out minSpeed))
                        {
                            Console.Write("Invalid input. Please enter a valid integer value for minimum speed: ");
                        }

                        Console.Write("Enter maximum speed: ");
                        int maxSpeed;
                        while (!int.TryParse(Console.ReadLine(), out maxSpeed))
                        {
                            Console.Write("Invalid input. Please enter a valid integer value for maximum speed: ");
                        }

                        controller.FindTransportBySpeedRange(minSpeed, maxSpeed);
                        break;
                    case 6:
                        double totalCost = controller.CalculateTotalCost();
                        Console.WriteLine($"Total cost of vehicles: {totalCost}");
                        break;
                    case 0:
                        return;
                    default:
                        System.Diagnostics.Debug.Assert(false, "Invalid choice. Please try again.");
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine();
            }
        }
    }
}