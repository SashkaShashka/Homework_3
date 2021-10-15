using System;
using System.Text;
using System.Collections.Generic;


namespace Task_3
{
    class Program
    {
        static string CheckBracketSequence(string str)
        {
            Stack<KeyValuePair<char, int>> brackets = new Stack<KeyValuePair<char, int>>();
            int position = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '<' || str[i] == '>' || str[i] == '(' || str[i] == ')' || str[i] == '[' || str[i] == ']' || str[i] == '{' || str[i] == '}')
                {
                    position = i;
                    if (str[i] == '<' || str[i] == '(' || str[i] == '{' || str[i] == '[')
                    {
                        brackets.Push(new KeyValuePair<char, int>(str[i], i));
                        continue;
                    }
                    else
                    if (brackets.Count != 0)
                    {
                        switch (str[i])
                        {
                            case '>':
                                if (brackets.Peek().Key == '<')
                                    brackets.Pop();
                                else
                                    return PrintAndReturnError(str, brackets.Peek());
                                break;
                            case ']':
                                if (brackets.Peek().Key == '[')
                                    brackets.Pop();
                                else
                                    return PrintAndReturnError(str, brackets.Peek());
                                break;
                            case '}':
                                if (brackets.Peek().Key == '{')
                                    brackets.Pop();
                                else
                                    return PrintAndReturnError(str, brackets.Peek());
                                break;
                            case ')':
                                if (brackets.Peek().Key == '(')
                                    brackets.Pop();
                                else
                                    return PrintAndReturnError(str, brackets.Peek());
                                break;
                            default:
                                break;
                        }
                    }
                    else
                        return PrintAndReturnError(str, position);
                }

            }
            if (brackets.Count == 0)
                return "Последовательность правильная";
            else
                return PrintAndReturnError(str, position);

        }
        static string PrintAndReturnError(string str, KeyValuePair<char, int> element)
        {
            PrintString(str, element.Value);
            return String.Format("Для {0} не хватает закрывающей скобки", element.Key);
        }
        static string PrintAndReturnError(string str, int pos)
        {
            PrintString(str, pos);
            if (str[pos] == '<' || str[pos] == '(' || str[pos] == '{' || str[pos] == '[')
                return String.Format("Для {0} не хватает закрывающей скобки", str[pos]);
            else
                return String.Format("Для {0} не хватает открывающей скобки", str[pos]);
        }

        static void PrintString(string s, int pos)
        {

            Console.Write(s.Substring(0, pos));
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(s[pos]);
            Console.ResetColor();
            Console.Write(s.Substring(pos + 1, s.Length - pos - 1));
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.Write("Введите выражение: ");
            string s = Console.ReadLine();
            Console.WriteLine(CheckBracketSequence(s));
        }
    }
}
