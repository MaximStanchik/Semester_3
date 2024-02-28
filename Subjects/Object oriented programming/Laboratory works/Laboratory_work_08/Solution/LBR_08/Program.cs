using System;
public class User
{
    public string Name { get; set; }

    public event Action<string> Upgrade;
    public event Action<string> Work;
    public event Action<string> Message;

    public void PerformUpgrade(string softwareName)
    {
        OnUpgrade(softwareName);
    }

    public void PerformWork(string softwareName)
    {
        OnWork(softwareName);
    }

    public void SendMessage(string message)
    {
        OnMessage(message);
    }

    protected virtual void OnUpgrade(string softwareName)
    {
        Upgrade?.Invoke(softwareName);
    }

    protected virtual void OnWork(string softwareName)
    {
        Work?.Invoke(softwareName);
    }

    protected virtual void OnMessage(string message)
    {
        Message?.Invoke(message);
    }
}

public class Software
{
    public string Name { get; set; }
    public string Version { get; set; }

    public Software(string name, string version)
    {
        Name = name;
        Version = version;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        User user1 = new User { Name = "User1" };
        User user2 = new User { Name = "User2" };
        User user3 = new User { Name = "User3" };

        Software software1 = new Software("Software1", "1.0");
        Software software2 = new Software("Software2", "2.0");
        Software software3 = new Software("Software3", "3.0");

        user1.Upgrade += softwareName => Console.WriteLine($"{user1.Name} upgraded {softwareName}");
        user2.Work += WorkHandler;
        user3.Upgrade += softwareName =>
        {
            Console.WriteLine($"{user3.Name} upgraded {softwareName}");
            Console.WriteLine("Sending notification...");
        };
        user3.Message += message => Console.WriteLine($"Message: {message}");

        user1.PerformUpgrade(software1.Name);
        user2.PerformWork(software2.Name);
        user3.PerformUpgrade(software3.Name);
        user3.SendMessage("Hello!");

        Console.ReadLine();
    }

    static void WorkHandler(string softwareName)
    {
        Console.WriteLine($"Working on {softwareName}");
    }
}