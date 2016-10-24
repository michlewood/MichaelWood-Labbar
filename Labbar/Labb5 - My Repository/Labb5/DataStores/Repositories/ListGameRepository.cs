using Labb5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb5.DataStores.Repositories
{
    class ListGameRepository : IRepository
    {
        public Game[] GetGames()
        {
            return MyLists.Games.ToArray();
        }

        public void AddGame(Game newGame)
        {
            MyLists.Games.Add(newGame);
        }

        public void RemoveGame(Game game)
        {
            MyLists.Games.Remove(game);
        }

        public Book[] GetBooks()
        {
            throw new NotImplementedException();
        }

        public void AddBook(Book newBook)
        {
            throw new NotImplementedException();
        }

        public void RemoveBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
