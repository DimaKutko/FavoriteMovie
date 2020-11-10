using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class CacheClient
{
    private static readonly String fileName = "movies.dat";

    public static void CacheWrite(MovieList myMovies)
    {
        var formatter = new BinaryFormatter();
        using (var fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        {
            formatter.Serialize(fStream, myMovies);
        }
    }

    public static MovieList CacheRead()
    {
        MovieList myMovies;

        using (FileStream fStream = File.OpenRead(fileName))
        {
            if(fStream.Length != 0)
            {
                var formatter = new BinaryFormatter();
                var temp = (MovieList)formatter.Deserialize(fStream);
                myMovies = temp;
            }
            else
            {
                myMovies = new MovieList();
            }
        }

        return myMovies;
    }

}