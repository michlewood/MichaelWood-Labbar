using Labb5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb5.DataStores.Repositories
{
    class ListBookRepository : IRepository
    {
        public Book[] GetBooks()
        {
            return MyLists.Books.ToArray();
        }

        public void AddBook(Book newBook)
        {
            MyLists.Books.Add(newBook);
        }

        public void RemoveBook(Book book)
        {
            MyLists.Books.Remove(book);
        }

        public Game[] GetGames()
        {
            throw new NotImplementedException();
        }

        public void AddGame(Game newGame)
        {
            throw new NotImplementedException();
        }

        public void RemoveGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
