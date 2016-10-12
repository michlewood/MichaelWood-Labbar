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
            return String.Format("{0} is {1} years old and is a {2}",
                                   Name, Age, Breed);
        }
    }
}