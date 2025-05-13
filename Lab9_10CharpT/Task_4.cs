using System;
using System.Collections;
using System.IO;
namespace Task_4
{
    public class Task_4
    {
        class NumberGroups
        {
            private ArrayList inRange = new ArrayList();
            private ArrayList lessThan = new ArrayList();
            private ArrayList greaterThan = new ArrayList();

            public void Add(int num, int a, int b)
            {
                if (num >= a && num <= b) inRange.Add(num);
                else if (num < a) lessThan.Add(num);
                else greaterThan.Add(num);
            }

            public void PrintGroup(string type)
            {
                IEnumerable group = type switch
                {
                    "in" => inRange,
                    "low" => lessThan,
                    "high" => greaterThan,
                    _ => throw new ArgumentException("Unknown group type")
                };

                foreach (int num in group)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
        public void main4()
        {
            string fileName = "C:/Users/Smart/OneDrive/Робочий стіл/C#/csharplab9-Antonio8315/Lab9_10CharpT/FilesTask3/numbers.txt";
            int a = 10, b = 20;
            File.WriteAllText(fileName, "5 12 25 8 10 15 3 22 18 30");

            string[] tokens = File.ReadAllText(fileName).Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            NumberGroups groups = new NumberGroups();

            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    groups.Add(number, a, b);
                }
            }

            Console.WriteLine($"Числа в інтервалі [{a}, {b}]:");
            groups.PrintGroup("in");

            Console.WriteLine($"Числа менші за {a}:");
            groups.PrintGroup("low");

            Console.WriteLine($"Числа більші за {b}:");
            groups.PrintGroup("high");
        }
    }
}