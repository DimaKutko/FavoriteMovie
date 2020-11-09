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
}

public class ShortMovie : Movie {
    private String imdbID;

    public ShortMovie(String title, String year, String imdbID) : base(title, year)
    {
        this.imdbID = imdbID;
    }
}