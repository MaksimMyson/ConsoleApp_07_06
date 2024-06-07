using System;
using System.IO;
using System.Text;
using System.Threading;

namespace ConsoleApp_07_06
{
    class Program
    {
        static int[] numbers = new int[10000];
        static int minValue, maxValue;
        static double averageValue;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            // Генерація набору чисел
            GenerateNumbers();

            // Створення та запуск потоків
            Thread minThread = new Thread(FindMin);
            Thread maxThread = new Thread(FindMax);
            Thread avgThread = new Thread(FindAverage);
            Thread printThread = new Thread(PrintToFile);

            minThread.Start();
            maxThread.Start();
            avgThread.Start();
            printThread.Start();

            // Очікування завершення роботи потоків
            minThread.Join();
            maxThread.Join();
            avgThread.Join();
            printThread.Join();

            Console.WriteLine("Всі обчислення завершено.");
            Console.WriteLine("Результати збережено у файлі 'results.txt'.");
        }

        static void GenerateNumbers()
        {
            Random rand = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(1000); // Генеруємо випадкове число від 0 до 999
            }
        }

        static void FindMin()
        {
            minValue = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < minValue)
                {
                    minValue = numbers[i];
                }
            }
        }

        static void FindMax()
        {
            maxValue = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > maxValue)
                {
                    maxValue = numbers[i];
                }
            }
        }

        static void FindAverage()
        {
            int sum = 0;

            foreach (int num in numbers)
            {
                sum += num;
            }

            averageValue = (double)sum / numbers.Length;
        }

        static void PrintToFile()
        {
            using (StreamWriter writer = new StreamWriter("results.txt"))
            {
                writer.WriteLine($"Мінімум: {minValue}");
                writer.WriteLine($"Максимум: {maxValue}");
                writer.WriteLine($"Середнє: {averageValue}");
            }
        }
    }
}
