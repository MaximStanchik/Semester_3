using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// Интерфейс, определяющий поведение фигуры
public interface IShape
{
    double CalculateArea();
}

// Класс, представляющий геометрическую фигуру
public class Shape : IShape
{
    public string Type { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }

    public double CalculateArea()
    {
        return Width * Height;
    }
}

// Класс, управляющий коллекцией фигур
public class ShapeCollection : IEnumerable<Shape>
{
    private Stack<Shape> shapes = new Stack<Shape>();

    public void AddShape(Shape shape)
    {
        shapes.Push(shape);
    }

    public void RemoveShape()
    {
        if (shapes.Count > 0)
        {
            shapes.Pop();
        }
    }

    public Shape FindShape(string type)
    {
        foreach (Shape shape in shapes)
        {
            if (shape.Type == type)
            {
                return shape;
            }
        }
        return null;
    }

    public void PrintAllShapes()
    {
        Console.WriteLine("All Shapes:");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Type: {shape.Type}, Area: {shape.CalculateArea()}");
        }
    }

    // Реализация методов интерфейса IEnumerator
    public IEnumerator<Shape> GetEnumerator()
    {
        return shapes.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
public class CustomType
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class Program
{
    public static void Main()
    {
        List<CustomType> collection = new List<CustomType>
        {
            new CustomType { Id = 1, Name = "Item 1" },
            new CustomType { Id = 2, Name = "Item 2" },
            new CustomType { Id = 3, Name = "Item 3" },
            new CustomType { Id = 4, Name = "Item 4" },
            new CustomType { Id = 5, Name = "Item 5" }
        };

        // Вывод коллекции на консоль
        Console.WriteLine("Collection:");
        foreach (CustomType item in collection)
        {
            Console.WriteLine($"Id: {item.Id}, Name: {item.Name}");
        }

        // Удаление n последовательных элементов из коллекции
        int n = 2;
        collection.RemoveRange(0, n);

        // Добавление других элементов в коллекцию
        collection.Add(new CustomType { Id = 6, Name = "Item 6" });
        collection.Insert(0, new CustomType { Id = 0, Name = "Item 0" });
        collection.AddRange(new List<CustomType>
        {
            new CustomType { Id = 7, Name = "Item 7" },
            new CustomType { Id = 8, Name = "Item 8" },
            new CustomType { Id = 9, Name = "Item 9" }
        });

        // Создание второй коллекции Dictionary<int, CustomType> и заполнение ее данными из первой коллекции
        Dictionary<int, CustomType> secondCollection = new Dictionary<int, CustomType>();
        for (int i = 0; i < collection.Count; i++)
        {
            secondCollection[i] = collection[i];
        }

        // Вывод второй коллекции на консоль
        Console.WriteLine("Second Collection:");
        foreach (KeyValuePair<int, CustomType> item in secondCollection)
        {
            Console.WriteLine($"Key: {item.Key}, Value: Id: {item.Value.Id}, Name: {item.Value.Name}");
        }

        // Найдите во второй коллекции заданное значение
        int searchId = 5;
        bool found = false;
        foreach (CustomType item in secondCollection.Values)
        {
            if (item.Id == searchId)
            {
                found = true;
                break;
            }
        }
        Console.WriteLine($"Search Id '{searchId}' found in second collection: {found}");

        // Создание объекта наблюдаемой коллекции ObservableCollection<CustomType>
        ObservableCollection<CustomType> observableCollection = new ObservableCollection<CustomType>();

        // Регистрация метода на событие CollectionChanged
        observableCollection.CollectionChanged += CollectionChangedHandler;

        // Добавление и удаление элементов из наблюдаемой коллекции
        observableCollection.Add(new CustomType { Id = 10, Name = "Item 10" });
        observableCollection.Add(new CustomType { Id = 11, Name = "Item 11" });
        observableCollection.RemoveAt(0);

        // Вспомогательный метод-обработчик события CollectionChanged
        static void CollectionChangedHandler(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Collection changed!");
        }
        ShapeCollection collection = new ShapeCollection();

        while (true)
        {
            Console.WriteLine("1. Add Shape");
            Console.WriteLine("2. Remove Shape");
            Console.WriteLine("3. Find Shape");
            Console.WriteLine("4. Print All Shapes");
            Console.WriteLine("5. Exit");
            Console.WriteLine();

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddShape(shape);
                    break;
                case "2":
                    RemoveShape(collection);
                    break;
                case "3":
                    FindShape(collection);
                    break;
                case "4":
                    PrintAllShapes(collection);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }


    public static void AddShape(ShapeCollection collection)
    {

        Console.WriteLine("Enter shape details:");

        Console.Write("Type: ");
        string type = Console.ReadLine();

        Console.Write("Width: ");
        double width = Convert.ToDouble(Console.ReadLine());

        Console.Write("Height: ");
        double height = Convert.ToDouble(Console.ReadLine());

        Shape shape = new Shape { Type = type, Width = width, Height = height };
        collection.AddShape(shape);

        Console.WriteLine("Shape added successfully.");
    }

    public static void RemoveShape(ShapeCollection collection)
    {
        if (collection.GetEnumerator().MoveNext())
        {
            collection.RemoveShape();
            Console.WriteLine("Shape removed successfully.");
        }
        else
        {
            Console.WriteLine("No shapes in the collection to remove.");
        }
    }

    public static void FindShape(ShapeCollection collection)
    {
        Console.Write("Enter shape type to search: ");
        string type = Console.ReadLine();

        Shape foundShape = collection.FindShape(type);
        if (foundShape != null)
        {
            Console.WriteLine($"Found Shape: Type: {foundShape.Type}, Area: {foundShape.CalculateArea()}");
        }
        else
        {
            Console.WriteLine($"Shape of type '{type}' not found.");
        }
    }

    public static void PrintAllShapes(ShapeCollection collection)
    {
        collection.PrintAllShapes();
    }
}