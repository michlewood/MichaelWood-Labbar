using Labb5.DataStores.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb5.Controllers
{
    class BooksController
    {
        private IRepository repository = new FileBookRepository();

        public void CreateBook()
        {
            var newBook = UI.CreateBook();
            repository.AddBook(newBook);
        }

        public void RemoveBook()
        {
            var book = repository.GetBooks();
            var index = UI.SelectBook(book) - 1;
            repository.RemoveBook(book[index]);

        }

        public void EditBook()
        {
            var books = repository.GetBooks();
            UI.PrintBookList(books);
            int index = UI.SelectBook(books) - 1;

            UI.EditBook(books[index]);
            repository.Update();
        }

        public void PrintBookList()
        {
            Console.Clear();
            UI.PrintBookList(repository.GetBooks());
            Console.ReadKey(true);
        }
    }
}
