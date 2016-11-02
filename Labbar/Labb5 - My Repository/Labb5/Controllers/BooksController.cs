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
            var newBook = Graphics.CreateBook();
            repository.AddBook(newBook);
        }

        public void RemoveBook()
        {
            var book = repository.GetBooks();
            var index = Graphics.SelectBook(book) - 1;
            repository.RemoveBook(book[index]);

        }

        public void EditBook()
        {
            var books = repository.GetBooks();
            Graphics.PrintBookList(books);
            int index = Graphics.SelectBook(books) - 1;

            Graphics.EditBook(books[index]);
            repository.Update();
        }

        public void PrintBookList()
        {
            Console.Clear();
            Graphics.PrintBookList(repository.GetBooks());
            Console.ReadKey(true);
        }
    }
}
