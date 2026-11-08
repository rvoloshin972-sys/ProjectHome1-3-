using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHome3
{
    public class Play : IDisposable
    {
        private static int _totalPlaysCount = 0;
        private int isDisposed = 0;
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
        public void Dispose()
        {
            _Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void _Dispose(bool disposing)
        {
            int previous = Interlocked.Exchange(ref isDisposed, 1);
            Interlocked.Add(ref _totalPlaysCount, previous - 1);
            Console.WriteLine(previous == 0
                ? disposing
                    ? $"[Dispose]: Ресурси п'єси \"{Title}\" очищено."
                    : $"[Деструктор]: П'єсу \"{Title}\" видалено збирачем сміття."
                : $"[Dispose]: П'єсу \"{Title}\" уже очищено.");
        }
        ~Play()
        {
            _Dispose(false);
        }
    }
}
