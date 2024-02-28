using System;
using System.IO;

public class SMADirInfo
{
    private string directoryPath;

    public SMADirInfo(string directoryPath)
    {
        this.directoryPath = directoryPath;
    }

    public void PrintFileCount()
    {
        try
        {
            int fileCount = Directory.GetFiles(directoryPath).Length;
            Console.WriteLine($"Количество файлов: {fileCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении количества файлов: {ex.Message}");
        }
    }

    public void PrintCreationTime()
    {
        try
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            Console.WriteLine($"Время создания директории: {directoryInfo.CreationTime}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении времени создания директории: {ex.Message}");
        }
    }

    public void PrintSubdirectoryCount()
    {
        try
        {
            int subdirectoryCount = Directory.GetDirectories(directoryPath).Length;
            Console.WriteLine($"Количество поддиректорий: {subdirectoryCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении количества поддиректорий: {ex.Message}");
        }
    }

    public void PrintParentDirectories()
    {
        try
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            DirectoryInfo parentDirectory = directoryInfo.Parent;

            while (parentDirectory != null)
            {
                Console.WriteLine($"Родительская директория: {parentDirectory.FullName}");
                parentDirectory = parentDirectory.Parent;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении списка родительских директорий: {ex.Message}");
        }
    }
}