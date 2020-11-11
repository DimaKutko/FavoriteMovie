using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Movie 
{
    protected String title;
    protected int year;
    private bool viewed;
    private int rating;
    private String comment;
    private String imdbID;
    private String writer;
    private String genre;
    private String actors;
    private String plot;
    private String rated;
    private String released;
    private String runtime;
    private String director;
    private String language;
    private String country;
    private String awards;
    private String imdbRating;
    
    public Movie(FullMoviePayload payload){
        title = payload.title;
        year = Convert.ToInt32(payload.year);
        imdbID = payload.imdbID;
        writer = payload.writer;
        genre = payload.genre;
        actors = payload.actors;
        plot = payload.plot;
        rated = payload.rated;
        released = payload.released;
        runtime = payload.runtime;
        director = payload.director;
        language = payload.language;
        country = payload.country;
        awards = payload.awards;
        country = payload.imdbRating;
    }

    public Movie(String title, String year, String imdbID)
    {
        this.title = title;
        this.year = Convert.ToInt32(year);
        this.imdbID = imdbID;
    }

    public String Title { get { return title; } }
    public int Year { get { return year; } }
    public String Writer { get => writer; }
    public String Genre { get => genre; }
    public String Actors { get => actors; }
    public String Plot { get => plot; }
    public String Rated { get => rated; }
    public String Released { get => released; }
    public String Runtime { get => runtime; }
    public String Director { get => director; }
    public String Language { get => language; }
    public String Country { get => country; }
    public String Awards { get => awards; }
    public String ImdbRating { get => imdbRating; }
    public bool Viewed { get => viewed; set => viewed = value; }
    public string ID { get => imdbID; set => imdbID = value; }

    public int Rating
    {
        get{ return rating; }
        set
        {
            if (value >= 10)
            {
                rating = 10;
            }
            else if(value <= 0)
            {
                rating = 0;
            }
            else
            {
                rating = value;
            }
        }
    }

    public String Comment
    {
        get
        {
            if(comment != null)
            {
                return comment;
            }
            else
            {
                return "No comment";
            }
        }
        set
        {
            comment = value;
        }
    }

    private String YesNo
    {
        get {
            if (viewed)
            {
               return "Yes";
            }
            return "No";
        }
    }

    public class SortByTitle : IComparer
    {
        public int Compare(object x, object y)
        {
            Movie obj1 = x as Movie;
            Movie obj2 = y as Movie;

            if (Convert.ToInt32(obj1.title[0]) > Convert.ToInt32(obj2.title[0])) return 1;
            if (Convert.ToInt32(obj1.title[0]) < Convert.ToInt32(obj2.title[0])) return -1;
            return 0;
        }
    }

    public class SortByYear : IComparer
    {
        public int Compare(object x, object y)
        {
            Movie obj1 = x as Movie;
            Movie obj2 = y as Movie;

            if (obj1.year > obj2.year) return 1;
            if (obj1.year < obj2.year) return -1;
            return 0;
        }
    }

    public class SortByRating : IComparer
    {
        public int Compare(object x, object y)
        {
            Movie obj1 = x as Movie;
            Movie obj2 = y as Movie;

            if (obj1.rating > obj2.rating) return 1;
            if (obj1.rating < obj2.rating) return -1;
            return 0;
        }
    }

    public void Print()
    {
        Menu.CleanArea();

        Console.SetCursorPosition(1, 1);

        Console.Write(CheckLength("[" + year + "]" + " | " + title + " by " + director));

        Console.SetCursorPosition(1, 2);

        Console.Write(CheckLength(rated + "  | " + country + " " + released));

        Console.SetCursorPosition(1,3);

        Console.Write(CheckLength("Genre: " + genre));

        Console.SetCursorPosition(1, 4);

        Console.Write(CheckLength("Actors: " + actors));

        Console.SetCursorPosition(1, 9);

        Console.Write(CheckLength("My rating: " + rating + " | Viewed: " + YesNo));

        Console.SetCursorPosition(1, 10);

        Console.Write(CheckLength("My comment: " + comment));
    }



    private String CheckLength(String str)
    {
        if (str.Length > Menu.WidthArea)
        {
            int cut = str.Length - Menu.WidthArea;
            str = str.Substring(0, str.Length - cut);
            str += "...";
        }

        return str;
    }

    public override String ToString()
    {
        String str;

        if (director != null) {
            str = "[" + year + "]" + " | " + title + " by " + director;
        } else {
            str = "[" + year + "]" + " | " + title;
        }

        if (str.Length > Menu.WidthArea)
        {
            int cut = str.Length - Menu.WidthArea + 3;
            str = str.Substring(0, str.Length - cut);
            str += "...";
        }

        return str;
    }
}