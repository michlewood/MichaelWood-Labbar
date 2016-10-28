using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6.Interfaces
{
    interface IEnvironment
    {
        List<INonPlayerCharacter> NonPlayerCharacters { get; }
        int PositionInMap { get; }
        string Description { get; }
        string ObservationDescription { get; }
        string NewDescriptionIfNonPlayerCharacterIsRemoved { get; }

        void Observe();

        void UpdateDescription();
    }
}
