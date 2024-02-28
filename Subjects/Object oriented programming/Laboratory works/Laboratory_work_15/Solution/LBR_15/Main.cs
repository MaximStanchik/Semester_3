using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Collections.Concurrent;
using CheckingValues;
using PrimeNumbers;
using Matrix;
using SuppliersAndBuyersOfEquipment;
using ContinuationTask;

namespace LBR_15
{
    internal class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Здравствуйте!");
            Console.WriteLine("Нажмите нужную клавишу:");
            Console.WriteLine("1--Перейти к выполнению первого заданию");
            Console.WriteLine("2--Перейти к выпоолнению дополнительного задания для первого задания");
            Console.WriteLine("3--Перейти к выполнению третьего задания");
            Console.WriteLine("4--Перейти к выполнению четвертого задания");
            Console.WriteLine("4--Перейти к выполнению пятого задания");
            Console.WriteLine("(Шестое задание представляет собой модификацию первого задания с помощью Parallel.Invoke())");
            Console.WriteLine("7--Перейти к выполнению седьмого задания");
            Console.WriteLine("(Восьмое задание реализовано в методе)");
            Console.WriteLine("9--Выход из программы");
            switch (InputValidator.ReadPositiveIntegerInput())
            {
                case 1:
                    {
                        Console.WriteLine("Реализация первого задания:");
                        await SearchForPrimeNumbers.PerformFirstTaskAsync();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Введите число больше или равное 2, до которого Вы хотите найти все простые числа:");
                        int userSpecifiedValue = InputValidator.ReadPositiveIntegerInput();
                        if (userSpecifiedValue < 2)
                        {
                            Console.WriteLine("Вы ввели число меньше двух");
                        }
                        else
                        {
                            Console.WriteLine("Реализация дополнительного задания:");
                            SearchForPrimeNumbers.PerformAdditionalTask(userSpecifiedValue);
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Вы бы хотели перемножить две случайные матрицы или создать собственные?");
                        Console.WriteLine("1--Перемножить две случайные матрицы");
                        Console.WriteLine("2--Создать собственные матрицы и перемножить их");
                        Console.WriteLine("3--Выход из программы");
                        int choiceOfImplementationOfTheSecondTask = InputValidator.ReadPositiveIntegerInput();
                        switch (choiceOfImplementationOfTheSecondTask)
                        {
                            case 1:
                                {
                                    int[,] matrix1 = {
                                        { 1, 2, 3 },
                                        { 4, 5, 6 }
                                    };


                                    int[,] matrix2 = {
                                         { 7,  8  },
                                         { 9,  10 },
                                         { 11, 12 }
                                    };

                                    MatrixMultiplicationAndOutput.MultiplyOrCancelAnOperation(matrix1, matrix2);

                                    break;
                                }
                            case 2:
                                {
                                    MatrixMultiplicationAndOutput.CreateAndMultiplyMatrices();
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine("Программа закончила своё выполнение");
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Введено неверное значение. Автоматический выход из программы");
                                    break;
                                }
                        }
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Реализация четвертого задания C ContinueWith ");
                        MethodsForImplementingTwoVariantsOfTheTask.PerformFourthTaskInFirstVariant();
                        Console.WriteLine("Реализация четвертого задания на основе объекта ожидания и методов GetAwaiter(),GetResult(): ");
                        MethodsForImplementingTwoVariantsOfTheTask.PerformFourthTaskInSecondVariant();
                        break;
                    }

                case 7:
                    {
                        BuyingAndSellingGoods.PerformTheSeventhTask();
                        break;
                    }
                case 9:
                    {
                        Console.WriteLine("Программа закончила своё выполнение");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Введено неверное значение. Автоматический выход из программы");
                        break;
                    }
            }
        }
    }
}
