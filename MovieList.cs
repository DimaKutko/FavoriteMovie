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

    public Movie this[int index]{get {return list[index];}}

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

    public int Size {get{return list.Count;}}

    //public void Selector()
    //{
    //    bool run = true;
    //    int top = 0, bottom;

    //    if(list.Count >= 10)
    //    {
    //        bottom = 10;
    //    }
    //    else
    //    {
    //        bottom = list.Count;
    //    }

    //    Menu.Message(@"UP[W, Up Arrow] | Down[S, Down Arrow] | Enter[Enter] | Exit[Esc]");
    //    while (run)
    //    {
    //        Menu.CleanArea();

    //        for (int i = top, cursorTop = 1; i < bottom; i++, cursorTop++)
    //        {
    //            Console.SetCursorPosition(4, cursorTop);

    //            FullMovie movie = (FullMovie)list[i];

    //            Console.Write(movie);
    //        }

    //        switch (Console.ReadKey().Key)
    //        {
                
    //            default:
    //                break;
    //        }
    //    }
    //}
}