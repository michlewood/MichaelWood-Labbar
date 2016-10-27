using Labb5.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb5.DataStores.Repositories
{
    class FileBookRepository : IRepository
    {
        public FileBookRepository()
        {
            if (MyLists.Books.Count == 0) MyLists.Books.AddRange(GetFile());
        }

        private Book[] GetFile()
        {
            string[] fromFile;

            try
            {
                fromFile = File.ReadAllLines(FindFileLocation());
            }
            catch (FileNotFoundException)
            {
                File.WriteAllText(FindFileLocation(), "");
                fromFile = File.ReadAllLines(FindFileLocation());
            }

            Book[] tempList = new Book[fromFile.Length / 2];

            for (int i = 0; i < tempList.Length; i++)
            {
                tempList[i] = new Book()
                {
                    Name = fromFile[i * 2],
                    Genre = (Book.GenreType)int.Parse(fromFile[i * 2 + 1])
                };
            }

            return tempList;
        }

        private string FindFileLocation()
        {
            string filePath = Environment.CurrentDirectory;
            filePath = filePath.Remove(filePath.Length - 9, 9) + @"DataStores\books.txt";
            return filePath;
        }


        public Book[] GetBooks()
        {
            return MyLists.Books.ToArray();
        }

        public void AddBook(Book newBook)
        {
            MyLists.Books.Add(newBook);
            Update();
        }

        public void RemoveBook(Book book)
        {
            MyLists.Books.Remove(book);
            Update();
        }

        public void Update()
        {
            List<string> tempList = new List<string>();

            foreach (var book in MyLists.Books)
            {
                tempList.Add(book.Name);
                tempList.Add(((int)book.Genre).ToString());
            }

            File.WriteAllLines(FindFileLocation(), tempList);
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
