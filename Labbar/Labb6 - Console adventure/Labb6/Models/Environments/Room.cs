using Labb6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6.Models.Environments
{
    class Room : IEnvironment
    {
        
        List<INonPlayerCharacter> nonPlayerCharacters;
        public List<INonPlayerCharacter> NonPlayerCharacters
        {
            get
            {
                if (nonPlayerCharacters == null) nonPlayerCharacters = new List<INonPlayerCharacter>();
                return nonPlayerCharacters;
            }
        }

        public int PositionInMap { get; private set; }

        public string Description { get; private set; }

        public string ObservationDescription { get; private set; }


        public Room(int positionInMap, string description, string observationDescription)
        {
            PositionInMap = positionInMap;
            Description = description;
            ObservationDescription = observationDescription;
        }

        public string Observe()
        {
            string observation = ObservationDescription;

            foreach (var nonPlayerCharacter in NonPlayerCharacters)
            {
                observation += "\nYou see a " + nonPlayerCharacter.Name;
            }

            return observation;
        }
    }
}
