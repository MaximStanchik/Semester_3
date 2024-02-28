using System;
using System.IO;

public class SMADiskInfo
{
    public void PrintFreeSpace(string drive)
    {
        try
        {
            DriveInfo driveInfo = new DriveInfo(drive);
            long freeSpace = driveInfo.AvailableFreeSpace;
            Console.WriteLine($"Свободное место на диске {drive}: {freeSpace} байт");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении информации о свободном месте на диске {drive}: {ex.Message}");
        }
    }

    public void PrintFileSystem(string drive)
    {
        try
        {
            DriveInfo driveInfo = new DriveInfo(drive);
            string fileSystem = driveInfo.DriveFormat;
            Console.WriteLine($"Файловая система диска {drive}: {fileSystem}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении информации о файловой системе диска {drive}: {ex.Message}");
        }
    }

    public void PrintDriveInfo()
    {
        try
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo driveInfo in drives)
            {
                Console.WriteLine($"Диск: {driveInfo.Name}");
                Console.WriteLine($"Объем диска: {driveInfo.TotalSize} байт");
                Console.WriteLine($"Свободное место: {driveInfo.AvailableFreeSpace} байт");
                Console.WriteLine($"Метка тома: {driveInfo.VolumeLabel}");
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении информации о дисках: {ex.Message}");
        }
    }
}