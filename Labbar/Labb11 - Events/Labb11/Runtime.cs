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
            for (int i = 2; i < input; i++)
            {
                if (input % i == 0)
                    notPrime = true;
            }

            Console.WriteLine("{0}", !notPrime && input != 1 ? "Is prime" : "Is not prime");
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
