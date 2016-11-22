using Labb14.Models.Publications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb14.Managers
{
    class PublicationManager
    {
        public List<Publication> PublicationList { get; set; }
        public AuthorManager authorManager { get; set; }

        public PublicationManager()
        {
            PublicationList = new List<Publication>
            {
                new Book {Title = "Book1", Author = authorManager.AuthorList[0], Genre = "Genre1", Pages = 200, ReleaseDate = new DateTime(2016, 11, 22) },
                new Book {Title = "Book2", Author = authorManager.AuthorList[1], Genre = "Genre2", Pages = 150, ReleaseDate = new DateTime(1992, 10, 18) },
                new Magazine {Title = "Magazine1", Author = authorManager.AuthorList[2], ReleaseDate = new DateTime(2002, 03, 22)},
                new Paper {Title = "Paper1", Author = authorManager.AuthorList[1], ReleaseDate = new DateTime(2013, 07, 11) }
            };
        }
    }
}
