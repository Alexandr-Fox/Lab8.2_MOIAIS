using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Lab8._2_MOIAIS
{
    internal class Program
    {
        private static Dictionary<string, string> words = new();
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до файла: ");
            string path = Console.ReadLine();
            StreamReader reader = new(path);
            string? line;
            while ((line = reader.ReadLine()) != null)
                words.Add(line.Split(' ')[0], line.Split(' ')[1]);
            reader.Close();
            Console.WriteLine("Введите ФИО: ");
            string name = Console.ReadLine();
            int count = 0;
            Random random = new Random();
            int c = random.Next(3, words.Count);
            c = c > 15 ? 15 : c;
            List<string> keys = new();
            foreach (var key in words.Keys)
                keys.Add(key);
            for(int i = 0; i < c; i++)
            {
                int ind = random.Next(keys.Count);
                Console.WriteLine($"Введите перевод слова: {words[keys[ind]]}");
                if (Console.ReadLine().ToLower() == keys[ind].ToLower())
                    count++;
                keys.RemoveAt(ind);
            }
            Console.WriteLine(name);
            Console.WriteLine($"Число заданных слов: {c}");
            Console.WriteLine($"Число верно введенных слов: {count}");
            Console.WriteLine("Введите путь до файла с результатами: ");
            path = Console.ReadLine();
            StreamWriter writer = new(path, false);
            writer.WriteLine(name);
            writer.WriteLine($"Число заданных слов: {c}");
            writer.WriteLine($"Число верно введенных слов: {count}");
            writer.Close();

        }
    }
}
