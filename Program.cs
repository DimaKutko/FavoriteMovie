using System;

namespace FavoriteMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            FavoriteList myMovie = CacheClient.CacheRead();

            Menu.DrawFrame();

            Menu.Message("Test message");

            Menu.CleanMessage();

            bool run  = true;

            Menu.PrintMenu();

            while (run)
            {
                switch (Menu.Selector(Menu.Size))
                {
                    case 0:
                        {
                            var movie = Menu.Item0();

                            if(movie != null) myMovie.Add(movie);
                        }
            break;


            default:
                        run = false;
            break;
        }

    }


    CacheClient.CacheWrite(myMovie);

        }
    }
}
