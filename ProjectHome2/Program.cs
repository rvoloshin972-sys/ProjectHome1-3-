using System;
using System.Collections.Generic;

namespace ProjectHome2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(" Робота зі списком магазинів ");
            List<Shop> catalog = new()
            {
                new(),
                new("АТБ", "м. Київ, вул. Центральна, 10",ShopType.Grocery),
                new("Епіцентр", "м. Київ, вул. Полярна, 20",ShopType.Household),
                new("Zara", "м. Київ, вул. Хрещатик, 15",ShopType.Clothing),
                new("Intertop", "м. Київ, вул. Велика Васильківська, 5", ShopType.Shoes)
            };
            Console.WriteLine($"\nВсього створено магазинів: {Shop.TotalShopsCount}\n");
            Console.WriteLine(" Список усіх магазинів ");
            foreach (Shop shop in catalog)
            {
                shop.DisplayInfo();
            }
            Console.WriteLine("\n Перевірка Dispose ");
            Console.WriteLine("\nСтворення магазину (Dispose викличеться автоматично):");
            using (Shop disposableShop = new("Сільпо","м. Київ, вул. Шевченка, 12",ShopType.Grocery))
            {
                disposableShop.DisplayInfo();
                Console.WriteLine($"\nВсього створено магазинів: {Shop.TotalShopsCount}");
            }
            Console.WriteLine($"\nВсього магазинів після Dispose: {Shop.TotalShopsCount}");
            Console.WriteLine("\n Ручний виклик Dispose ");
            Shop manualShop = new("Comfy","м. Київ, вул. Незалежності, 25",ShopType.Household);

            manualShop.DisplayInfo();
            manualShop.Dispose();

            Console.WriteLine($"\nВсього магазинів: {Shop.TotalShopsCount}");
            Console.WriteLine("\n Перевірка деструктора ");

            CreateForgottenShop();
            Console.WriteLine("\nЗапуск Garbage Collector...");

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine($"\nВсього магазинів: {Shop.TotalShopsCount}");

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
            static void CreateForgottenShop()
            {
                Shop forgotten = new("Rozetka","м. Київ, вул. Хрещатик, 1",ShopType.Clothing);
                forgotten.DisplayInfo();
                Console.WriteLine($"\nВсього створено магазинів: {Shop.TotalShopsCount}");
            }
        }
    }
}
