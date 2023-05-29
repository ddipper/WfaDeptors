using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtor
{
    class Dolzhnik
    {
        public string Name { get; set; }
        public decimal Dolg { get; set; }
        public DateTime Time { get; set; }
        public Dolzhnik(string name, decimal dolg , DateTime time)
        {
            Name = name;
            Dolg = dolg;
            Time = time;
        }

        public Dolzhnik()
        {
        }

        public override string ToString()
        {
            return $"{Name}|{Dolg}|{Time}";
        }
    }
}
