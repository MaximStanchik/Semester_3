using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Timers;


class Program
{
    static readonly object blockingAccessToASharedFile = new object();
    static void Main()
    {
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Перейти к выполнению первого задания");
        Console.WriteLine("3. Перейти к выполнению второго задания");
        Console.WriteLine("3. Перейти к выполнению третьего задания");
        Console.WriteLine("4. Перейти к выполнению четвёртого задания");
        Console.WriteLine("5. Перейти к выполнению пятого задания");
        Console.WriteLine("6. Выйти из программы");

        string taskChoice = Console.ReadLine();
        switch(taskChoice)
        {
            case "1":
                Process[] allRunningProcesses = Process.GetProcesses();

                foreach (Process everyRunningProcess in allRunningProcesses)
                {
                    Console.WriteLine($"ID: {everyRunningProcess.Id}");
                    Console.WriteLine($"Name: {everyRunningProcess.ProcessName}");
                    Console.WriteLine($"Priority: {everyRunningProcess.BasePriority}");
                    Console.WriteLine($"Start Time: {everyRunningProcess.StartTime}");
                    Console.WriteLine($"Current State: {everyRunningProcess.Responding}");
                    Console.WriteLine($"Total Processor Time: {everyRunningProcess.TotalProcessorTime}");
                    Console.WriteLine("-------------------------------------------");
                }

                AppDomain currentDomainOfProgram = AppDomain.CurrentDomain;
                Console.WriteLine($"Current Domain Name: {currentDomainOfProgram.FriendlyName}");
                Console.WriteLine($"Configuration Details: {currentDomainOfProgram.SetupInformation}");

                Assembly[] allAssemblies = currentDomainOfProgram.GetAssemblies();
                Console.WriteLine("Assemblies loaded in current domain:");
                foreach (Assembly assembly in allAssemblies)
                {
                    Console.WriteLine(assembly.FullName);
                }
                break;
            case "2":
                Console.WriteLine("-------------------------------------------");

                AppDomain newDomainOfProgram = AppDomain.CreateDomain("NewDomain");

                string assemblyPath = "PathToYourAssembly.dll";
                Assembly assemblyInNewDomain = newDomainOfProgram.Load(AssemblyName.GetAssemblyName(assemblyPath));
                Console.WriteLine($"Assembly loaded in new domain: {assemblyInNewDomain.FullName}");

                Console.WriteLine("-------------------------------------------");

                AppDomain.Unload(newDomainOfProgram);
                Console.WriteLine("New domain unloaded.");
                break;
            case "3":
                Console.WriteLine("Введите число n:");
                int userEnteredValue_n = int.Parse(Console.ReadLine());

                if (IsPrimeAndLettersOnly(userEnteredValue_n) == false)
                {
                    Console.WriteLine("Введено неверное значение n.");
                    Console.WriteLine("Желаете ввести число снова? (Yes/No)");
                    string selectIfInvalidValue = Console.ReadLine();
                    switch (selectIfInvalidValue)
                    {
                        case "Yes":
                            break; 
                        case "No":
                            return;
                        default:
                            Console.WriteLine("Некорректный выбор. Автоматический выход из программы.");
                            return; 
                    }
                }
                else
                {
                    Thread calculationThread = new Thread(() => CalculateAndWritePrimes(userEnteredValue_n));
                    calculationThread.Start();

                    while (true)
                    {
                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("1. Приостановить поток");
                        Console.WriteLine("2. Возобновить поток");
                        Console.WriteLine("3. Остановить поток");
                        Console.WriteLine("4. Выйти из программы");

                        string streamChoice = Console.ReadLine();

                        switch (streamChoice)
                        {
                            case "1":
                                calculationThread.Suspend();
                                Console.WriteLine("Поток приостановлен.");
                                break;
                            case "2":
                                calculationThread.Resume();
                                Console.WriteLine("Поток возобновлен.");
                                break;
                            case "3":
                                calculationThread.Abort();
                                Console.WriteLine("Поток остановлен.");
                                break;
                            case "4":
                                calculationThread.Abort();
                                return;
                            default:
                                Console.WriteLine("Некорректный выбор.");
                                break;
                        }
                    }
                }
                break;
            case "4":
                int numberEnteredByTheUserInTask_4 = int.Parse(Console.ReadLine());

                if (IsPrimeAndLettersOnly(numberEnteredByTheUserInTask_4) == false)
                {
                    Console.WriteLine("Введено неверное значение n.");
                    Console.WriteLine("Желаете ввести число снова? (Yes/No)");
                    string selectIfInvalidValue = Console.ReadLine();
                    switch (selectIfInvalidValue)
                    {
                        case "Yes":
                            break;
                        case "No":
                            return;
                        default:
                            Console.WriteLine("Некорректный выбор. Автоматический выход из программы.");
                            return;
                    }
                }
                else {
                    Console.WriteLine("Выберите порядок вывода чисел (1 - сначала четные, потом нечетные, 2 - последовательный вывод):");
                    int choiceInTask_4 = int.Parse(Console.ReadLine());
                    if (IsPrimeAndLettersOnly(choiceInTask_4) == false)
                    {
                        Console.WriteLine("Введено неверное значение n.");
                        Console.WriteLine("Желаете ввести число снова? (Yes/No)");
                        string selectIfInvalidValue = Console.ReadLine();
                        switch (selectIfInvalidValue)
                        {
                            case "Yes":
                                break;
                            case "No":
                                return;
                            default:
                                Console.WriteLine("Некорректный выбор. Автоматический выход из программы.");
                                return;
                        }
                    }
                    else
                    {
                        Thread threadForOutputtingEvenNumbers, threadForOutputtingOddNumbers;

                        switch (choiceInTask_4)
                        {
                            case 1:
                                threadForOutputtingEvenNumbers = new Thread(() => PrintEvenNumbers(numberEnteredByTheUserInTask_4));
                                threadForOutputtingOddNumbers = new Thread(() => PrintOddNumbers(numberEnteredByTheUserInTask_4));
                                break;
                            case 2:
                                threadForOutputtingEvenNumbers = new Thread(() => PrintNumbersSequentially(numberEnteredByTheUserInTask_4));
                                threadForOutputtingOddNumbers = null;
                                break;
                            default:
                                Console.WriteLine("Неверный выбор.");
                                return;
                        }

                        threadForOutputtingEvenNumbers.Priority = ThreadPriority.Highest;

                        threadForOutputtingEvenNumbers.Start();
                        threadForOutputtingOddNumbers.Start();


                        threadForOutputtingEvenNumbers.Join();
                        threadForOutputtingOddNumbers.Join();

                        Console.WriteLine("Все потоки завершили работу. Нажмите любую клавишу для выхода.");
                    }
                }
                break;
            case "5":
                System.Timers.Timer timer = new System.Timers.Timer(1000);

                timer.Elapsed += TimerElapsed;

                timer.Start();

                Console.WriteLine("Таймер запущен. Нажмите любую клавишу для остановки.");
                Console.ReadKey();

                timer.Stop();

                Console.WriteLine("Таймер остановлен. Нажмите любую клавишу для выхода.");
                Console.ReadKey();
                break;
            case "6":
                Console.WriteLine("Выход из программы.");
                break;
            default:
                Console.WriteLine("Вы ввели неверное значение.");
                Console.WriteLine("Автоматический выход из программы.");
                break;
        } 
    }

    static void CalculateAndWritePrimes(int n)
    {
        string filePath = "primes.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 2; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                    writer.WriteLine(i);
                    Thread.Sleep(500); 
                }
            }
        }
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    static bool IsPrimeAndLettersOnly(int userEnteredNumber)
    {
        if (!IsPrime(userEnteredNumber))
            return false;

        string numberString = userEnteredNumber.ToString();
        foreach (char userEnteredLetter in numberString)
        {
            if (!char.IsLetter(userEnteredLetter))
                return false;
        }

        return true;
    }

    static void PrintEvenNumbers(int numberEnteredByTheUserInTask_4)
    {
        string filePath = "Numbers from task 4.txt";
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            for (int i = 2; i <= numberEnteredByTheUserInTask_4; i += 2)
            {
                lock (blockingAccessToASharedFile)
                {
                    Console.WriteLine($"Четное число: {i}");
                    writer.WriteLine($"Четное число: {i}");
                }
                Thread.Sleep(100); 
            }
        }
    }

    static void PrintOddNumbers(int numberEnteredByTheUserInTask_4)
    {
        string filePath = "Numbers from task 4.txt";
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            for (int i = 1; i <= numberEnteredByTheUserInTask_4; i += 2)
            {
                lock (blockingAccessToASharedFile)
                {
                    Console.WriteLine($"Нечетное число: {i}");
                    writer.WriteLine($"Нечетное число: {i}");
                }
                Thread.Sleep(200); 
            }
        }
    }

    static void PrintNumbersSequentially(int numberEnteredByTheUserInTask_4)
    {
        string filePath = "Numbers from task 4.txt";
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            for (int i = 1; i <= numberEnteredByTheUserInTask_4; i++)
            {
                lock (blockingAccessToASharedFile)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine($"Четное число: {i}");
                        writer.WriteLine($"Четное число: {i}");
                    }
                    else
                    {
                        Console.WriteLine($"Нечетное число: {i}");
                        writer.WriteLine($"Нечетное число: {i}");
                    }
                }
                Thread.Sleep(100);
            }
        }
    }

    static void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        int i = 1;
        Console.WriteLine("Прошло " + i + " секунд");
        i++;
    }
}

