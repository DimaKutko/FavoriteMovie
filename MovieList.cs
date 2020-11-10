using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public abstract class MovieList
{
    protected List<Movie> list;

    public MovieList()
    {
        list = new List<Movie>();
    }

    public void Print()
    {
        Console.CursorVisible = false;
        foreach (Movie m in list)
        {
            Console.SetCursorPosition(4, Console.CursorTop);
            Console.WriteLine($"[{m.Year}] | {m.Title}");
        }
    }

    public void Add(Movie movie)
    {
        list.Add(movie);
    }

    public Movie this[int index]{get {return list[index];}}

    public int Size {get{return list.Count;}}
}

[Serializable]
public class FavoriteList : MovieList
{

    public FavoriteList()
    {
        list = new List<Movie>();
    }

}

public class SearchList : MovieList
{
    public SearchList(String xml)
    {
        list = XmlClient.ToSearchList(xml);
    }
}