//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Microsoft.VisualBasic;
using System;
using System.Text;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            /*--------------Task_1_a-----------------*/

            sbyte sbyteValue = 0;
            byte byteValue = 0;
            short shortValue = 0;
            ushort ushortValue = 0;
            int intValue = 0;
            uint uintValue = 0;
            long longValue = 0;
            ulong ulongValue = 0;
            char charValue = '0';
            float floatValue = 0;
            double doubleValue = 0;
            bool boolValue = false;
            decimal decimalValue = 0;
            string stringValue = string.Empty;
            object objectValue = 0;
            dynamic dynamicValue = 0;

            Console.Write("Введите значение для sbyte: ");
            sbyteValue = sbyte.Parse(Console.ReadLine());
            Console.WriteLine("Ваше значение: " + sbyteValue); //тут метод: контентенация--объединение строк

            Console.Write("Введите значение для byte: ");
            byteValue = byte.Parse(Console.ReadLine());
            Console.WriteLine("Ваше значение: " + byteValue);

            Console.Write("Введите значение для short: ");
            shortValue = short.Parse(Console.ReadLine());
            Console.WriteLine("Ваше значение: " + shortValue);

            Console.Write("Введите значение для ushort: ");
            ushortValue = ushort.Parse(Console.ReadLine());
            Console.WriteLine("Ваше значение: " + ushortValue);

            Console.Write("Введите значение для int: ");
            intValue = int.Parse(Console.ReadLine());
            Console.WriteLine("Ваше значение: " + intValue);

            Console.Write("Введите значение для uint: ");
            uintValue = uint.Parse(Console.ReadLine());
            Console.WriteLine("Ваше значение: " + uintValue);

            Console.Write("Введите значение для long: ");
            longValue = long.Parse(Console.ReadLine());
            Console.WriteLine("Ваше значение: " + longValue);

            Console.Write("Введите значение для ulong: ");
            ulongValue = ulong.Parse(Console.ReadLine());
            Console.WriteLine("Ваше значение: " + ulongValue);

            Console.Write("Введите значение для char: ");
            charValue = char.Parse(Console.ReadLine());
            Console.WriteLine("Ваше значение: " + charValue);

            Console.Write("Введите значение для float: ");
            floatValue = float.Parse(Console.ReadLine());
            Console.WriteLine("Ваше значение: " + floatValue);

            Console.Write("Введите значение для double: ");
            doubleValue = double.Parse(Console.ReadLine());
            Console.WriteLine("Ваше значение: " + doubleValue);

            Console.Write("Введите значение для bool: ");
            boolValue = bool.Parse(Console.ReadLine());
            Console.WriteLine("Ваше значение: " + boolValue);

            Console.Write("Введите значение для decimal: ");
            decimalValue = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ваше значение: " + decimalValue);

            Console.Write("Введите значение для string: ");
            stringValue = Console.ReadLine();
            Console.WriteLine("Ваше значение: " + stringValue);

            Console.Write("Введите значение для object: ");
            objectValue = Console.ReadLine();
            Console.WriteLine("Ваше значение: " + objectValue);

            Console.Write("Введите значение для dynamic: ");
            dynamicValue = Console.ReadLine();
            Console.WriteLine("Ваше значение: " + dynamicValue);

            /*--------------Task_1_b-----------------*/

            int explicit_conversion_a = 10;
            double explicit_conversion_b = (double)explicit_conversion_a;

            float explicit_conversion_c = 3.14f;
            int explicit_conversion_d = (int)explicit_conversion_c;

            short explicit_conversion_e = 5;
            byte explicit_conversion_f = (byte)explicit_conversion_e;

            long explicit_conversion_g = 123456789;
            int explicit_conversion_h = (int)explicit_conversion_g;

            double explicit_conversion_i = 3.1415926535897932384626433832795;
            decimal explicit_conversion_j = (decimal)explicit_conversion_i;


            int implicit_conversion_a = 10;
            float implicit_conversion_b = implicit_conversion_a;

            byte implicit_conversion_c = 255;
            int implicit_conversion_d = implicit_conversion_c;

            short implicit_conversion_e = 100;
            long implicit_conversion_f = implicit_conversion_e;

            float implicit_conversion_g = 3.14f;
            double implicit_conversion_h = implicit_conversion_g;

            char implicit_conversion_i = 'a';
            int implicit_conversion_j = implicit_conversion_i;

            /*--------------Task_1_c-----------------*/

            int a = 10;
            object b = a;

            object c = 20;
            int d = (int)c;

            /*--------------Task_1_d-----------------*/

            var name = "John";
            Console.WriteLine("Name: " + name);

            /*--------------Task_1_e-----------------*/

            int? age = null;

            if (age.HasValue)
            {
                Console.WriteLine("Age: " + age.Value);
            }
            else
            {
                Console.WriteLine("Age is not specified.");
            }

            /*--------------Task_1_f-----------------*/

            var myVar = 10;
            //myVar = "hello"; 
            //нужно раскоментировать, чтобы произишла ошибка компиляции

            /*--------------Task_2_a-----------------*/

            String string1 = "Hello";
            String string2 = "hello";
            bool result = string1.Equals(string2, StringComparison.CurrentCultureIgnoreCase);
            Console.WriteLine(result);

            /*--------------Task_2_b-----------------*/

            string str1 = "Hello";
            string str2 = "World";
            string str3 = "C#";

            string result1 = str1 + " " + str2; // "Hello World"

            string result2 = string.Copy(str1); // "Hello"

            string result3 = str1.Substring(0, 3); // "Hel"

            string[] words = result1.Split(' '); // ["Hello, World"]

            string result4 = str3.Insert(1, "sharp"); // "Csharp#"

            string result5 = str3.Remove(1, 1); // "C#"

            string myName = "Max";
            int myAge = 18;
            string message = $"Hi! I am {myName} and I am {age} y.o.";

            /*--------------Task_2_c-----------------*/

            string emptyString = "";
            string nullString = null;
            string non_emptyString = "abcdefg";

            bool isEmpty1 = string.IsNullOrEmpty(emptyString); // true
            bool isEmpty2 = string.IsNullOrEmpty(nullString); // true
            bool isEmpty3 = string.IsNullOrEmpty(non_emptyString); // false

            // Добавление подстроки в начало строки
            string newString1 = emptyString.Insert(0, "Hello"); // "Hello"

            string newString2 = emptyString.Insert(emptyString.Length, "World"); // "World"

            /*--------------Task_2_d-----------------*/

            StringBuilder sb = new StringBuilder();
            sb.Append("This is a simple string.");

            sb.Remove(5, 2);

            sb.Insert(0, "Hello ");

            sb.Append("!");

            string summaryLine = sb.ToString(); // "Hello is a simple string!"

            /*--------------Task_3_a-----------------*/

            int[,] matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            Console.WriteLine("Двумерный массив в отформатированном виде (матрица):");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            /*--------------Task_3_b-----------------*/
            
            string[] strings = new string[] { "Я", "люблю", "ООП" };
            Console.WriteLine("\nОдномерный массив строк:");
            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("Длина массива: " + strings.Length);

            Console.Write("\nВведите позицию элемента для изменения (от 1 до " + (strings.Length) + "): ");
            int position = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Введите новое значение элемента: ");
            string value = Console.ReadLine();
            strings[position] = value;
            Console.WriteLine("\nИзмененный одномерный массив строк:");
            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }

            /*--------------Task_3_c-----------------*/
            // Создание и вывод ступенчатого массива
            double[][] jaggedArray = new double[3][];
            jaggedArray[0] = new double[2];
            jaggedArray[1] = new double[3];
            jaggedArray[2] = new double[4];

            Console.WriteLine("\nСтупенчатый массив:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write("Введите значение для элемента [" + i + "][" + j + "]: ");
                    jaggedArray[i][j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            Console.WriteLine("\nСтупенчатый массив:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }

            /*--------------Task_3_d-----------------*/

            // Использование неявно типизированных переменных
            var array = new[] { 1, 2, 3, 4, 5 };
            var str_3d = "Пример строки";

            Console.WriteLine("\nНеявно типизированный массив:");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Неявно типизированная строка: " + str_3d);

            /*--------------Task_4_a-----------------*/

            var tuple = (42, "hello", 'a', "world", 123456789UL);

            /*--------------Task_4_b-----------------*/

            Console.WriteLine(tuple);
            Console.WriteLine(tuple.Item1); 
            Console.WriteLine(tuple.Item3); 
            Console.WriteLine(tuple.Item4);

            /*--------------Task_4_c-----------------*/

            var (first, second, third, fourth, fifth) = tuple;

            var first_element_var = tuple.Item1;
            var second_element_var = tuple.Item2;
            var third_element_var = tuple.Item3;
            var fourth_element_var = tuple.Item4;
            var fifth_element_var = tuple.Item5;

            int first_element_int = tuple.Item1;
            string second_element_string = tuple.Item2;
            char third_element_char = tuple.Item3;
            string fourth_element_string = tuple.Item4;
            ulong fifth_element_ulong = tuple.Item5;

            /*--------------Task_4_d-----------------*/

            var tuple1 = (1, "hello");
            var tuple2 = (1, "world");

            if (tuple1 == tuple2)
            {
                Console.WriteLine("Tuples equal");
            }
            else
            {
                Console.WriteLine("Tuples are not equal");
            }

            /*--------------Task_5-----------------*/

            (int, int, int, char) LocalFunction(int[] numbers, string str1)
            {
                int max = numbers[0];
                int min = numbers[0];
                int sum = 0;

                for(int i=0; i < numbers.Length; i++)
                {
                    if (numbers[i]> max)
                    {
                        max = numbers[i];
                    }
                    if (numbers[i] < min)
                    {
                        min = numbers[i];
                    }
                    sum += numbers[i];
                }
                char smb = str1[0];
                var tuple1 = (max, min, sum, smb);
                return tuple1;
            }

            //int nums[] = new int[4];
            //nums[0]= 23;
            //nums[1] = 243;
            //nums[2] = 223;
            //string str = "qweee";
            //Console.WriteLine(LocalFunction();

            /*--------------Task_6-----------------*/

            void CheckedFunction()
            {
                checked
                {
                    int maxInt = int.MaxValue;
                    Console.WriteLine($"Максимальное значение int в режиме checked: {maxInt}");
                }
            }

            void UncheckedFunction()
            {
                unchecked
                {
                    int maxInt = int.MaxValue + 1;
                    Console.WriteLine($"Максимальное значение int в режиме unchecked: {maxInt}");
                }
            }
            CheckedFunction();
            UncheckedFunction();

        }
    }


}
    



