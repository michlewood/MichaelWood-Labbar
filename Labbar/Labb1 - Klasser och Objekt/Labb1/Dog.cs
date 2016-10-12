using System;

namespace Labb1
{
    public  class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }

        internal string Introduction()
        {
            return String.Format("Namn: {0}. Är {1} år gammal. Är en: {2}",
                                   Name, Age, Breed);
        }
    }
}