using System;
using System.Collections.Generic;

namespace Main
{
    static class List
    {
        static void Main() //main в другом месте. должен быть в классе программ. Тут создаю экземпляры класса лист и что-то тут делаю
        {
            Console.WriteLine("Здравствуйте. Введите цифру чтобы:");
            Console.WriteLine("1--подсчёт количества слов");
            Console.WriteLine("2--проверка на нулевые элементы в списке");
            Console.WriteLine("Любая другая клавиша--выйти из программы");
            int switchNum_1 = Convert.ToInt32(Console.ReadLine());

            switch (switchNum_1)
            {
                case 1:
                    Console.WriteLine($"Вы ввели {switchNum_1}");

                    Console.WriteLine("Введите строку:");
                    string text = Console.ReadLine() ?? "null";

                    Console.WriteLine("Хотите внести изменения?:");
                    Console.WriteLine("1--Да");
                    Console.WriteLine("2--Нет");
                    Console.WriteLine("Любая другая клавиша--оставить все как есть");
                    int switchNum_2 = Convert.ToInt32(Console.ReadLine());
                    switch (switchNum_2)
                    {
                        case 1:
                            Console.WriteLine("1--Добавить элемент в конец:");
                            Console.WriteLine("2--Удалить элемент из конца:");
                            Console.WriteLine("3--Проверка на неравенство:");
                            Console.WriteLine("4--Проверка упорядоченности элементов:");
                            int switchNum_3 = Convert.ToInt32(Console.ReadLine());
                            switch (switchNum_3)
                            {
                                case 1:
                                    Console.WriteLine("Введите элемент, который нужно добавить");
                                    string item = Console.ReadLine() ?? "null";
                                    AddItemToEnd(text, item);  //методы расширения просмотреть--добавление функциональсти типу. Перегрузка делается чеерез <(класс меньше класса)
                                    string newText = text.AddItemToEnd(item);
                                    Console.WriteLine($"Преобразованная строка: {newText}");
                                    break;
                                case 2:
                                    RemoveItemFromEnd(text);
                                    break;
                                case 3:

                                    break;    //реализация списков на c#
                                case 4:

                                    break;
                                default:

                                    break;
                            }
                            break;
                        default:
                            string[] ArrayOfText = SplitTextToArray(text);

                            Console.WriteLine("Всего слов в тексте: " + ArrayOfText.Length);

                            break;
                    }

                    break;
                case 2:
                    Console.WriteLine($"Вы ввели {switchNum_1}");
                    Console.WriteLine("Скоро будет добавлено!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Программа закончит своё выполнение");
                    Environment.Exit(0);
                    break;
            }

        }
        public static string[] SplitTextToArray(string text)
        {
            text = text.Trim(new char[] { ',', '.' });
            string[] textArray = text.Split(new char[] { ' ' });
            return textArray;
        }

        public static string AddItemToEnd(this string text, string item)
        {
            string[] textArray = SplitTextToArray(text);

            // Добавляем элемент в конец массива строк
            Array.Resize(ref textArray, textArray.Length + 1);
            textArray[textArray.Length - 1] = item;

            // Соединяем элементы массива обратно в строку
            string newText = string.Join(" ", textArray);
            return newText;
        }

        public static string RemoveItemFromEnd(this string text)
        {
            string[] textArray = SplitTextToArray(text);

            // Удаляем последний элемент массива строк
            Array.Resize(ref textArray, textArray.Length - 1);

            // Соединяем элементы массива обратно в строку
            string removedText = string.Join(" ", textArray);
            return removedText;
        }
        public class Developer //в листе должен быть в листе
        {
            public int id;
            public string name;
            public string department;
            public Developer(int id, string name, string department)
            {
                this.id = id;
                this.name = name;
                this.department = department;
            }
            public void Show()
            {
                Console.WriteLine("ID: " + id);
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Department: " + department);
            }
        }

        public class Production //в отдельном файле и должен быть как поле класса лист
        {
            public int id;
            public string nameOrganization;
            public Production(int id, string nameOrganization)
            {
                this.id = id;
                this.nameOrganization = nameOrganization;
            }
            public void Show()
            {
                Console.WriteLine("ID Organization: " + id);
                Console.WriteLine("Name Organization: " + nameOrganization);
            }
        }

    }



}

