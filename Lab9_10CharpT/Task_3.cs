using System;
using System.Collections;
using System.IO;
using System.Text;
namespace Task_3
{
    public class Task_3
    {
        class VowelList : ArrayList, ICloneable
        {
            public IEnumerable GetReversed()
            {
                ArrayList clone = (ArrayList)this.Clone();
                clone.Reverse();
                foreach (var item in clone)
                {
                    yield return item;
                }
            }

            public new object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        public void main3()
        {
            string fileName = "C:/Users/Smart/OneDrive/Робочий стіл/C#/csharplab9-Antonio8315/Lab9_10CharpT/FilesTask3/text.txt";
            string text = "asdqwerty";
            File.WriteAllText(fileName, text, Encoding.UTF8);

            string content = File.ReadAllText(fileName, Encoding.UTF8);
            char[] vowels = { 'a', 'e', 'o', 'i', 'y', 'u',
                          'A', 'E', 'O', 'I', 'Y', 'U' };

            VowelList vowelList = new VowelList();
            foreach (char c in content)
            {
                if (Array.Exists(vowels, v => v == c))
                    vowelList.Add(c);
            }

            Console.WriteLine("Голосні у зворотному порядку:");
            foreach (char c in vowelList.GetReversed())
            {
                Console.Write(c);
            }

            Console.WriteLine();
        }
    }
}