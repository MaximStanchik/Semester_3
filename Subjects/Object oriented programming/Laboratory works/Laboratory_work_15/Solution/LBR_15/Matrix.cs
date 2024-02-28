using CheckingValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Matrix
{
    internal static class MatrixMultiplicationAndOutput
    {
        public static void CreateAndMultiplyMatrices()
        {
            Console.Write("Введите количество строк для первой матрицы: ");
            int numberOfRowsOfTheFirstMatrix = InputValidator.ReadPositiveIntegerInput();

            Console.Write("Введите количество столбцов для первой матрицы: ");
            int numberOfColumnsOfTheFirstMatrix = InputValidator.ReadPositiveIntegerInput();

            Console.Write("Введите количество строк для второй матрицы: ");
            int numberOfRowsOfTheSecondMatrix = InputValidator.ReadPositiveIntegerInput();

            Console.Write("Введите количество столбцов для второй матрицы: ");
            int numberOfColumnsOfTheSecondMatrix =  InputValidator.ReadPositiveIntegerInput();

            if (numberOfColumnsOfTheFirstMatrix != numberOfRowsOfTheSecondMatrix)
            {
                Console.WriteLine("Умножение матриц невозможно. Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
                return;
            }

            int[,] matrix1 = CreateMatrix(numberOfRowsOfTheFirstMatrix, numberOfColumnsOfTheFirstMatrix);
            int[,] matrix2 = CreateMatrix(numberOfRowsOfTheSecondMatrix, numberOfColumnsOfTheSecondMatrix);

            MultiplyOrCancelAnOperation(matrix1, matrix2);
        }
        public static int[,] CreateMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("Введите значение для элемента [{0},{1}]: ", i, j);
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int value))
                    {
                        matrix[i, j] = value;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Повторите попытку.");
                        j--;
                    }
                }
            }

            return matrix;
        }
        public static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2, CancellationToken cancellationToken)
        {
            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);
            int cols2 = matrix2.GetLength(1);

            int[,] result = new int[rows1, cols2];

            for (int i = 0; i < rows1; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Операция была отменена.");
                    return null;
                }

                for (int j = 0; j < cols2; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < cols1; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }
        public static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public static void MultiplyOrCancelAnOperation(int[,] matrix1, int[,] matrix2)
        {
            using (var cts = new CancellationTokenSource())
            {
                Console.WriteLine("Для отмены операции умножения матриц нажмите клавишу 'Q'.");

                var multiplicationThread = new Thread(() =>
                {
                    int[,] result = MultiplyMatrices(matrix1, matrix2, cts.Token);
                    if (result != null)
                    {
                        Console.WriteLine("Результат умножения матриц:");
                        PrintMatrix(result);
                    }
                });

                multiplicationThread.Start();

                if (Console.ReadKey(true).Key == ConsoleKey.Q)
                {
                    cts.Cancel();
                }

                multiplicationThread.Join();
            }
        }
    }
}
