using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilleMiettes
{
    public class Special
    {
        public Special(string iD, string name, string picture, double price)
        {
            ID = iD;
            Name = name;
            Picture = picture;
            Price = price;
        }

        public string ID { get; private set; }
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public double Price { get; set; }
    }
}
