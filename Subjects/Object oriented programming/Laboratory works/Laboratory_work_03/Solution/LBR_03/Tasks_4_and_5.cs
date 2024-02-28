using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public static class StatisticOperation
    {
        // Метод для подсчета суммы длин нескольких слов
        public static int SumWordLengths(List<string> words)
        {
            return words.Sum(word => word.Length);
        }

        // Метод для вычисления разницы в количестве символов между максимальным и минимальным словом
        public static int DifferenceBetweenMaxAndMinWords(List<string> words)
        {
            if (words.Count == 0)
            {
                throw new ArgumentException("Список слов не должен быть пустым");
            }

            int maxLength = words.Max(word => word.Length);
            int minLength = words.Min(word => word.Length);

            return maxLength - minLength;
        }

        // Метод для подсчета количества слов
        public static int CountWords(List<string> words)
        {
            return words.Count;
        }
    }
}
