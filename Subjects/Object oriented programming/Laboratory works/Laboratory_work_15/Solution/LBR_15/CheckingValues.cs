using System;

namespace CheckingValues
{
    internal static class InputValidator
    {
        public static int ReadPositiveIntegerInput()
        {
            int numberEnteredByTheUser;
            string consoleInput = Console.ReadLine();

            CheckWhatTheUserEntered(consoleInput);

            while (!int.TryParse(consoleInput, out numberEnteredByTheUser) || numberEnteredByTheUser <= 0)
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова:");
                consoleInput = Console.ReadLine();
            }

            return numberEnteredByTheUser;
        }
        public static void CheckWhatTheUserEntered(string userInput)
        {
            if (userInput.ToLower() == "Exit")
            {
                Console.WriteLine("Программа завершена.");
                Environment.Exit(0);
            }
        }
    }
}
        