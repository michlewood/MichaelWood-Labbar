using Labb8.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb8.Datastores
{
    class MyLists
    {
        public List<string> StringList { get; set; }
        public List<float> FloatList { get; set; }
        List<Product> productList;

        public List<Product> ProductList
        {
            get {
                if (productList == null)
                    productList = new List<Product>();
                return productList;
            }
            set { productList = value; }
        }


        public MyLists()
        {
            #region G-Uppgift
            StringList = new List<string>
            {
                "String 1",
                "String 2",
                "String 3",
                "String 4",
                "String 5",
                "Hello",
                "World",
                "Foo",
                "Bar"
            };

            FloatList = new List<float>
            {
                5,
                (float)3.2,
                (float)1.1,
            };
            #endregion
        }
    }
}
