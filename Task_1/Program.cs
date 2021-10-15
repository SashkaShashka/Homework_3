using System;
using System.Text;
using System.Collections.Generic;

namespace Task_1
{
    class Program
    {
        static Dictionary<string, string> dictionaryCountries = new Dictionary<string, string>();
        static void FillDictionary()
        {
            dictionaryCountries.Add("Германия", "Берлин");
            dictionaryCountries.Add("Россия", "Москва");
            dictionaryCountries.Add("Франция", "Париж");
            dictionaryCountries.Add("Соединенные Штаты Америки", "Вашингтон");
            dictionaryCountries.Add("Канада", "Оттава");
            dictionaryCountries.Add("Испания", "Норвегия");
            dictionaryCountries.Add("Чехия", "Прага");
            dictionaryCountries.Add("Исландия", "Рейкьявик");
            dictionaryCountries.Add("Люксембург", "Люксембург");
            dictionaryCountries.Add("Италия", "Рим");
            dictionaryCountries.Add("Швеция", "Стокгольм");
            dictionaryCountries.Add("Дания", "Копенгаген");
            dictionaryCountries.Add("Украина", "Киев");
            dictionaryCountries.Add("Австрия", "Вена");
            dictionaryCountries.Add("Польша", "Варшава");
            dictionaryCountries.Add("Бельгия", "Брюссель");
            dictionaryCountries.Add("Нидерланды", "Амстердам");
            dictionaryCountries.Add("Хорватия", "Загреб");
            dictionaryCountries.Add("Греция", "Афины");
            dictionaryCountries.Add("Португалия", "Лиссабон");
            dictionaryCountries.Add("Норвегия", "Осло");

        }

        static void WriteDictionary()
        {
            foreach (var dictionaryCountry in dictionaryCountries)
            {
                Console.WriteLine("Cтрана: {0,-15} Cтолица: {1} ", dictionaryCountry.Key, dictionaryCountry.Value);
            }
        }

        static void WriteCountDictionary()
        {
            int countFilledCountries = 0;
            foreach (string capital in dictionaryCountries.Values)
            {
                if (capital != "")
                    countFilledCountries++;
            }
            Console.WriteLine("Всего стран {0} из них столицы заполнены у {1}", dictionaryCountries.Count, countFilledCountries);
        }

        static bool FindCountry(string countryIn, bool printResult)
        {
            string country = FormatString(countryIn);
            foreach (string _country in dictionaryCountries.Keys)
            {
                if (_country == country)
                {
                    if (printResult)
                        Console.WriteLine("Страна {0} столица {1}", _country, dictionaryCountries[country]);
                    return true;
                }
            }
            if (printResult)
                Console.WriteLine("Страна не найдена");
            return false;
        }
        static bool FindCapital(string capitalIn)
        {
            string capital = FormatString(capitalIn);
            foreach (KeyValuePair<string, string> country in dictionaryCountries)
            {
                if (country.Value == capital)
                {
                    Console.WriteLine("Страна {0} столица {1}", country.Key, country.Value);
                    return true;
                }
            }
            Console.WriteLine("Столица не найдена");
            return false;
        }
        static string FormatString(string str)
        {
            if (str.Length == 0)
                return str;
            else
            {
                if (string.Equals("США", str, StringComparison.OrdinalIgnoreCase) || string.Equals("Соединенные Штаны Америки", str, StringComparison.OrdinalIgnoreCase))
                    return "Соединенные Штаты Америки";
                string[] words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (words.Length == 1)
                {
                    StringBuilder strWork = new StringBuilder(str.ToLower());
                    strWork[0] = str.ToUpper()[0];
                    return strWork.ToString();
                }
                else
                {
                    StringBuilder strWork = new StringBuilder("");
                    foreach (string word in words)
                    {
                        if (word.Length != 0)
                        {
                            StringBuilder helpStr = new StringBuilder(word.ToLower());
                            helpStr[0] = word.ToUpper()[0];
                            strWork.Append(helpStr + " ");
                        }
                    }
                    strWork.Remove(strWork.Length - 1, 1);
                    return strWork.ToString();
                }

            }
        }
        static void AddCountry(string _country, string _capital)
        {
            string country = FormatString(_country);
            string capital = FormatString(_capital);
            if (FindCountry(country, false) && dictionaryCountries[country] != "")
            {
                Console.WriteLine("Столица у данной страны уже записана. Хотите перезаписать? Y/N");
                while (true)
                {
                    ConsoleKeyInfo yn = Console.ReadKey(true);
                    if (yn.Key == ConsoleKey.Y)
                    {
                        dictionaryCountries[country] = capital;
                        Console.WriteLine("Столица у страны {0} исправлена на ", country, capital);
                        return;
                    }
                    if (yn.Key == ConsoleKey.N)
                        return;
                }
            }
            else
            {
                dictionaryCountries.Add(country, capital);
                Console.WriteLine("Страна {0} добавлена", country);
            }
        }
        static void RemoveCountry(string _country)
        {
            string country = FormatString(_country);
            if (FindCountry(country, false))
            {
                dictionaryCountries.Remove(country);
                Console.WriteLine("Страна была '{0}' была удалена из списка", country);
            }
            else
                Console.WriteLine("Страна '{0}' не найдена", country);
        }
        static void Wait()
        {
            Console.WriteLine("Чтобы продолжить нажмите Enter");
            while (Console.ReadKey().Key != ConsoleKey.Enter) ;
        }
        static void Function()
        {
            ShowMenu();
            for (; ; )
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Q:
                        return;
                    case ConsoleKey.W:
                        Console.Clear();
                        ShowMenu();
                        WriteDictionary();
                        break;
                    case ConsoleKey.C:
                        Console.Clear();
                        ShowMenu();
                        WriteCountDictionary();
                        break;
                    case ConsoleKey.F:
                        Console.Clear();
                        ShowMenu();
                        Console.Write("Введите страну для поиска: ");
                        FindCountry(Console.ReadLine(), true);
                        break;
                    case ConsoleKey.G:
                        Console.Clear();
                        ShowMenu();
                        Console.Write("Введите столицу для поиска: ");
                        FindCapital(Console.ReadLine());
                        break;
                    case ConsoleKey.A:
                        Console.Clear();
                        ShowMenu();
                        Console.Write("Введите страну для добавления: ");
                        string country = Console.ReadLine();
                        Console.Write("Введите столицу для добавления: ");
                        string capital = Console.ReadLine();
                        AddCountry(country, capital);
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        ShowMenu();
                        Console.Write("Введите страну для удаления: ");
                        RemoveCountry(Console.ReadLine());
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            FillDictionary();
            Function();
        }

        static void ShowMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");
            Console.CursorLeft = 1;
            PrintMenuCommand("W", "Вывести список стран и столиц");
            PrintMenuCommand("C", "Вывести количество");
            PrintMenuCommand("F", "Поиск по стране");
            PrintMenuCommand("G", "Поиск по столице");
            PrintMenuCommand("A", "Добавить");
            PrintMenuCommand("D", "Удалить");
            PrintMenuCommand("Q", "Выход");
            Console.WriteLine();
            Console.ResetColor();
            Console.CursorLeft = 0;
        }

        static void PrintMenuCommand(string key, string action)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(key);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" " + action + " ");
        }
    }
}
