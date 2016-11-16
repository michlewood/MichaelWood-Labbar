using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb11
{
    class Runtime
    {
        public delegate void AnalyzeNumber(int input);

        public event AnalyzeNumber NumberInput;

        public void IsEven(int input)
        {
            Console.WriteLine("{0}", input % 2 == 0 ? "Is even" : "Is not even");
        }

        public void IsDivisableByThree(int input)
        {
            Console.WriteLine("{0}", input % 3 == 0 ? "Is divisable by three" : "Is not divisable by three");
        }

        public void IsPrime(int input)
        {
            var notPrime = false;
            
            if ((input % 2 == 0 && input != 2) || input == 1)
            {
                notPrime = true;
            }

            else
            {
                for (int i = 3; i < (int)Math.Sqrt(input)+1; i += 2)
                {
                    if (input % i == 0)
                        notPrime = true;
                } 
            }

            Console.WriteLine("{0}", !notPrime ? "Is prime" : "Is not prime");
        }

        public void Start()
        {
            NumberInput += IsEven;
            NumberInput += IsDivisableByThree;
            NumberInput += IsPrime;
            Loop();
        }

        private void Loop()
        {
            while (true)
            {
                Console.Clear();
                var input = 0;
                var validInput = false;

                Console.WriteLine("Enter a number");
                validInput = int.TryParse(Console.ReadLine(), out input);

                if (validInput) NumberInput(input);
                Console.ReadKey(true);
            }
        }
    }
}
