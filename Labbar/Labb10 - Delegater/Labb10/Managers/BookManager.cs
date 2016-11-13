using Labb10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb10.Managers
{
    class BookManager
    {
        public List<Book> Books { get; set; }

        public delegate void BookFilter(Book book);

        public BookManager()
        {
            Books = new List<Book>
            {
                new Book { Title = "At the Mountains of Madness", Pages = 128  },
                new Book { Title = "The Hitchhiker's Guide to the Galaxy", Pages = 224 }
            };
        }

        public void PrintWhere(BookFilter filter)
        {

        }
    }
}
