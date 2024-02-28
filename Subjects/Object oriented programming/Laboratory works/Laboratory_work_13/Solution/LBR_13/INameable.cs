using System;

interface INameable
{
    string Name { get; set; }
}

[Serializable]
abstract class Vehicle : INameable
{
    public string Name { get; set; }
    public int MaxSpeed { get; set; }

    public abstract void PrintInfo();
    public abstract double CalculateTravelTime(double distance);

    public override string ToString()
    {
        return $"Object type: {GetType()}, name: {Name}, max speed: {MaxSpeed} km/h";
    }
}
