using System;
using System.IO;
using System.Linq;
using System.Text;

using System.Security.Cryptography;
namespace Task_1
{
    public class Task_1
    {
        public void main1()
        {
            string fileName = "C:/Users/Smart/OneDrive/Робочий стіл/C#/csharplab9-Antonio8315/Lab9_10CharpT/FilesTask1/text.txt";

            // Створюємо файл і записуємо текст
            string textToWrite = "qwertyuiop";
            File.WriteAllText(fileName, textToWrite, Encoding.UTF8);

            // Зчитуємо текст з файлу
            string content = File.ReadAllText(fileName, Encoding.UTF8);

            char[] vowels = { 'a', 'e', 'o', 'i', 'y',
                          'A', 'E', 'O', 'I', 'Y' };

            // Створюємо стек для зберігання голосних
            Stack<char> vowelStack = new Stack<char>();

            // Додаємо всі голосні в стек
            foreach (char c in content)
            {
                if (Array.Exists(vowels, v => v == c))
                {
                    vowelStack.Push(c);
                }
            }
            // Виводимо голосні у зворотному порядку
            Console.WriteLine("Голосні у зворотному порядку:");
            while (vowelStack.Count > 0)
            {
                Console.Write(vowelStack.Pop());
            }

            Console.WriteLine();
        }
    }
}