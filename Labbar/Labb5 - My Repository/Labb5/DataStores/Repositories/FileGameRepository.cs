using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb5.Models;
using System.IO;

namespace Labb5.DataStores.Repositories
{
    class FileGameRepository : IRepository
    {
        public void AddBook(Book newBook)
        {
            throw new NotImplementedException();
        }

        public void AddGame(Game newGame)
        {
            List<string> tempList = File.ReadAllLines(FindFileLocation()).ToList();

            tempList.AddRange(new List<string>()
            {
                newGame.Name,
                ((int)newGame.Genre).ToString()
            });
            File.WriteAllLines(FindFileLocation(), tempList);
        }

        private void UpdateList(Game[] gameList)
        {
            string[] toFile = new string[gameList.Length * 2];
            for (int i = 0; i < gameList.Length; i++)
            {
                toFile[i * 2] = gameList[i].Name;
                toFile[i * 2 + 1] = ((int)gameList[i].Genre).ToString();
            }
            File.WriteAllLines(FindFileLocation(), toFile);
        }

        public Book[] GetBooks()
        {
            throw new NotImplementedException();
        }

        public Game[] GetGames()
        {
            return GetFile();
        }

        private Game[] GetFile()
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

            Game[] tempList = new Game[fromFile.Length / 2];

            for (int i = 0; i < tempList.Length; i++)
            {
                tempList[i] = new Game()
                {
                    Name = fromFile[i * 2],
                    Genre = (Game.GenreType)int.Parse(fromFile[i * 2 + 1])
                };
            }

            return tempList;
        }

        private string FindFileLocation()
        {
            string filePath = Environment.CurrentDirectory;
            filePath = filePath.Remove(filePath.Length - 9, 9) + @"DataStores\games.txt";
            return filePath;
        }

        public void RemoveBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void RemoveGame(Game game)
        {
            List<string> tempList = File.ReadAllLines(FindFileLocation()).ToList();
            for (int i = 0; i < tempList.Count; i += 2)
            {
                if (tempList[i] == game.Name && tempList[i + 1] == ((int)game.Genre).ToString())
                {
                    tempList.RemoveRange(i, 2);
                }
            }
            
            File.WriteAllLines(FindFileLocation(), tempList);
        }
    }
}
