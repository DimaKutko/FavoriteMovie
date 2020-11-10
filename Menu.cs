using System;
using System.Collections.Generic;

public static class Menu {

    private static readonly String item1 = "Add movie";
    private static readonly String item2 = "Edit movie";
    private static readonly String item3 = "Delete movie";
    private static readonly String item4 = "Print my movie";

    private static readonly String error = "ERROR";

    private static readonly int width = 70, height = 13;


    private static readonly List<String> masMenu = new List<string>(){ item1, item2, item3, item4 };

    public static int Size { get => masMenu.Count; }

    public static void PrintMenu()
    {
        CleanArea();

        Console.SetCursorPosition(4,1);
        foreach (String item in masMenu)
        {
            Console.WriteLine(item);
            Console.SetCursorPosition(4, Console.CursorTop);
        }
    }

    public static void DrawFrame(){
        Console.CursorVisible = false;

        Console.Clear();

        for (int i = 1; i < width; i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write(Convert.ToChar(0x2550));
            Console.SetCursorPosition(i, 11);
            Console.Write(Convert.ToChar(0x2550));
            Console.SetCursorPosition(i, 13);
            Console.Write(Convert.ToChar(0x2550));
        }

        for (int i = 1; i < height; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write(Convert.ToChar(0x2551));
            Console.SetCursorPosition(width, i);
            Console.Write(Convert.ToChar(0x2551));
        }

        Console.SetCursorPosition(0, 0);
        Console.Write(Convert.ToChar(0x2554));
        Console.SetCursorPosition(width, 0);
        Console.Write(Convert.ToChar(0x2557));
        Console.SetCursorPosition(width, 11);
        Console.Write(Convert.ToChar(0x2563));
        Console.SetCursorPosition(width, 13);
        Console.Write(Convert.ToChar(0x255D));
        Console.SetCursorPosition(0, 13);
        Console.Write(Convert.ToChar(0x255A));
        Console.SetCursorPosition(0, 11);
        Console.Write(Convert.ToChar(0x2560));
    }

    public static void CleanMessage(){
        for (int i = 1; i < width; i++)
        {
            Console.SetCursorPosition(i, height-1);
            Console.Write(" ");
        }
    }

    public static void Message(String message)
    {
        CleanMessage();
        Console.SetCursorPosition(2, height - 1);
        Console.Write(message);
    }

    public static void CleanArea()
    {
        for (int x = 1; x < width - 1; x++)
        {
            for (int y = 1; y < height - 3; y++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" ");
            }
        }
    }

    public static Movie Item0()
    {
        Console.SetCursorPosition(4,1);

        Console.Write("Enter the title of the movie to search: ");

        String title = Console.ReadLine();

        CleanArea();

        String data = RestApiClient.SerchAllMovie(title);

        if(data != error)
        {
            MovieList movies = new MovieList(data);

            Console.SetCursorPosition(4, 1);

            movies.Print();

            int select = Selector(movies.Size);

            CleanMessage();

            if (select == -1) return null;

            Movie movie = (Movie)movies[select];

            data = RestApiClient.GetMovie(movie.ID);

            if (data != error)
            {
                return XmlClient.XmlToFullMovie(data);
            }
        }

        return null;
    }

    public static void Item3(MovieList list)
    {
        
    }

    public static int Selector(int size)
    {
        Console.CursorVisible = false;

        Message(@"UP[W, Up Arrow] | Down[S, Down Arrow] | Enter[Enter] | Exit[Esc]");

        Console.SetCursorPosition(1, 1);

        int cursor = Console.CursorTop;

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
                    cursor = Console.CursorTop;
                    run = false;
                    break;
                case ConsoleKey.Escape:
                    cursor = 0;
                    run = false;
                    break;
                default:
                    Console.SetCursorPosition(1, Console.CursorTop);
                    PrintArrow();
                    break;
            }
        }
        Console.CursorVisible = true;

        return cursor - 1;
    }

    public static void PrintArrow()
    {
        Console.Write("-->");
        Console.SetCursorPosition(1, Console.CursorTop);
    }

    public static void PrintSpace()
    {
        Console.SetCursorPosition(1, Console.CursorTop);
        Console.Write("   ");
    }
}