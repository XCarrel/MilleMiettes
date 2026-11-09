using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilleMiettes
{
    public class Special
    {
        public Special(string iD, string name, string picture, int price)
        {
            ID = iD;
            Name = name;
            Picture = picture;
            Price = price;
        }

        public string ID { get; private set; }
        public string Name { get; private set; }
        public string Picture { get; private set; }
        /// <summary>
        ///  Price in centimes (CHF 3.50 = 350)
        /// </summary>
        public int Price { get; set; }
    }
}
