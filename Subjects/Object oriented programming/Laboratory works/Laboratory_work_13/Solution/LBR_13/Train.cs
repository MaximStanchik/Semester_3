using System;

[Serializable]
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