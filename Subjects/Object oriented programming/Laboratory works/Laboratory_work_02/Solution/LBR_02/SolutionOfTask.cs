using System;

class Train
{
    private static int numOfTrains = 0; 

    public string Destination { get; private set; }
    public int TrainNumber { get; private set; }
    public DateTime DepartureTime { get; private set; }
    public int CommonSeats { get; private set; }
    public int CoupeSeats { get; private set; }
    public int ReservedSeats { get; private set; }
    public int LuxurySeats { get; private set; }

    public static int NumOfTrains { get { return numOfTrains; } } 

    public Train(string destination, int trainNumber, DateTime departureTime, int commonSeats, int coupeSeats, int reservedSeats, int luxurySeats)
    {
        Destination = destination;
        TrainNumber = trainNumber;
        DepartureTime = departureTime;
        CommonSeats = commonSeats;
        CoupeSeats = coupeSeats;
        ReservedSeats = reservedSeats;
        LuxurySeats = luxurySeats;

        numOfTrains++; 
    }

    public static void PrintTrainInfo()
    {
        Console.WriteLine($"Количество созданных объектов класса Train: {NumOfTrains}");
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Train otherTrain = (Train)obj;
        return TrainNumber == otherTrain.TrainNumber;
    }

    public override int GetHashCode()
    {
        return TrainNumber.GetHashCode();
    }

    public override string ToString()
    {
        return $"Поезд номер {TrainNumber}, отправление в {DepartureTime}";
    }
}

class Program
{
    static void Main()
    {
        Train[] trains = new Train[]
        {
            new Train("Москва", 123, new DateTime(2023, 9, 12, 10, 0, 0), 50, 40, 30, 30),
            new Train("Санкт-Петербург", 456, new DateTime(2023, 9, 13, 12, 0, 0), 70, 50, 40, 40),
            new Train("Киев", 789, new DateTime(2023, 9, 15, 14, 0, 0), 60, 45, 35, 40),
            new Train("Москва", 246, new DateTime(2023, 9, 12, 15, 0, 0), 80, 60, 50, 30),
            new Train("Санкт-Петербург", 135, new DateTime(2023, 9, 13, 18, 0, 0), 65, 45, 40, 40)
        };

        
        string destination = "Москва";
        Console.WriteLine($"Список поездов, следующих до пункта назначения '{destination}':");
        foreach (Train train in trains)
        {
            if (train.Destination == destination)
            {
                Console.WriteLine(train.ToString());
            }
        }

        
        DateTime departureTime = new DateTime(2023, 9, 13, 14, 0, 0);
        Console.WriteLine($"Список поездов, следующих до пункта назначения '{destination}' и отправляющихся после {departureTime}:");
        foreach (Train train in trains)
        {
            if (train.Destination == destination && train.DepartureTime > departureTime)
            {
                Console.WriteLine(train.ToString());
            }
        }

        Train.PrintTrainInfo(); 

        
        var anonymousTrain = new
        {
            Destination = "Санкт-Петербург",
            TrainNumber = 777,
            DepartureTime = new DateTime(2023, 9, 14, 16, 0, 0),
            CommonSeats = 30,
            CoupeSeats = 20,
            ReservedSeats = 10,
            LuxurySeats = 5
        };

        Console.WriteLine(anonymousTrain.ToString()); 
    }
}