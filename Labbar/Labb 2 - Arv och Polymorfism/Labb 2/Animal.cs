﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    abstract public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }

        public Animal() { }

        abstract public string Move();

        abstract public string Talk();

        public virtual string Description()
        {
            string type = this.GetType().ToString();
            type = type.Remove(0, 7);
            return String.Format("{0} is a {1} years old {2} and weighs {3}. It {4} and it makes a {5} sound.", Name, Age, type.ToLower(), Weight, Move(), Talk());
        }
    }
}
