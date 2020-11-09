using System;

namespace FavoriteMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            RestApiClient api = new RestApiClient();

            String data = api.SerchAllMovie("Avatar");

            Console.WriteLine(data);

            Console.ReadKey();
        }
    }
}
