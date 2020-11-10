using System;

public abstract class Movie
{
    protected String title;
    protected int year;

    protected Movie(String title, int year)
    {
        this.title = title;
        this.year = year;
    }

    protected Movie(String title, String year)
    {
        try
        {
            this.title = title;
            this.year = Convert.ToInt32(year);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error {e.Message}");
        }
    }

    public String Title { get { return title; } }
    public int Year { get { return year; } }
}

public class FullMovie : Movie{
    private bool viewed;
    private int rating;
    private String comment;

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

    public FullMovie(FullMoviePayload payload) : base(payload.title, payload.year) {
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

    public bool Viewed{get => viewed; set =>viewed = value;}

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

    public string Writer { get => writer;}
    public string Genre { get => genre;}
    public string Actors { get => actors; }
    public string Plot { get => plot;}
    public string Rated { get => rated; }
    public string Released { get => released; }
    public string Runtime { get => runtime;}
    public string Director { get => director;}
    public string Language { get => language;}
    public string Country { get => country;}
    public string Awards { get => awards; }
    public string ImdbRating { get => imdbRating;}

    public override string ToString()
    {
        return "[" + year + "]" + " | " + title + " by " + director;
    }
}

public class ShortMovie : Movie {
    private String imdbID;

    public ShortMovie(String title, String year, String imdbID) : base(title, year)
    {
        this.imdbID = imdbID;
    }

    public String ID {get{return imdbID;}}

    public override string ToString()
    {
        return "[" + year + "]"+ " | " + title  + " id: " + imdbID; 
    }
}