using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Xml.XPath;

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car { Name = "MyCar", MaxSpeed = 200, NumberOfDoors = 4 };

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream("car.bin", FileMode.Create))
        {
            binaryFormatter.Serialize(fileStream, car);
        }

        using (FileStream fileStream = new FileStream("car.bin", FileMode.Open))
        {
            Car deserializedCar = (Car)binaryFormatter.Deserialize(fileStream);
            Console.WriteLine($"Deserialized Car - Name: {deserializedCar.Name}, Max Speed: {deserializedCar.MaxSpeed}, Number of Doors: {deserializedCar.NumberOfDoors}");
        }

        SoapFormatter soapFormatter = new SoapFormatter();
        using (FileStream fileStream = new FileStream("car.soap", FileMode.Create))
        {
            soapFormatter.Serialize(fileStream, car);
        }

        using (FileStream fileStream = new FileStream("car.soap", FileMode.Open))
        {
            Car deserializedCar = (Car)soapFormatter.Deserialize(fileStream);
            Console.WriteLine($"Deserialized Car - Name: {deserializedCar.Name}, Max Speed: {deserializedCar.MaxSpeed}, Number of Doors: {deserializedCar.NumberOfDoors}");
        }

        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Car));
        using (FileStream fileStream = new FileStream("car.json", FileMode.Create))
        {
            jsonSerializer.WriteObject(fileStream, car);
        }

        using (FileStream fileStream = new FileStream("car.json", FileMode.Open))
        {
            Car deserializedCar = (Car)jsonSerializer.ReadObject(fileStream);
            Console.WriteLine($"Deserialized Car - Name: {deserializedCar.Name}, Max Speed: {deserializedCar.MaxSpeed}, Number of Doors: {deserializedCar.NumberOfDoors}");
        }

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Car));
        using (FileStream fileStream = new FileStream("car.xml", FileMode.Create))
        {
            xmlSerializer.Serialize(fileStream, car);
        }

        using (FileStream fileStream = new FileStream("car.xml", FileMode.Open))
        {
            Car deserializedCar = (Car)xmlSerializer.Deserialize(fileStream);
            Console.WriteLine($"Deserialized Car - Name: {deserializedCar.Name}, Max Speed: {deserializedCar.MaxSpeed}, Number of Doors: {deserializedCar.NumberOfDoors}");
        }

        Car[] cars = new Car[]
        {
            new Car { Name = "Car1", MaxSpeed = 200, NumberOfDoors = 4 },
            new Car { Name = "Car2", MaxSpeed = 180, NumberOfDoors = 2 },
            new Car { Name = "Car3", MaxSpeed = 220, NumberOfDoors = 4 }
        };

       
        BinaryFormatter binaryFormatterOfCar = new BinaryFormatter();
        using (FileStream fileStream = new FileStream("cars.bin", FileMode.Create))
        {
            binaryFormatterOfCar.Serialize(fileStream, cars);
        }

        
        using (FileStream fileStream = new FileStream("cars.bin", FileMode.Open))
        {
            Car[] deserializedCars = (Car[])binaryFormatter.Deserialize(fileStream);
            foreach (Car car_task2 in deserializedCars)
            {
                Console.WriteLine($"Deserialized Car - Name: {car_task2.Name}, Max Speed: {car_task2.MaxSpeed}, Number of Doors: {car_task2.NumberOfDoors}");
            }
        }

        string xml_task3 = "<vehicles><car><name>Car1</name><maxSpeed>200</maxSpeed><numberOfDoors>4</numberOfDoors></car><car><name>Car2</name><maxSpeed>180</maxSpeed><numberOfDoors>2</numberOfDoors></car><car><name>Car3</name><maxSpeed>220</maxSpeed><numberOfDoors>4</numberOfDoors></car></vehicles>";

        XPathDocument document_task3 = new XPathDocument(new StringReader(xml_task3));
        XPathNavigator navigator_task3 = document_task3.CreateNavigator();

        XPathNodeIterator iterator_task3 = navigator_task3.Select("//name");
        while (iterator_task3.MoveNext())
        {
            Console.WriteLine(iterator_task3.Current.Value);
        }

        string xml_task4 = "<vehicles><car><name>Car1</name><maxSpeed>200</maxSpeed><numberOfDoors>4</numberOfDoors></car><car><name>Car2</name><maxSpeed>180</maxSpeed><numberOfDoors>2</numberOfDoors></car><car><name>Car3</name><maxSpeed>220</maxSpeed><numberOfDoors>4</numberOfDoors></car></vehicles>";

        XPathDocument document_task4 = new XPathDocument(new StringReader(xml_task4));
        XPathNavigator navigator_task4 = document_task4.CreateNavigator();

        XPathNodeIterator iterator_task4 = navigator_task4.Select("//car");
        while (iterator_task4.MoveNext())
        {
            string name_task4 = iterator_task4.Current.SelectSingleNode("name").Value;
            string maxSpeed_task4 = iterator_task4.Current.SelectSingleNode("maxSpeed").Value;
            string numberOfDoors_task4 = iterator_task4.Current.SelectSingleNode("numberOfDoors").Value;

            Console.WriteLine($"Name: {name_task4}, Max Speed: {maxSpeed_task4}, Number of Doors: {numberOfDoors_task4}");
        }
    }
}