using Labb5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb5.DataStores
{
    class MyLists
    {
        private static List<Game> games;

        public static List<Game> Games
        {
            get
            {
                if (games == null)
                    games = new List<Game>();

                return games;
            }
        }

        private static List<Book> books;

        public static List<Book> Books
        {
            get
            {
                if (books == null)
                    books = new List<Book>();

                return books;
            }
        }
    }
}
