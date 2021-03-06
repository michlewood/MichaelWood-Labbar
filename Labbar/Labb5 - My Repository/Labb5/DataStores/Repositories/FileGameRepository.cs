﻿using Labb5.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb5.DataStores.Repositories
{
    class FileGameRepository : IRepository
    {
        public FileGameRepository()
        {
            if (MyLists.Games.Count == 0) MyLists.Games.AddRange(GetFile());
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

        public Game[] GetGames()
        {
            return MyLists.Games.ToArray();
        }

        public void AddGame(Game newGame)
        {
            MyLists.Games.Add(newGame);
            Update();
        }

        public void RemoveGame(Game game)
        {
            MyLists.Games.Remove(game);
            Update();
        }

        public void Update()
        {
            List<string> tempList = new List<string>();

            foreach (var game in MyLists.Games)
            {
                tempList.Add(game.Name);
                tempList.Add(((int)game.Genre).ToString());
            }

            File.WriteAllLines(FindFileLocation(), tempList);
        }

        Book[] IRepository.GetBooks()
        {
            throw new NotImplementedException();
        }

        void IRepository.AddBook(Book newBook)
        {
            throw new NotImplementedException();
        }

        void IRepository.RemoveBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
