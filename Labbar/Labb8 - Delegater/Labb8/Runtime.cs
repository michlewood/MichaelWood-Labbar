using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb8
{
    class Runtime
    {
        public delegate string StringConcatinator(List<String> stringList);

        public string StringConcatinatorMethod(List<String> stringList)
        {
            string singleString = "";

            foreach (var item in stringList)
            {
                    singleString += item + ", " ; 
            }

            singleString = singleString.Remove(singleString.Length - 2, 2);
            return singleString;
        }

        public delegate float NumberOperator(List<float> floatList);

        public float NumberOperatorAddMethod(List<float> floatList)
        {
            float sum = 0;

            foreach (var item in floatList)
            {
                sum += item;
            }

            return sum;
        }

        public float NumberOperatorMultiplierMethod(List<float> floatList)
        {
            float product = 1;

            foreach (var item in floatList)
            {
                product *= item;
            }

            return product;
        }

        public void Start()
        {
            MyLists lists = new MyLists();
            StringConcatinator scDel = StringConcatinatorMethod;

            string stringer = scDel(lists.StringList);

            Console.WriteLine(stringer);

            NumberOperator moDel = NumberOperatorAddMethod;

            float floatResult = moDel(lists.FloatList);

            Console.WriteLine(floatResult);

            moDel = NumberOperatorMultiplierMethod;

            floatResult = moDel(lists.FloatList);

            Console.WriteLine(floatResult);
        }
    }
}
