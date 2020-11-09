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

    public String Title
    {
        get { return title;}
    }

    public int Year
    {
        get { return year;}
    }
}

public class FullMovie : Movie{
    private bool viewed;
    private int rating;
    private String comment;

    private String writer;
    private String genre;
    private String actors;
    private String plot;

    public FullMovie(String title, String year) : base(title, year) {

    }

    public bool Viewed{get{return viewed;}set {viewed = value;}}

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

    public String Writer {get{return writer;}}
    public String Genre {get{return genre;}}
    public String Actors {get{return actors;}}
    public String Plot {get{return plot;}}
}

public class ShortMovie : Movie {
    private String imdbID;

    public ShortMovie(String title, String year, String imdbID) : base(title, year)
    {
        this.imdbID = imdbID;
    }

    public String ID {get{return imdbID;}}
}