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
        void Update();

        Game[] GetGames();
        void AddGame(Game newGame);
        void RemoveGame(Game game);

        Book[] GetBooks();
        void AddBook(Book newBook);
        void RemoveBook(Book book);
    }
}
