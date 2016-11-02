using Labb5.DataStores.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb5.Controllers
{
    class GamesController
    {
        private IRepository repository = new FileGameRepository();

        public void CreateGame()
        {
            var newGame = Graphics.CreateGame();
            repository.AddGame(newGame);
        }

        public void RemoveGame()
        {
            var games = repository.GetGames();
            var index = Graphics.SelectGame(games) - 1;
            repository.RemoveGame(games[index]);

        }

        public void EditGame()
        {
            var games = repository.GetGames();
            Graphics.PrintGameList(games);
            int index = Graphics.SelectGame(games) - 1;

            Graphics.EditGame(games[index]);
            repository.Update();
        }

        public void PrintGameList()
        {
            Console.Clear();
            Graphics.PrintGameList(repository.GetGames());
            Console.ReadKey(true);
        }
    }
}
