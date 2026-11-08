namespace ProjectHome1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(" Робота зі списком п'єс ");
            List<Play> catalog = new()
            {
                new(),
                new("Гамлет", "Вільям Шекспір", "Трагедія", 1601),
                new("Ромео і Джульєтта", "Вільям Шекспір", "Трагедія", 1597),
                new("Лісова пісня", "Леся Українка", "Драма-феєрія", 1911)
            };
            Console.WriteLine($"\nВсього створено об'єктів п'єс: {Play.TotalPlaysCount}");
            Console.WriteLine("\n Список усіх п'єс ");
            foreach (Play play in catalog)
            {
                play.DisplayInfo();
            }
            int searchYear = 1911;
            Console.WriteLine($"\n П'єси {searchYear} року випуску ");
            var filteredByYear = catalog.Where(p => p.Year == searchYear);
            foreach (Play play in filteredByYear)
            {
                play.DisplayInfo();
            }
            Console.WriteLine("\n Перевірка роботи деструктора ");
            Console.WriteLine("\nСтворення тимчасової п'єси:");
            CreateForgottenPlay();
            Console.WriteLine("\nЗапуск Garbage Collector...");

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine($"\nВсього створено об'єктів п'єс: {Play.TotalPlaysCount}");
            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
            static void CreateForgottenPlay()
            {
                Play forgotten = new("Кайдашева сім'я","Іван Нечуй-Левицький","Соціально-побутова комедія",1879);
                forgotten.DisplayInfo();
                Console.WriteLine($"\nВсього створено об'єктів п'єс: {Play.TotalPlaysCount}");
            }
        }
    }
}
