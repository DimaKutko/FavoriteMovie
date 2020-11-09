using System;
using System.Collections.Generic;

public abstract class MovieList
{
    protected List<Movie> list;

    public void Print()
    {
        foreach (Movie m in list)
        {

            Console.WriteLine($"[{m.Year}] | {m.Title}");
        }
    }
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