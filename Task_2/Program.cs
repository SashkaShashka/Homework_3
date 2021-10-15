using System;
using System.Text;
using System.Collections.Generic;

namespace Task_2
{
    class Program
    {
        static List<HashSet<string>> usersLoves = new List<HashSet<string>>();
        static Dictionary<string, int> loves = new Dictionary<string, int>();

        static string[] FormatString(string strUser)
        {
            string[] separator = new string[] { " , ", ", ", " ,", "," };
            HashSet<string> words = new HashSet<string>(strUser.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            StringBuilder newString = new StringBuilder();
            foreach (string word in words)
            {
                newString.Append(word + " ");
            }
            newString.Remove(newString.Length - 1, 1);
            return newString.ToString().Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        static void AddUserLoves(string strUser)
        {
            if (strUser.Length == 0)
                return;
            HashSet<string> userLoves = new HashSet<string>(FormatString(strUser));
            usersLoves.Add(userLoves);
            foreach (string love in userLoves)
            {
                if (loves.ContainsKey(love))
                    loves[love]++;
                else
                    loves.Add(love, 1);
            }
        }
        static HashSet<string> AllLoves()
        {
            HashSet<string> allLoves = new HashSet<string>();
            foreach (HashSet<string> userLoves in usersLoves)
            {
                allLoves.UnionWith(userLoves);
            }
            return allLoves;
        }
        static void PrintAllLoves()
        {
            HashSet<string> allLoves = AllLoves();
            Console.Write("Эти любимки нравятся хотя бы одному пользователю: ");
            foreach (string loves in allLoves)
            {
                Console.Write(loves + " ");
            }
            Console.WriteLine();
        }
        static void PrintAnyLoves()
        {
            HashSet<string> allLoves = AllLoves();
            foreach (HashSet<string> userLoves in usersLoves)
            {
                allLoves.IntersectWith(userLoves);
            }
            if (allLoves.Count == 0)
                Console.Write("Любимок, которые нравятся всем - нет :(");
            else
            {
                Console.Write("Любимки, котоыре нравятся всем: ");
                foreach (string loves in allLoves)
                {
                    Console.Write(loves + " ");
                }
            }
            Console.WriteLine();

        }
        static void PrintOneUserLoves()
        {
            int i = 0, j = 0;
            foreach (HashSet<string> userLoves in usersLoves)
            {
                Console.Write("Любимки, которые нравятся только пользователю №{0}: ", i + 1);
                HashSet<string> printUser = new HashSet<string>(userLoves);
                foreach (HashSet<string> userLove in usersLoves)
                {
                    if (i != j)
                        printUser.ExceptWith(userLove);
                    j++;
                }
                if (printUser.Count == 0)
                    Console.WriteLine("таких любимок нет");
                else
                    foreach (string loves in printUser)
                    {
                        Console.Write(loves + " ");
                    }
                Console.WriteLine();
                i++;
                j = 0;
            }
        }
        static void PrintLoves()
        {
            foreach (KeyValuePair<string, int> love in loves)
            {
                Console.WriteLine("Любимка '{0}' нравится {1} пользователю/ям", love.Key, love.Value);
            }
        }

        static void Function()
        {
            Fill();
            Console.Clear();
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
                        Console.Write("Ввведите любимки нового пользователя: ");
                        AddUserLoves(Console.ReadLine());
                        break;
                    case ConsoleKey.S:
                        Console.Clear();
                        ShowMenu();
                        PrintAnyLoves();
                        break;
                    case ConsoleKey.O:
                        Console.Clear();
                        ShowMenu();
                        PrintOneUserLoves();
                        break;
                    case ConsoleKey.A:
                        Console.Clear();
                        ShowMenu();
                        PrintLoves();
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        ShowMenu();
                        PrintAllLoves();

                        break;
                }
            }
        }
        static void Fill()
        {
            for (int i = 0; ; i++)
            {
                Console.Write("Введите любимки {0} пользователя: ", i + 1);
                string userStr = Console.ReadLine();
                if (userStr.Length == 0)
                    break;
                else
                    AddUserLoves(userStr);
            }
        }
        static void Main(string[] args)
        {

            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowPosition(0, 0);
            Function();
        }
        static void ShowMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");
            Console.CursorLeft = 1;
            PrintMenuCommand("W", "Добавить пользователя");
            PrintMenuCommand("S", "Что нравится всем");
            PrintMenuCommand("D", "Что нравится хотя бы одному");
            PrintMenuCommand("O", "Нравится только одному пользователю");
            PrintMenuCommand("A", "Все любимки");
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
