using System;

class Printer
{
    public void Print(INameable obj)
    {
        Console.WriteLine(obj.ToString());
    }
}
