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

        private ITicketState currentState;

        public ITicketState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        public void SwitchToSavedState()
        {
            currentState = new SavedTicketState(this);
        }

        public void SwitchToEditableState()
        {
            currentState = new EditableTicketState(this);
        }
    }

    public class NoBaggageTicketAdapter : IPayable
    {
        private NoBaggageTicket ticket;

        public NoBaggageTicketAdapter(NoBaggageTicket ticket)
        {
            this.ticket = ticket;
        }

        public void Pay()
        {
            ticket.Pay();
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
            if (!baggageIncluded && !priorityBoarding)
            {
                return new NoBaggageTicket(flightNumber, price);
            }
            else if (baggageIncluded && !priorityBoarding)
            {
                return new BaggageTicket(flightNumber, price);
            }
            else if (baggageIncluded && priorityBoarding)
            {
                return new PriorityTicket(flightNumber, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid ticket configuration");
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class TicketDecorator : Ticket
    {
        protected Ticket ticket;

        public TicketDecorator(Ticket ticket)
        {
            this.ticket = ticket;
        }

        public override void Display()
        {
            ticket.Display();
        }
    }

    public class ExtraBaggageTicketDecorator : TicketDecorator, IPayable
    {
        public ExtraBaggageTicketDecorator(Ticket ticket) : base(ticket)
        {
            BaggageIncluded = true;
        }

        public void Pay()
        {
            Console.WriteLine("Оплачиваем дополнительный багаж.");
        }

        public override void Display()
        {
            ticket.Display();
            Console.WriteLine("Дополнительный багаж: Да");
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    // Реализуйте конкретные команды
    public class SaveCommand : ICommand
    {
        private Ticket ticket;

        public SaveCommand(Ticket ticket)
        {
            this.ticket = ticket;
        }

        public void Execute()
        {
            // Логика сохранения билета
            Console.WriteLine("Билет сохранен.");
        }
    }

    public class SearchCommand : ICommand
    {
        private string flightNumber;

        public SearchCommand(string flightNumber)
        {
            this.flightNumber = flightNumber;
        }

        public void Execute()
        {
            // Логика поиска билета по номеру рейса
            Console.WriteLine($"Поиск билета с номером рейса {flightNumber}.");
        }
    }



    public interface ITicketState
    {
        void Display();
    }

    // Реализуйте конкретные состояния
    public class SavedTicketState : ITicketState
    {
        private Ticket ticket;

        public SavedTicketState(Ticket ticket)
        {
            this.ticket = ticket;
        }

        public void Display()
        {
            Console.WriteLine("Сохраненный билет:");
            ticket.Display();
        }
    }

    public class EditableTicketState : ITicketState
    {
        private Ticket ticket;

        public EditableTicketState(Ticket ticket)
        {
            this.ticket = ticket;
        }

        public void Display()
        {
            Console.WriteLine("Редактируемый билет:");
            ticket.Display();
        }
    }
    public interface IInputObserver
    {
        void Notify(decimal value);
    }

    // Реализуйте конкретных наблюдателей
    public class PriceInputObserver : IInputObserver
    {
        public void Notify(decimal value)
        {
            if (value > 1000)
            {
                Console.WriteLine("Цена превышает 1000. Пожалуйста, проверьте введенное значение.");
            }
        }
    }
    public class MainClass
    {
        public static void Main(string[] args)
        {
            // Создание билетов с помощью фабрики
            ITicketFactory ticketFactory = new TicketFactory();
            Ticket noBaggageTicket = ticketFactory.CreateNoBaggageTicket("123", 100);
            Ticket baggageTicket = ticketFactory.CreateBaggageTicket("456", 200);
            Ticket priorityTicket = ticketFactory.CreatePriorityTicket("789", 300);

            // Оплата билетов
            IPayable payableTicket1 = new NoBaggageTicketAdapter((NoBaggageTicket)noBaggageTicket);
            payableTicket1.Pay();

            IPayable payableTicket2 = (IPayable)baggageTicket;
            payableTicket2.Pay();

            IPayable payableTicket3 = (IPayable)priorityTicket;
            payableTicket3.Pay();

            Console.WriteLine();

            // Строитель билетов
            ITicketBuilder ticketBuilder = new TicketBuilder()
                .SetFlightNumber("ABC")
                .SetPrice(400)
                .SetBaggageIncluded(true)
                .SetPriorityBoarding(true);

            Ticket customTicket = ticketBuilder.Build();
            customTicket.Display();

            Console.WriteLine();

            // Декорирование билетов
            Ticket decoratedTicket1 = new ExtraBaggageTicketDecorator(noBaggageTicket);
            decoratedTicket1.Display();

            Console.WriteLine();

            Ticket decoratedTicket2 = new ExtraBaggageTicketDecorator(baggageTicket);
            decoratedTicket2.Display();

            Console.WriteLine();

            Ticket decoratedTicket3 = new ExtraBaggageTicketDecorator(priorityTicket);
            decoratedTicket3.Display();

            customTicket.SwitchToEditableState();
            customTicket.Display();
            ticketBuilder.SetPrice(800);

            ICommand saveCommand = new SaveCommand(customTicket);
            saveCommand.Execute();

            ICommand searchCommand = new SearchCommand("ABC");
            searchCommand.Execute();
        }
    }
}