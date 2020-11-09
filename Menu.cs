using System;
using System.Collections.Generic;

public class Menu {

    private static readonly String item1 = "Search movie";
    private static readonly String item2 = "Edit movie";
    private static readonly String item3 = "Delete movie";
    private static readonly String item4 = "Print my movie";

    private static readonly List<String> masMenu = new List<string>(){ item1, item2, item3, item4 };

    public void PrintMenu()
    {
        Console.CursorVisible = false;
        Console.Clear();
        for (int i = 0; i < 35; i++)
        {
            Console.Write(Convert.ToChar(0x2550));
        }
        Console.SetCursorPosition(0,1);
        foreach (String item in masMenu)
        {
            PrintItem(item);
        }
    }

    private void PrintItem(String item)
    {
        Console.SetCursorPosition( 3, Console.CursorTop + 1);
        Console.Write(item);
    }

    public int Selector(int size)
    {
        Console.SetCursorPosition(0, 0);

        PrintArrow();

        size--;

        bool run = true;
        while (run)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (Console.CursorTop != 0)
                    {
                        PrintSpace();
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        PrintArrow();
                    }
                    else
                    {
                        Console.SetCursorPosition(0, Console.CursorTop);
                        PrintArrow();
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (Console.CursorTop != size)
                    {
                        PrintSpace();
                        Console.SetCursorPosition(0, Console.CursorTop + 1);
                        PrintArrow();
                    }
                    else
                    {
                        Console.SetCursorPosition(0, Console.CursorTop);
                        PrintArrow();
                    }
                    break;
                case ConsoleKey.Enter:
                    run = false;
                    break;
                default:
                    Console.SetCursorPosition(0, Console.CursorTop);
                    PrintArrow();
                    break;
            }
        }
        return Console.CursorTop;
    }

    private void PrintArrow()
    {
        Console.Write("-->");
        Console.SetCursorPosition(0, Console.CursorTop);
    }

    private void PrintSpace()
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write("   ");
    }
}