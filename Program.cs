using System;

namespace FavoriteMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            FavoriteList myMovie = CacheClient.CacheRead();

            myMovie.Print();


            bool run  = true;

            //Console.Clear();
            //Console.SetCursorPosition(0, 0);
            //Menu.PrintMenu();

            //while (run)
            //{
            //switch (Menu.Selector(Menu.Size))
            //    {
            //        case 0:
            myMovie.Add(Menu.Item0());
            //            break;


            //        default:
            //            run = false;
            //            break;
            //    }

            //}

            //myMovie.Print();

            CacheClient.CacheWrite(myMovie);

        }
    }
}
