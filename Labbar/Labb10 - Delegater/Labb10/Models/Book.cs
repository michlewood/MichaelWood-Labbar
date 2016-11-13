using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb10.Models
{
    class Book
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public enum Genres
        {
            Wierd = 1,
            Comedy,
            Mystery,
            Fantasy,
            Romance
        }

        public Genres Genre { get; set; }
        public double Price { get; set; }
    }
}
