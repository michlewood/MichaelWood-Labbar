using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb11
{
    class Runtime
    {
        public event EventHandler NumberInput;

        protected virtual void OnNumberInput(EventArgs e, int input)
        {
            EventHandler handler = NumberInput;

            if (handler != null)
            {
                AnalyzeNumber even = IsEven;
                AnalyzeNumber divisableByThree = IsDivisableByThree;
                AnalyzeNumber prime = IsPrime;
                Console.WriteLine("{0}", even(input) ? "Is even" : "Is not even");
                Console.WriteLine("{0}", divisableByThree(input) ? "Is divisable by three" : "Is not divisable by three");
                Console.WriteLine("{0}", prime(input) ? "Is prime" : "Is not prime");
                Console.ReadLine();
                handler(this, e);
            }
        }

        public delegate bool AnalyzeNumber(int input);

        public bool IsEven(int input)
        {
            if (input % 2 == 0)
                return true;
            else return false;
        }

        public bool IsDivisableByThree(int input)
        {
            if (input % 3 == 0)
                return true;
            else return false;
        }

        public bool IsPrime(int input)
        {
            var notPrime = false;
            for (int i = 2; i < input; i++)
            {
                if (input % i == 0)
                    notPrime = true;
            }
            if (!notPrime && input != 1)
                return true;
            else return false;
        }

        public void Start()
        {
            NumberInput += (sender, e) => { };
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

                if (validInput) OnNumberInput(EventArgs.Empty, input);

            }
        }
    }
}
