using System;

namespace FavoriteMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieList myMovie = CacheClient.CacheRead();

            Menu.DrawFrame();

            Menu.Message("Test message");

            Menu.CleanMessage();

            bool run  = true;

            while (run)
            {
                Menu.PrintMenu();

                switch (Menu.Selector(Menu.Size))
                {
                    case 0:
                        {
                            var movie = Menu.Item1();

                            if(movie != null) myMovie.Add(movie);
                        }
                        break;
                    case 1:
                        {
                            Menu.Item2(myMovie);
                        }
                        break;
                    case -1:
                        run = false;
                        break;
                    default:
                        break;
                }

            }


            CacheClient.CacheWrite(myMovie);

        }
    }
}
