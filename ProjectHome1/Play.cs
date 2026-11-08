using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHome1
{
    public class Play
    {
        private static int _totalPlaysCount = 0;
        public string Title { get; set; } = "Нова п'єса";
        public string Author { get; set; } = "Невідомий автор";
        public string Genre { get; set; } = "Драма";
        public int Year { get; set; } = 2026;
        public Play()
        {
            _totalPlaysCount++;
            Console.WriteLine("[Конструктор]: Створено нову п'єсу.");
        }
        public Play(string title, string author, string genre, int year)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;

            _totalPlaysCount++;
            Console.WriteLine($"[Конструктор]: Створено п'єсу \"{Title}\".");
        }
        public static int TotalPlaysCount
        {
            get { return _totalPlaysCount; }
        }
        public void DisplayInfo()
        {
            Console.WriteLine("");
            Console.WriteLine($"Назва п'єси: {Title}");
            Console.WriteLine($"Автор: {Author}");
            Console.WriteLine($"Жанр: {Genre}");
            Console.WriteLine($"Рік випуску: {Year}");
            Console.WriteLine("");
        }
        ~Play()
        {
            _totalPlaysCount--;
            Console.WriteLine($"[Деструктор]: П'єсу \"{Title}\" видалено збирачем сміття.");
        }
    }
}
