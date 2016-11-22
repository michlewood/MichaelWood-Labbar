using Labb14.Models.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb14.Models.Publications
{
    class Publication
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
