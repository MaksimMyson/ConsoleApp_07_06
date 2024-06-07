using System;
using System.Text;
using System.Threading;

namespace ConsoleApp_07_06
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            // Введення користувачем меж діапазону чисел
            Console.Write("Введіть початок діапазону чисел: ");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть кінець діапазону чисел: ");
            int end = Convert.ToInt32(Console.ReadLine());

            // Введення користувачем кількості потоків
            Console.Write("Введіть кількість потоків: ");
            int threadCount = Convert.ToInt32(Console.ReadLine());

            // Створення та запуск потоків
            for (int i = 0; i < threadCount; i++)
            {
                Thread thread = new Thread(() => CountNumbers(start, end));
                thread.Start();
            }

            Console.WriteLine("Головний потік продовжує своє виконання...");
            Console.WriteLine("Натисніть Enter для завершення програми...");
            Console.ReadLine();
        }

        static void CountNumbers(int start, int end)
        {
            // Виведення чисел у вказаному діапазоні
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine($"Потік {Thread.CurrentThread.ManagedThreadId}: {i}");
                Thread.Sleep(200); // Затримка для відображення чисел з приривками
            }
        }
    }
}