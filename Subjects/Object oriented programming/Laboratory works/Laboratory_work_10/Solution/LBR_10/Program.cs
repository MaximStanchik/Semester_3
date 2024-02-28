using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Train> trains = new List<Train>();

        trains.Add(new Train("Москва", 1, DateTime.Parse("2023-10-23 10:00"), 100, 50, 20, 10));
        trains.Add(new Train("Санкт-Петербург", 2, DateTime.Parse("2023-10-23 12:00"), 150, 60, 30, 15));
        trains.Add(new Train("Новосибирск", 3, DateTime.Parse("2023-10-23 15:30"), 120, 55, 25, 12));
        trains.Add(new Train("Екатеринбург", 4, DateTime.Parse("2023-10-23 18:45"), 110, 45, 22, 11));
        trains.Add(new Train("Казань", 5, DateTime.Parse("2023-10-23 20:15"), 130, 58, 28, 14));
        trains.Add(new Train("Ростов-на-Дону", 6, DateTime.Parse("2023-10-23 22:30"), 105, 48, 24, 13));
        trains.Add(new Train("Сочи", 7, DateTime.Parse("2023-10-24 09:15"), 95, 42, 21, 9));
        trains.Add(new Train("Владивосток", 8, DateTime.Parse("2023-10-24 14:20"), 140, 62, 32, 16));
        trains.Add(new Train("Калининград", 9, DateTime.Parse("2023-10-24 16:40"), 125, 52, 27, 13));
        trains.Add(new Train("Уфа", 10, DateTime.Parse("2023-10-24 19:00"), 115, 47, 23, 10));

        var selectedTrains = trains
            .Where(t => t.CommonSeats > 100) 
            .OrderBy(t => t.DepartureTime) 
            .Select(t => t.ToString()); 
        var passengers = new List<Passenger>
        {
            new Passenger { TrainNumber = 1, Name = "Иванов", Age = 30 },
            new Passenger { TrainNumber = 2, Name = "Петров", Age = 25 },
            new Passenger { TrainNumber = 3, Name = "Сидоров", Age = 40 },
            new Passenger { TrainNumber = 1, Name = "Козлов", Age = 35 },
            new Passenger { TrainNumber = 3, Name = "Смирнов", Age = 28 }
        };

        var trainPassengerInfo = from train in trains
                                 join passenger in passengers on train.TrainNumber equals passenger.TrainNumber
                                 select new { Train = train, Passenger = passenger };
        string destination = "Москва"; 

        var trainsToDestination = from train in trains
                                  where train.Destination == destination
                                  select train;

        var trainsToDestination_Train = from train in trains
                                  where train.Destination == destination
                                  select train;
        string destination_StPetersburg = "Санкт-Петербург";
        int departureHour = 15; 

        var trainsToDestinationAfterHour = from train in trains
                                           where train.Destination == destination && train.DepartureTime.Hour > departureHour
                                           select train;
        var maxCapacityTrain = trains.OrderByDescending(train =>
    train.CommonSeats + train.CoupeSeats + train.ReservedSeats + train.LuxurySeats)
    .FirstOrDefault();

        var lastFiveTrains = trains.OrderByDescending(train => train.DepartureTime)
                           .Take(5)
                           .OrderBy(train => train.Destination);

        string[] twelveMonths = new string[]
        {
            "June"     ,
            "July"     ,
            "August"   ,
            "September",
            "October"  ,
            "November" ,
            "December" ,
            "January"  ,
            "February" ,
            "March"    ,
            "April"    ,
            "May"
        };

        int monthStringLength_n = 0;
        bool isValidInput = false;

        Console.WriteLine("Выберите действие:");
        Console.WriteLine("01. Начать выполнение программы");
        Console.WriteLine("02. Закрыть программу");

        string startOrCloseExecution = Console.ReadLine();

        switch (startOrCloseExecution)
        {
            case "01":
                Console.WriteLine("Программа начала свое выполнение");

                while (!isValidInput)
                {
                    Console.Write("Введите значение n: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out monthStringLength_n))
                    {
                        if (monthStringLength_n >= 0)
                        {
                            isValidInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка! Введите целочисленное положительное значение.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Введите целочисленное значение.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("01. Вывести месяцы с длиной строки {0}", monthStringLength_n);
                    Console.WriteLine("02. Вывести летние и зимние месяцы");
                    Console.WriteLine("03. Вывести месяцы в алфавитном порядке");
                    Console.WriteLine("04. Посчитать месяцы, содержащие букву 'u' и длиной имени не менее 4");
                    Console.WriteLine("05. Вывести месяцы, содержащие гласные");
                    Console.WriteLine("06. Вывод информации о поездах (без инофрмации о пассажирах)");
                    Console.WriteLine("07. Вывод информации о поездах (c инофрмацией о пассажирах)");
                    Console.WriteLine("08. Вывести список поездов, следующих до заданного пункта назначения и отправляющихся после заданного часа отправления");
                    Console.WriteLine("09. Вывести поезд по самому большому кол-ву мест");
                    Console.WriteLine("10. Вывести последние пять поездов по времени отправления в алфавитном порядке по пункту назначения");
                    Console.WriteLine("11. Выйти из программы\n");

                    Console.Write("Введите номер действия: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "01":
                            var monthsWithLengthN = twelveMonths.Where(m => m.Length == monthStringLength_n);
                            Console.WriteLine("Месяцы с длиной строки {0}:", monthStringLength_n);
                            foreach (var month in monthsWithLengthN)
                            {
                                Console.WriteLine(month);
                            }
                            Console.WriteLine();
                            break;

                        case "02":
                            var summerMonths = new string[] { "June", "July", "August" };
                            var winterMonths = new string[] { "December", "January", "February" };

                            Console.WriteLine("Летние месяцы: {0}", string.Join(", ", summerMonths));
                            Console.WriteLine("Зимние месяцы: {0}", string.Join(", ", winterMonths));
                            Console.WriteLine();
                            break;

                        case "03":
                            var monthsInAlphabeticalOrder = twelveMonths.OrderBy(m => m);
                            Console.WriteLine("Месяцы в алфавитном порядке:");
                            foreach (var month in monthsInAlphabeticalOrder)
                            {
                                Console.WriteLine(month);
                            }
                            Console.WriteLine();
                            break;

                        case "04":
                            var monthsWithUAndLength4OrMore = twelveMonths.Where(m => m.Contains("u") && m.Length >= 4);
                            int count = monthsWithUAndLength4OrMore.Count();
                            Console.WriteLine("Количество месяцев, содержащих букву 'u' и длиной имени не менее 4: {0}", count);
                            Console.WriteLine();
                            break;

                        case "05":
                            var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
                            var monthsWithVowels = twelveMonths.Where(m => m.ToLower().Intersect(vowels).Any());
                            Console.WriteLine("Месяцы, содержащие гласные:");
                            foreach (var month in monthsWithVowels)
                            {
                                Console.WriteLine(month);
                            }
                            Console.WriteLine();
                            break;

                        case "06":
                            
                            foreach (var train in selectedTrains)
                            {
                                Console.WriteLine(train);
                            }

                            Train.PrintTrainInfo();

                            break;
                        case "07":
                            foreach (var info in trainPassengerInfo)
                            {
                                Console.WriteLine($"Поезд номер {info.Train.TrainNumber}, отправление в {info.Train.DepartureTime}");
                                Console.WriteLine($"Пассажир: {info.Passenger.Name}, возраст: {info.Passenger.Age}");
                                Console.WriteLine();
                            }
                            break;
                        case "08":
                            foreach (var train in trainsToDestinationAfterHour)
                            {
                                Console.WriteLine($"Поезд номер {train.TrainNumber}, следующий до {destination_StPetersburg} и отправляющийся после {destination_StPetersburg} часов");
                            }
                            break;
                        case "09":
                            Console.WriteLine($"Максимальный поезд по количеству мест: Поезд номер {maxCapacityTrain.TrainNumber}, количество мест: {maxCapacityTrain.CommonSeats + maxCapacityTrain.CoupeSeats + maxCapacityTrain.ReservedSeats + maxCapacityTrain.LuxurySeats}");
                            break;
                        case "10":
                            foreach (var train in lastFiveTrains)
                            {
                                Console.WriteLine($"Поезд номер {train.TrainNumber}, отправление в {train.DepartureTime}, пункт назначения: {train.Destination}");
                            }
                            break;
                        case "11":
                            return;

                        default:
                            Console.WriteLine("Ошибка! Введите номер действия от 1 до 6.");
                            Console.WriteLine();
                            break;

                    }
                }
            case "02":
                Console.WriteLine("2. Программа закончила свое выполнение");
                return;
        }
    }
}






