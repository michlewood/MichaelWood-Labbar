using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb5.Models
{
    class Book
    {
        public enum GenreType
        {
            Scifi = 1,
            Fanstasy,
            Horror,
            Comedy,
            Thriller,
            GameGuide
        }

        public string Name { get; set; }
        public GenreType Genre { get; set; }
    }
}
