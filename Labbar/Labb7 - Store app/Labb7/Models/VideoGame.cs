using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb7.Models
{
    class VideoGame : Product
    {
        public enum Genre
        {
            RolePlayingGame
        }
        public Genre GenreType { get; set; }

        public VideoGame()
        {
            Type = TypesOfProduct.VideoGames;
        }
    }
}
