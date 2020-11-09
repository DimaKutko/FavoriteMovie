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
}