using System;
using System.IO;

public class SMALog
{
    private const string LogFilePath = "SMAlogfile.txt";

    public void LogAction(string action, string fileName, string filePath)
    {
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {action}: {fileName} ({filePath})";

        try
        {
            using (StreamWriter writer = File.AppendText(LogFilePath))
            {
                writer.WriteLine(logEntry);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при записи в лог-файл: {ex.Message}");
        }
    }

    public void ReadLog()
    {
        try
        {
            string[] logEntries = File.ReadAllLines(LogFilePath);
            foreach (string entry in logEntries)
            {
                Console.WriteLine(entry);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении лог-файла: {ex.Message}");
        }
    }

    public void SearchLog(string keyword)
    {
        try
        {
            string[] logEntries = File.ReadAllLines(LogFilePath);
            foreach (string entry in logEntries)
            {
                if (entry.Contains(keyword))
                {
                    Console.WriteLine(entry);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении лог-файла: {ex.Message}");
        }
    }

    public void DeleteOldEntries()
    {
        try
        {
            string[] logEntries = File.ReadAllLines(LogFilePath);
            DateTime currentHour = DateTime.Now;
            DateTime lowerBound = currentHour.Date.AddHours(currentHour.Hour);

            using (StreamWriter writer = new StreamWriter(LogFilePath))
            {
                foreach (string entry in logEntries)
                {
                    string timestampString = entry.Substring(0, 19);
                    if (DateTime.TryParseExact(timestampString, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime timestamp))
                    {
                        if (timestamp >= lowerBound)
                        {
                            writer.WriteLine(entry);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при удалении старых записей из лог-файла: {ex.Message}");
        }
    }

    public int CountLogEntries()
    {
        try
        {
            string[] logEntries = File.ReadAllLines(LogFilePath);
            return logEntries.Length;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении лог-файла: {ex.Message}");
            return 0;
        }
    }
}