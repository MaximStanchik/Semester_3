using System;
using System.IO;
using System.Linq;
using System.IO.Compression;

public class SMAFileManager
{
    private string diskPath;

    public SMAFileManager(string diskPath)
    {
        this.diskPath = diskPath;
    }

    public void PerformActions()
    {
        try
        {
            string inspectDirPath = Path.Combine(diskPath, "SMAInspect");
            Directory.CreateDirectory(inspectDirPath);
            Console.WriteLine($"Создан директорий SMAInspect: {inspectDirPath}");

            string dirInfoFilePath = Path.Combine(inspectDirPath, "SMAdirinfo.txt");
            using (StreamWriter writer = new StreamWriter(dirInfoFilePath))
            {
                writer.WriteLine($"Список файлов и папок на диске {diskPath}:");
                writer.WriteLine();

                foreach (string itemPath in Directory.GetFileSystemEntries(diskPath))
                {
                    writer.WriteLine(itemPath);
                }
            }
            Console.WriteLine($"Создан файл SMAdirinfo.txt в директории SMAInspect: {dirInfoFilePath}");

            string copyFilePath = Path.Combine(inspectDirPath, "SMAdirinfo_copy.txt");
            File.Copy(dirInfoFilePath, copyFilePath);
            Console.WriteLine($"Создана копия файла SMAdirinfo.txt: {copyFilePath}");

            string renamedCopyFilePath = Path.Combine(inspectDirPath, "SMAdirinfo_renamed.txt");
            File.Move(copyFilePath, renamedCopyFilePath);
            Console.WriteLine($"Файл SMAdirinfo_copy.txt переименован в SMAdirinfo_renamed.txt");

            File.Delete(dirInfoFilePath);
            Console.WriteLine($"Удален файл SMAdirinfo.txt");

            string filesDirPath = Path.Combine(diskPath, "SMAFiles");
            Directory.CreateDirectory(filesDirPath);
            Console.WriteLine($"Создан директорий SMAFiles: {filesDirPath}");

            string[] sourceFiles = Directory.GetFiles(diskPath, "*.*", SearchOption.AllDirectories)
                .Where(file => file.EndsWith(".txt"))
                .ToArray();

            foreach (string sourceFile in sourceFiles)
            {
                string destinationFile = Path.Combine(filesDirPath, Path.GetFileName(sourceFile));
                File.Copy(sourceFile, destinationFile);
            }
            Console.WriteLine($"Скопировано файлов в директорий SMAFiles: {sourceFiles.Length}");

            string movedDirPath = Path.Combine(inspectDirPath, "SMAFiles");
            Directory.Move(filesDirPath, movedDirPath);
            Console.WriteLine($"Директорий SMAFiles перемещен в директорий SMAInspect: {movedDirPath}");

            string archivePath = Path.Combine(inspectDirPath, "SMAFiles.zip");
            ZipFile.CreateFromDirectory(movedDirPath, archivePath);
            Console.WriteLine($"Создан архив из файлов директорий SMAFiles: {archivePath}");

            string extractedDirPath = Path.Combine(inspectDirPath, "ExtractedFiles");
            ZipFile.ExtractToDirectory(archivePath, extractedDirPath);
            Console.WriteLine($"Архив разархивирован в директорий ExtractedFiles: {extractedDirPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при выполнении действий: {ex.Message}");
        }
    }
}