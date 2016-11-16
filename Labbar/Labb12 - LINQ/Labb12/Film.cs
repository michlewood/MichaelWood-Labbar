using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb12
{
    class Film
    {
        public string Title { get; set; }
        public int Length { get; set; }

        public enum Genres
        {
            Genre1 = 1,
            Genre2,
            Genre3
        }

        public Genres Genre { get; set; }
    }
}
