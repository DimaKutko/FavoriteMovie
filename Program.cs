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

            //Console.WriteLine($"Select: {select}");

            ShortMovie movie = (ShortMovie)movies[select];

            Console.Clear();

            Console.SetCursorPosition(0, 0);

            Console.WriteLine(movie.ToString());

            data = api.GetMovie(movie.ID);

            XmlClient xml = new XmlClient();

            var full = xml.XmlToFullMovie(data);

            Console.WriteLine(full.ToString());

            Console.ReadKey();

            //m.PrintMenu();

            //Console.ReadKey();
        }
    }
}
