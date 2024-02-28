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
