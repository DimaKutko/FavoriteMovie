using System;

namespace FavoriteMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            RestApiClient api = new RestApiClient();

            String data = api.SerchAllMovie("Avatar");

            SearchList movies = new SearchList(data);

            movies.Print();



            Menu m = new Menu();

            int select = m.Selector(movies.Size);

            Console.WriteLine($"Select: {select}");

            //m.PrintMenu();

            //Console.ReadKey();
        }
    }
}
