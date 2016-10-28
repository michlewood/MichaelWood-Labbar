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
        public string NewDescriptionIfNonPlayerCharacterIsRemoved { get; private set; }

        public Room(int positionInMap, string description, string observationDescription, string enemyRemovedDescription = "")
        {
            PositionInMap = positionInMap;
            Description = description;
            ObservationDescription = observationDescription;
            NewDescriptionIfNonPlayerCharacterIsRemoved = enemyRemovedDescription;
        }

        public void Observe()
        {
            Console.WriteLine(ObservationDescription);

            foreach (var nonPlayerCharacter in NonPlayerCharacters)
            {
                Console.Write("You see a(n) ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(nonPlayerCharacter.Name);
                Console.ResetColor();
            }
        }

        public void UpdateDescription()
        {
            if (NonPlayerCharacters.Count == 0 && NewDescriptionIfNonPlayerCharacterIsRemoved != "")
            {
                ObservationDescription = NewDescriptionIfNonPlayerCharacterIsRemoved;
            }
        }
    }
}
