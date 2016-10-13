using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    abstract public class Bird : Animal
    {
        public bool CanFly { get; private set; }

        public Bird(string name, int age, int weight, bool canFly = true) : base(name, age, weight)
        {
            CanFly = canFly;
        }
    }

    public class Spearow : Bird , IPokemon
    {
        public bool CanEvolve { get; set; }
        public string Type { get; set; }

        public Spearow(string name, int age, int weight) : base(name, age, weight)
        {
            CanEvolve = true;
            Type = "flying-type";
        }


        public override string Move()
        {
            return "flies through the sky";
        }

        public override string Talk()
        {
            return "twerps";
        }

        public override string Description()
        {
            return string.Format("{0} is a {1} and can evolve",base.Description(), Type);
        }
    }

    public interface IPokemon
    {
        bool CanEvolve { get; set; }
        string Type { get; set; }
    }
}
