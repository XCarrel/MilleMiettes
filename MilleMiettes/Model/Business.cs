using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilleMiettes
{
    public class Business
    {
        public Business(string iD, string name, string logo, Special special)
        {
            ID = iD;
            Name = name;
            Logo = logo;
            Special = special;
        }

        public string ID { get; private set; }
        public string Name { get; private set; }
        public string Logo { get; private set; }
        public Special Special { get; private set; }
        /// <summary>
        ///  One entry per day of the week. Null when read from a data file written before opening hours existed.
        /// </summary>
        public List<OpeningDay>? OpeningHours { get; set; }
    }
}
