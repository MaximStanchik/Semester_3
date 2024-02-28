using System;

sealed class Car : Vehicle
{
    public int NumberOfDoors { get; set; }


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
        return $"Object type: {GetType()}, name: {Name}, max speed: {MaxSpeed} km/h, number of doors: {NumberOfDoors}";
    }
}