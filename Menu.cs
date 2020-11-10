using System;
using System.Collections.Generic;

public static class Menu {

    private static readonly String item1 = "Add movie";
    private static readonly String item2 = "Edit movie";
    private static readonly String item3 = "Delete movie";
    private static readonly String item4 = "Print my movie";

    private static readonly String error = "ERROR";


    private static readonly List<String> masMenu = new List<string>(){ item1, item2, item3, item4 };

    public static int Size { get => masMenu.Count; }

    public static void PrintMenu()
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

    public static FullMovie Item0()
    {
        Console.Clear();
        Console.SetCursorPosition(1,1);

        Console.Write("Enter the title of the movie to search: ");

        String title = Console.ReadLine();

        String data = RestApiClient.SerchAllMovie(title);

        if(data != error)
        {
            SearchList movies = new SearchList(data);

            Console.SetCursorPosition(4, 1);

            movies.Print();

            int select = Selector(movies.Size);

            if (select == -1) return null;

            ShortMovie movie = (ShortMovie)movies[select];

            data = RestApiClient.GetMovie(movie.ID);

            if (data != error)
            {
                return XmlClient.XmlToFullMovie(data);
            }
        }

        return null;
    }

    private static void PrintItem(String item)
    {
        Console.SetCursorPosition(4, Console.CursorTop + 1);
        Console.Write(item);
    }

    public static int Selector(int size)
    {
        Console.SetCursorPosition(1, 1);

        PrintArrow();

        bool run = true;
        while (run)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (Console.CursorTop != 1)
                    {
                        PrintSpace();
                        Console.SetCursorPosition(1, Console.CursorTop - 1);
                        PrintArrow();
                    }
                    else
                    {
                        Console.SetCursorPosition(1, Console.CursorTop);
                        PrintArrow();
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (Console.CursorTop != size)
                    {
                        PrintSpace();
                        Console.SetCursorPosition(1, Console.CursorTop + 1);
                        PrintArrow();
                    }
                    else
                    {
                        Console.SetCursorPosition(1, Console.CursorTop);
                        PrintArrow();
                    }
                    break;
                case ConsoleKey.Enter:
                    run = false;
                    break;
                case ConsoleKey.Escape:
                    return -1;
                default:
                    Console.SetCursorPosition(1, Console.CursorTop);
                    PrintArrow();
                    break;
            }
        }
        return Console.CursorTop - 1;
    }

    private static void PrintArrow()
    {
        Console.Write("-->");
        Console.SetCursorPosition(1, Console.CursorTop);
    }

    private static void PrintSpace()
    {
        Console.SetCursorPosition(1, Console.CursorTop);
        Console.Write("   ");
    }
}