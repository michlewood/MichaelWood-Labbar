using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb12
{
    class Runtime
    {
        public void Start()
        {
            FilmManager filmManager = new FilmManager();
            Film film = filmManager.GetFilmWithName("Film2");
            Console.WriteLine("Film called film2:");
            Console.WriteLine(filmManager.Print(film));
            Console.WriteLine("\nFilms of the genre genre3:");
            List<Film> films = filmManager.GetListOfFilmsWithGenre(Film.Genres.Genre3);
            foreach (var movie in films)
            {
                Console.WriteLine(filmManager.Print(movie));
            }
            Console.WriteLine("\nfilms under 120 length:");

            films = filmManager.GetListOfFilmsUnderACertainLength(120);
            foreach (var movie in films)
            {
                Console.WriteLine(filmManager.Print(movie));
            }
            Console.WriteLine("\nlist of all the names of films:");

            string[] namesOfMovies = filmManager.ReturnFilmNames();
            foreach (var name in namesOfMovies)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("\nFilms that start with F:");

            films = filmManager.GetListOfFilmsThatStartWithASpecifiedLetter('F');
            foreach (var movie in films)
            {
                Console.WriteLine(filmManager.Print(movie));
            }
        }
    }
}
