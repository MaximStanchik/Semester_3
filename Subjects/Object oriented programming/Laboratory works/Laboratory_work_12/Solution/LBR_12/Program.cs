using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBR_12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Демонстрация работы класса SMALog:");
            SMADiskInfo diskInfo = new SMADiskInfo();
            diskInfo.PrintFreeSpace("C");
            diskInfo.PrintFileSystem("D");
            diskInfo.PrintDriveInfo();

            Console.WriteLine("Демонстрация работы класса SMALog с дополнениями:");
            SMALog log = new SMALog();
            log.ReadLog(); 
            log.SearchLog("keyword");
            log.DeleteOldEntries(); 
            int count = log.CountLogEntries(); 
            Console.WriteLine($"Количество записей в логе: {count}");

            Console.WriteLine("Демонстрация работы класса SMADiskInfo:");
            SMALog logger = new SMALog();
            logger.LogAction("Открытие файла", "example.txt", "C:\\Documents");
            logger.ReadLog();
            logger.SearchLog("Открытие");

            Console.WriteLine("Демонстрация работы класса SMAFileInfo:");
            string filePath = "C:\\path\\to\\file.txt";
            SMAFileInfo fileInfo = new SMAFileInfo(filePath);
            fileInfo.PrintFullPath();
            fileInfo.PrintFileInfo();
            fileInfo.PrintFileDates();

            Console.WriteLine("Демонстрация работы класса SMADirInfo:");
            string directoryPath = "C:\\path\\to\\directory";
            SMADirInfo dirInfo = new SMADirInfo(directoryPath);
            dirInfo.PrintFileCount();
            dirInfo.PrintCreationTime();
            dirInfo.PrintSubdirectoryCount();
            dirInfo.PrintParentDirectories();

            Console.WriteLine("Демонстрация работы класса SMAFileManager:");
            string diskPath = "C:\\"; // Задайте нужный путь к диску
            SMAFileManager fileManager = new SMAFileManager(diskPath);
            fileManager.PerformActions();

        }
    }
}
