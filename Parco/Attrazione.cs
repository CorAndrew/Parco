using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parco
{
    public abstract class Attrazione
    {
        public string nome { get; set; }
        public int eta { get; set; }
        public int alteza { get; set; }
        public int peso { get; set; }
        public bool hafastPass { get; set; }
        public int gettoni { get; set; }
    }
}
