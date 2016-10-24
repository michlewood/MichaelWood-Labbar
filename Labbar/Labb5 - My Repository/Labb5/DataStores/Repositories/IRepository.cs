using Labb5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb5.DataStores.Repositories
{
    interface IRepository
    {
        Game[] GetGames();
        Book[] GetBooks();
        void AddGame(Game newGame);
        void AddBook(Book newBook);
        void RemoveGame(Game game);
        void RemoveBook(Book book);
    }
}
