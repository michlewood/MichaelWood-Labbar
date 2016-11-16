using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb12
{
    class FilmManager
    {
        List<Film> films = new List<Film>
        {
            new Film {Title = "Film1", Length = 200, Genre = Film.Genres.Genre3 },
            new Film {Title = "Film2", Length = 100, Genre = Film.Genres.Genre1 },
            new Film {Title = "Film3", Length = 120, Genre = Film.Genres.Genre2 },
            new Film {Title = "Movie1", Length = 210, Genre = Film.Genres.Genre2 },
            new Film {Title = "Movie2", Length = 80, Genre = Film.Genres.Genre3 }
        };

        public Film GetFilmWithName(string name)
        {
            return films.Find(film => film.Title == name);
        }

        public List<Film> GetListOfFilmsWithGenre(Film.Genres genre)
        {
            return films.Where(film => film.Genre == genre).ToList();
        }

        public List<Film> GetListOfFilmsUnderACertainLength(int length)
        {
            return films.Where(film => film.Length <= length).ToList();
        }

        public string[] ReturnFilmNames()
        {
            return films.Select(film => film.Title ).ToArray();
        }

        public List<Film> GetListOfFilmsThatStartWithASpecifiedLetter(char firstLetter)
        {
            return films.Where(film => film.Title[0] == firstLetter).ToList();
        }

        public string Print(Film film)
        {
            return string.Format("{0}: Genre: {1}. Length: {2}", film.Title, film.Genre, film.Length);
        }
    }
}
