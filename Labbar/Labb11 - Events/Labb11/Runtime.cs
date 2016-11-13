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
                AnalyzeNumber divisByThree = IsDivisableByThree;
                AnalyzeNumber prime = IsPrime;
                if (even(input)) Console.WriteLine("Is Even");
                if (divisByThree(input)) Console.WriteLine("Is divisable by three");
                if (prime(input)) Console.WriteLine("Is Prime");
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
            if (!(input % 2 == 0 || input % 3 == 0 || input % 5 == 0 || input % 7 == 0
                || input % 11 == 0 || input % 13 == 0 || input % 17 == 0 || input % 19 == 0
                || input % 23 == 0 || input % 29 == 0 || input % 31 == 0 || input % 37 == 0))
                return true;
            else return false;
        }

        public void Start()
        {
            var loop = true;
            NumberInput += (sender, e) =>
            {
                

                loop = false;
            };
            Loop(loop);
        }

        private void Loop(bool loop)
        {
            while (loop)
            {
                Console.Clear();
                var input = 0;
                var validInput = false;

                Console.WriteLine("Enter a number");
                validInput = int.TryParse(Console.ReadLine(), out input);

                if ((validInput && -1000 <= input && input <= 1000)) OnNumberInput(EventArgs.Empty, input);

            }
        }



    }
}
