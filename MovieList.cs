using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class MovieList : IEnumerable
{
    protected List<Movie> list;

    public MovieList()
    {
        list = new List<Movie>();
    }

    public MovieList(String xml)
    {
        list = XmlClient.ToSearchList(xml);
    }

    public int Size { get { return list.Count; } }
    public Movie this[int index] { get { return list[index]; } }

    public IEnumerator GetEnumerator()
    {
        return list.GetEnumerator();
    }

    public void Add(Movie movie)
    {

        if (!this[movie.ID])
        {
            list.Add(movie);
        }
    }

    public bool this[String id]
    {
        get {
            foreach (Movie movie in list)
            {
                if (movie.ID == id) return true;
            }
            return false;
        }
    }

    public void SortByTitle() => Array.Sort(list.ToArray(), new Movie.SortByTitle());
    public void SortByYear() => Array.Sort(list.ToArray(), new Movie.SortByYear());
    public void SortByRating() => Array.Sort(list.ToArray(), new Movie.SortByRating());

    public void Remove(int index)
    {
        list.RemoveAt(index);
    }

    public void Remove(Movie movie)
    {
        list.Remove(movie);
    }

    public int Selector()
    {
        int select = 0, masTop = 0, masBottom = -1;

        bool run = true;

        if (list.Count >= 10) masBottom = 10; else masBottom = list.Count;

        
        Console.SetCursorPosition(1, 1);
        Menu.PrintArrow();

        while (run)
        {
            
            int cursorTop = Console.CursorTop, cursorLeft = Console.CursorLeft;
            Menu.CleanArea();
            for (int i = masTop, _cursorTop = 1; i < masBottom; i++, _cursorTop++)
            {
                Console.SetCursorPosition(4, _cursorTop);
                Console.Write(list[i]);
            }

            Console.CursorTop = cursorTop; Console.CursorLeft = cursorLeft;
            Menu.PrintArrow();

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (Console.CursorTop != 1)
                    {
                        Menu.PrintSpace();
                        Console.SetCursorPosition(1, Console.CursorTop - 1);
                        Menu.PrintArrow();
                    }
                    else if (masTop != 0)
                    {
                        masTop--;
                        masBottom--;
                        Menu.PrintSpace();
                        Console.SetCursorPosition(1, Console.CursorTop);
                        Menu.PrintArrow();
                    }
                    else
                    {
                        Console.SetCursorPosition(1, Console.CursorTop);
                        Menu.PrintArrow();
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if(Console.CursorTop != list.Count && Console.CursorTop < 10)
                    {
                        Menu.PrintSpace();
                        Console.SetCursorPosition(1, Console.CursorTop + 1);
                        Menu.PrintArrow();
                    }
                    else if(masBottom < list.Count)
                    {
                        masBottom++;
                        masTop++;
                        Menu.PrintSpace();
                        Console.SetCursorPosition(1, Console.CursorTop);
                        Menu.PrintArrow();
                    }
                    else
                    {
                        Console.SetCursorPosition(1, Console.CursorTop);
                        Menu.PrintArrow();
                    }
                    break;
                case ConsoleKey.Enter:
                    select = Console.CursorTop;
                    run = false;
                    break;
                case ConsoleKey.Escape:
                    return - 1;
                default:
                    Console.SetCursorPosition(1, Console.CursorTop);
                    Menu.PrintArrow();
                    break;
            }
        }

        return masTop + select - 1;
    }
}