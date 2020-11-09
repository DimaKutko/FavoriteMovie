using System;
using System.Collections.Generic;

public abstract class MovieList
{
    protected List<Movie> list;

    public void Print()
    {
        Console.CursorVisible = false;
        foreach (Movie m in list)
        {
            Console.SetCursorPosition(4, Console.CursorTop);
            Console.WriteLine($"[{m.Year}] | {m.Title}");
        }
    }

    public int Size {get{return list.Count;}}
}

public class FavoriteList : MovieList 
{
    public FavoriteList(String xml){

    }
}

public class SearchList : MovieList
{
    public SearchList(String xml)
    {
        XmlClient xmlClient = new XmlClient();

        list = xmlClient.ToSearchList(xml);
    }


}