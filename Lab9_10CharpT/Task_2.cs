using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Task_2
{
    public class Task_2
    {
        static void PrintQueue(Queue<int> queue)
        {
            while (queue.Count > 0)
            {
                Console.Write(queue.Dequeue() + " ");
            }
            Console.WriteLine();
        }

        public void main2()
        {
            string fileName = "C:/Users/Smart/OneDrive/Робочий стіл/C#/csharplab9-Antonio8315/Lab9_10CharpT/FilesTask2/numbers.txt";
            int a = 10;
            int b = 20;

            // Створимо тестовий файл з числами
            string numbers = "5 12 25 8 10 15 3 22 18 30";
            File.WriteAllText(fileName, numbers);

            // Створюємо три черги для груп чисел
            Queue<int> inInterval = new Queue<int>();
            Queue<int> lessThanA = new Queue<int>();
            Queue<int> greaterThanB = new Queue<int>();

            // Зчитуємо файл і обробляємо числа за один перегляд
            string[] tokens = File.ReadAllText(fileName).Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    if (number >= a && number <= b)
                        inInterval.Enqueue(number);
                    else if (number < a)
                        lessThanA.Enqueue(number);
                    else // number > b
                        greaterThanB.Enqueue(number);
                }
            }

            // Друк результатів у потрібному порядку
            Console.WriteLine($"Числа в інтервалі [{a}, {b}]:");
            PrintQueue(inInterval);

            Console.WriteLine($"Числа менші за {a}:");
            PrintQueue(lessThanA);

            Console.WriteLine($"Числа більші за {b}:");
            PrintQueue(greaterThanB);
        }
    }
}