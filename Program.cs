using System;

namespace FavoriteMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            //RestApiClient api = new RestApiClient();

            //String data = api.SerchAllMovie("Avatar");

            //SearchList movies = new SearchList(data);

            //movies.Print();

            Menu m = new Menu();

            m.PrintMenu();

            Console.ReadKey();
        }
    }
}
