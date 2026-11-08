using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHome3
{
    public class Shop : IDisposable
    {
        private static int _totalShopsCount = 0;
        private int isDisposed = 0;
        public string Name { get; set; } = "Новий магазин";
        public string Address { get; set; } = "Невідома адреса";
        public ShopType Type { get; set; } = ShopType.Продовольчий;
        public Shop()
        {
            Interlocked.Increment(ref _totalShopsCount);
            Console.WriteLine("[Конструктор]: Створено новий магазин.");
        }
        public Shop(string name, string address, ShopType type)
        {
            Name = name;
            Address = address;
            Type = type;

            Interlocked.Increment(ref _totalShopsCount);
            Console.WriteLine($"[Конструктор]: Створено магазин \"{Name}\".");
        }
        public static int TotalShopsCount
        {
            get { return _totalShopsCount; }
        }
        public void DisplayInfo()
        {
            Console.WriteLine("");
            Console.WriteLine($"Назва магазину: {Name}");
            Console.WriteLine($"Адреса: {Address}");
            Console.WriteLine($"Тип магазину: {Type}");
            Console.WriteLine("");
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            int previous = Interlocked.Exchange(ref isDisposed, 1);
            Interlocked.Add(ref _totalShopsCount, previous - 1);
            Console.WriteLine(previous == 0
                ? disposing
                    ? $"[Dispose]: Ресурси магазину \"{Name}\" очищено."
                    : $"[Деструктор]: Магазин \"{Name}\" видалено збирачем сміття."
                : $"[Dispose]: Магазин \"{Name}\" уже очищено.");
        }
        ~Shop()
        {
            Dispose(false);
        }
    }
}
