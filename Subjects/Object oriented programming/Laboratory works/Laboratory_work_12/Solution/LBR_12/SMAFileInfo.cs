using System;
using System.IO;

public class SMAFileInfo
{
    private string filePath;

    public SMAFileInfo(string filePath)
    {
        this.filePath = filePath;
    }

    public void PrintFullPath()
    {
        try
        {
            string fullPath = Path.GetFullPath(filePath);
            Console.WriteLine($"Полный путь файла: {fullPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении полного пути файла: {ex.Message}");
        }
    }

    public void PrintFileInfo()
    {
        try
        {
            FileInfo fileInfo = new FileInfo(filePath);
            Console.WriteLine($"Размер файла: {fileInfo.Length} байт");
            Console.WriteLine($"Расширение файла: {fileInfo.Extension}");
            Console.WriteLine($"Имя файла: {fileInfo.Name}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении информации о файле: {ex.Message}");
        }
    }

    public void PrintFileDates()
    {
        try
        {
            FileInfo fileInfo = new FileInfo(filePath);
            Console.WriteLine($"Дата создания файла: {fileInfo.CreationTime}");
            Console.WriteLine($"Дата последнего изменения файла: {fileInfo.LastWriteTime}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении дат файла: {ex.Message}");
        }
    }
}