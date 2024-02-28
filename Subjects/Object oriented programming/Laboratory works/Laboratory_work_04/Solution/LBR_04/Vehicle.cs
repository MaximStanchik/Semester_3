using System;

interface INameable
{
    string Name { get; set; }
}

abstract class Vehicle : INameable
{
    public string Name { get; set; }
    public int MaxSpeed { get; set; }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Vehicle: {Name}, max speed: {MaxSpeed} km/h");
    }

    public abstract double CalculateTravelTime(double distance);

    public override string ToString()
    {
        return $"Object type: {GetType()}, name: {Name}, max speed: {MaxSpeed} km/h";
    }
}
