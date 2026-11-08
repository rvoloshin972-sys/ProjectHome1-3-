using System;
using System.Collections.Generic;

namespace ProjectHome3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(" ЗАВДАННЯ 1. П'ЄСИ ");
            List<Play> plays = new()
            {
                new(),
                new("Гамлет", "Вільям Шекспір", "Трагедія", 1601),
                new("Ромео і Джульєтта", "Вільям Шекспір", "Трагедія", 1597),
                new("Лісова пісня", "Леся Українка", "Драма-феєрія", 1911)
            };
            Console.WriteLine($"\nВсього створено п'єс: {Play.TotalPlaysCount}");
            foreach (Play play in plays)
                play.DisplayInfo();
            Console.WriteLine("\n Dispose для п'єси ");

            using (Play disposablePlay = new("Кайдашева сім'я","Іван Нечуй-Левицький","Комедія",1879))
            {
                disposablePlay.DisplayInfo();
            }
            Console.WriteLine("\n Деструктор п'єси ");
            CreateForgottenPlay();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine($"\nВсього п'єс: {Play.TotalPlaysCount}");
            Console.WriteLine("\n\n ЗАВДАННЯ 2. МАГАЗИНИ ");

            List<Shop> shops = new()
            {
                new(),
                new("АТБ", "м. Київ, вул. Центральна, 10",ShopType.Продовольчий),
                new("Епіцентр", "м. Київ, вул. Полярна, 20",ShopType.Господарський),
                new("Zara", "м. Київ, вул. Хрещатик, 15",ShopType.Одяг),
                new("Intertop", "м. Київ, вул. Васильківська, 5",ShopType.Взуття)
            };
            Console.WriteLine($"\nВсього створено магазинів: {Shop.TotalShopsCount}");
            foreach (Shop shop in shops)
                shop.DisplayInfo();
            Console.WriteLine("\n Dispose для магазину ");

            using (Shop disposableShop = new("Сільпо","м. Київ, вул. Шевченка, 12",ShopType.Продовольчий))
            {
                disposableShop.DisplayInfo();
            }
            Console.WriteLine("\n Ручний Dispose ");
            Shop manualShop = new("Comfy","м. Київ, вул. Незалежності, 25",ShopType.Господарський);

            manualShop.DisplayInfo();
            manualShop.Dispose();

            Console.WriteLine("\n Деструктор магазину ");
            CreateForgottenShop();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine($"\nВсього магазинів: {Shop.TotalShopsCount}");

            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey();
        }
        static void CreateForgottenPlay()
        {
            Play forgotten = new("Тіні забутих предків","Михайло Коцюбинський","Драма",1911);
            forgotten.DisplayInfo();
        }
        static void CreateForgottenShop()
        {
            Shop forgotten = new("Rozetka","м. Київ, вул. Хрещатик, 1",ShopType.Господарський);
            forgotten.DisplayInfo();
        }
    }
}
