using System;

namespace LowCostAirline
{
    public interface IPayable
    {
        void Pay();
    }

    public abstract class Ticket : ICloneable
    {
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public bool BaggageIncluded { get; set; }
        public bool PriorityBoarding { get; set; }

        public abstract void Display();

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class NoBaggageTicket : Ticket, IPayable
    {
        public NoBaggageTicket(string flightNumber, decimal price)
        {
            FlightNumber = flightNumber;
            Price = price;
            BaggageIncluded = false;
            PriorityBoarding = false;
        }

        public void Pay()
        {
            Console.WriteLine("Оплачиваем билет без багажа.");
        }

        public override void Display()
        {
            Console.WriteLine($"Билет на рейс {FlightNumber}");
            Console.WriteLine($"Цена: {Price}");
            Console.WriteLine("Багаж: Нет");
            Console.WriteLine("Приоритетная посадка: Нет");
        }
    }

    public class BaggageTicket : Ticket, IPayable
    {
        public BaggageTicket(string flightNumber, decimal price)
        {
            FlightNumber = flightNumber;
            Price = price;
            BaggageIncluded = true;
            PriorityBoarding = false;
        }

        public void Pay()
        {
            Console.WriteLine("Оплачиваем билет с багажом.");
        }

        public override void Display()
        {
            Console.WriteLine($"Билет на рейс {FlightNumber}");
            Console.WriteLine($"Цена: {Price}");
            Console.WriteLine("Багаж: Включен");
            Console.WriteLine("Приоритетная посадка: Нет");
        }
    }

    public class PriorityTicket : Ticket, IPayable
    {
        public PriorityTicket(string flightNumber, decimal price)
        {
            FlightNumber = flightNumber;
            Price = price;
            BaggageIncluded = true;
            PriorityBoarding = true;
        }

        public void Pay()
        {
            Console.WriteLine("Оплачиваем билет с багажом и приоритетной посадкой.");
        }

        public override void Display()
        {
            Console.WriteLine($"Билет на рейс {FlightNumber}");
            Console.WriteLine($"Цена: {Price}");
            Console.WriteLine("Багаж: Включен");
            Console.WriteLine("Приоритетная посадка: Да");
        }
    }

    public interface ITicketFactory
    {
        Ticket CreateNoBaggageTicket(string flightNumber, decimal price);
        Ticket CreateBaggageTicket(string flightNumber, decimal price);
        Ticket CreatePriorityTicket(string flightNumber, decimal price);
    }

    public class TicketFactory : ITicketFactory
    {
        public Ticket CreateNoBaggageTicket(string flightNumber, decimal price)
        {
            return new NoBaggageTicket(flightNumber, price);
        }

        public Ticket CreateBaggageTicket(string flightNumber, decimal price)
        {
            return new BaggageTicket(flightNumber, price);
        }

        public Ticket CreatePriorityTicket(string flightNumber, decimal price)
        {
            return new PriorityTicket(flightNumber, price);
        }
    }

    public interface ITicketBuilder
    {
        ITicketBuilder SetFlightNumber(string flightNumber);
        ITicketBuilder SetPrice(decimal price);
        ITicketBuilder SetBaggageIncluded(bool baggageIncluded);
        ITicketBuilder SetPriorityBoarding(bool priorityBoarding);
        Ticket Build();
    }

    public class TicketBuilder : ITicketBuilder, ICloneable
    {
        private string flightNumber;
        private decimal price;
        private bool baggageIncluded;
        private bool priorityBoarding;

        public ITicketBuilder SetFlightNumber(string flightNumber)
        {
            this.flightNumber = flightNumber;
            return this;
        }

        public ITicketBuilder SetPrice(decimal price)
        {
            this.price = price;
            return this;
        }

        public ITicketBuilder SetBaggageIncluded(bool baggageIncluded)
        {
            this.baggageIncluded = baggageIncluded;
            return this;
        }

        public ITicketBuilder SetPriorityBoarding(bool priorityBoarding)
        {
            this.priorityBoarding = priorityBoarding;
            return this;
        }

        public Ticket Build()
        {
            if (baggageIncluded && priorityBoarding)
            {
                return new PriorityTicket(flightNumber, price);
            }
            else if (baggageIncluded)
            {
                return new BaggageTicket(flightNumber, price);
            }
            else
            {
                return new NoBaggageTicket(flightNumber, price);
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание фабрики билетов
            ITicketFactory ticketFactory = new TicketFactory();

            // Создание билетов через фабрику
            Ticket noBaggageTicket = ticketFactory.CreateNoBaggageTicket("ABC123", 100);
            Ticket baggageTicket = ticketFactory.CreateBaggageTicket("DEF456", 150);
            Ticket priorityTicket = ticketFactory.CreatePriorityTicket("GHI789", 200);

            // Вывод информации о билетах
            Console.WriteLine("Билет без багажа:");
            noBaggageTicket.Display();
            Console.WriteLine();

            Console.WriteLine("Билет с багажом:");
            baggageTicket.Display();
            Console.WriteLine();

            Console.WriteLine("Билет с багажом и приоритетной посадкой:");
            priorityTicket.Display();
            Console.WriteLine();

            // Создание клона билета через шаблон Prototype
            ITicketBuilder ticketBuilder = new TicketBuilder()
                .SetFlightNumber("JKL012")
                .SetPrice(120)
                .SetBaggageIncluded(true)
                .SetPriorityBoarding(false);
            Ticket clonedTicket = ticketBuilder.Build();

            // Вывод информации о клонированном билете
            Console.WriteLine("Клонированный билет:");
            clonedTicket.Display();
            Console.WriteLine();

            // Оплата билетов
            IPayable payableTicket1 = noBaggageTicket as IPayable;
            payableTicket1.Pay();

            IPayable payableTicket2 = baggageTicket as IPayable;
            payableTicket2.Pay();

            IPayable payableTicket3 = priorityTicket as IPayable;
            payableTicket3.Pay();

            IPayable payableClonedTicket = clonedTicket as IPayable;
            payableClonedTicket.Pay();
        }
    }
}