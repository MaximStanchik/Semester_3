using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

public static class Reflector
{
    public static void Main(string[] args)
    {
        string className = "Train";
        string outputPath = "TrainClassInfo.txt";
        OutputFormat outputFormat = OutputFormat.Text;

        ExploreClass(className, outputPath, outputFormat);
    }
    public static void ExploreClass(string className, string outputPath, OutputFormat outputFormat)
    {
        Type targetType = Type.GetType(className);

        if (targetType == null)
        {
            Console.WriteLine($"Class '{className}' not found.");
            return;
        }

        Assembly assembly = targetType.Assembly;
        bool hasPublicConstructors = targetType.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Length > 0;
        IEnumerable<string> publicMethods = GetPublicMethods(targetType);
        IEnumerable<string> fieldsAndProperties = GetFieldsAndProperties(targetType);
        IEnumerable<string> implementedInterfaces = GetImplementedInterfaces(targetType);

        ClassInfo classInfo = new ClassInfo
        {
            AssemblyName = assembly.FullName,
            HasPublicConstructors = hasPublicConstructors,
            PublicMethods = publicMethods.ToList(),
            FieldsAndProperties = fieldsAndProperties.ToList(),
            ImplementedInterfaces = implementedInterfaces.ToList()
        };

        string serializedInfo = Serialize(classInfo, outputFormat);

        File.WriteAllText(outputPath, serializedInfo);
        Console.WriteLine($"Class information saved to '{outputPath}'.");
    }

    public static IEnumerable<string> GetPublicMethods(Type targetType)
    {
        return targetType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Select(method => method.Name);
    }

    public static IEnumerable<string> GetFieldsAndProperties(Type targetType)
    {
        IEnumerable<string> fields = targetType.GetFields(BindingFlags.Public | BindingFlags.Instance)
            .Select(field => field.Name);

        IEnumerable<string> properties = targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Select(property => property.Name);

        return fields.Concat(properties);
    }

    public static IEnumerable<string> GetImplementedInterfaces(Type targetType)
    {
        return targetType.GetInterfaces()
            .Select(interfac => interfac.Name);
    }

    public static IEnumerable<string> GetMethodsByParameterType(string className, Type parameterType)
    {
        Type targetType = Type.GetType(className);

        if (targetType == null)
        {
            Console.WriteLine($"Class '{className}' not found.");
            return Enumerable.Empty<string>();
        }

        return targetType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(method => method.GetParameters().Any(param => param.ParameterType == parameterType))
            .Select(method => method.Name);
    }

    public static void InvokeMethodFromFile(string className, string methodName, string parameterFilePath)
    {
        Type targetType = Type.GetType(className);

        if (targetType == null)
        {
            Console.WriteLine($"Class '{className}' not found.");
            return;
        }

        MethodInfo method = targetType.GetMethod(methodName);

        if (method == null)
        {
            Console.WriteLine($"Method '{methodName}' not found in class '{className}'.");
            return;
        }

        object instance = Activator.CreateInstance(targetType);
        object[] parameters = ReadParametersFromFile(parameterFilePath, method.GetParameters());

        try
        {
            object result = method.Invoke(instance, parameters);
            Console.WriteLine($"Method '{methodName}' invoked successfully. Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to invoke method '{methodName}'. Error: {ex.Message}");
        }
    }

    public static T Create<T>()
    {
        Type targetType = typeof(T);

        if (!targetType.IsClass || targetType.IsAbstract)
        {
            Console.WriteLine($"Cannot create an instance of type '{targetType.FullName}'.");
            return default;
        }

        ConstructorInfo[] constructors = targetType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

        if (constructors.Length == 0)
        {
            Console.WriteLine($"No public constructors found for type '{targetType.FullName}'.");
            return default;
        }

        ConstructorInfo constructor = constructors[0];

        try
        {
            object instance = constructor.Invoke(null);
            return (T)instance;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to create an instance of type '{targetType.FullName}'. Error: {ex.Message}");
            return default;
        }
    }
    private static object[] ReadParametersFromFile(string parameterFilePath, ParameterInfo[] parameters)
    {
        string[] lines = File.ReadAllLines(parameterFilePath);

        if (lines.Length != parameters.Length)
        {
            Console.WriteLine("Number of parameters in the file does not match the method's parameter count.");
            return null;
        }

        object[] parameterValues = new object[parameters.Length];

        for (int i = 0; i < parameters.Length; i++)
        {
            Type parameterType = parameters[i].ParameterType;
            object parameterValue = Convert.ChangeType(lines[i], parameterType);
            parameterValues[i] = parameterValue;
        }

        return parameterValues;
    }

    private static string Serialize(ClassInfo classInfo, OutputFormat outputFormat)
    {
        switch (outputFormat)
        {
            case OutputFormat.Text:
                return classInfo.ToString();
            case OutputFormat.Json:
                return JsonConvert.SerializeObject(classInfo, Newtonsoft.Json.Formatting.Indented);
            case OutputFormat.Xml:
                var serializer = new XmlSerializer(typeof(ClassInfo));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    serializer.Serialize(writer, classInfo);
                }
                return stringWriter.ToString();
            default:
                throw new NotSupportedException($"Output format '{outputFormat}' is not supported.");
        }
    }

}

public enum OutputFormat
{
    Text,
    Json,
    Xml
}

public class ClassInfo
{
    public string AssemblyName { get; set; }
    public bool HasPublicConstructors { get; set; }
    public List<string> PublicMethods { get; set; }
    public List<string> FieldsAndProperties { get; set; }
    public List<string> ImplementedInterfaces { get; set; }

    public override string ToString()
    {
        return $"Assembly Name: {AssemblyName}\n" +
               $"Has Public Constructors: {HasPublicConstructors}\n" +
               $"Public Methods: {string.Join(", ", PublicMethods)}\n" +
               $"Fields and Properties: {string.Join(", ", FieldsAndProperties)}\n" +
               $"Implemented Interfaces: {string.Join(", ", ImplementedInterfaces)}";
    }
}

class Train
{
    private static int numOfTrains = 0;

    public string Destination { get; private set; }
    public int TrainNumber { get; private set; }
    public DateTime DepartureTime { get; private set; }
    public int CommonSeats { get; private set; }
    public int CoupeSeats { get; private set; }
    public int ReservedSeats { get; private set; }
    public int LuxurySeats { get; private set; }

    public static int NumOfTrains { get { return numOfTrains; } }

    public Train(string destination, int trainNumber, DateTime departureTime, int commonSeats, int coupeSeats, int reservedSeats, int luxurySeats)
    {
        Destination = destination;
        TrainNumber = trainNumber;
        DepartureTime = departureTime;
        CommonSeats = commonSeats;
        CoupeSeats = coupeSeats;
        ReservedSeats = reservedSeats;
        LuxurySeats = luxurySeats;

        numOfTrains++;
    }

    public static void PrintTrainInfo()
    {
        Console.WriteLine($"Количество созданных объектов класса Train: {NumOfTrains}");
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Train otherTrain = (Train)obj;
        return TrainNumber == otherTrain.TrainNumber;
    }

    public override int GetHashCode()
    {
        return TrainNumber.GetHashCode();
    }

    public override string ToString()
    {
        return $"Поезд номер {TrainNumber}, отправление в {DepartureTime}";
    }
}