using Labb14.Models.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb14.Managers
{
    class AuthorManager
    {
        public List<Author> AuthorList { get; set; }

        public AuthorManager()
        {
            AuthorList = new List<Author>
            {
                new Author {Name = "Author1", Age = 20 },
                new Author {Name = "Author2", Age = 54 },
                new Author {Name = "Author3", Age = 37 }

            };
        }   
    }
}
