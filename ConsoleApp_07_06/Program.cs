using System;
using System.Threading;

namespace ConsoleApp_07_06
{
    class Program
    {

        static void Main(string[] args)
        {
            // Створення та запуск потоку
            Thread thread = new Thread(CountNumbers);
            thread.Start();

            // Головний потік виконує інші дії
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Головний потік: {i}");
                Thread.Sleep(500); // Затримка для імітації інших операцій
            }

            Console.WriteLine("Натисніть Enter для завершення програми...");
            Console.ReadLine();
        }

        static void CountNumbers()
        {
            // Виведення чисел від 0 до 50
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine($"Потік: {i}");
                Thread.Sleep(200); // Затримка для відображення чисел з приривками
            }
        }
    }
}
