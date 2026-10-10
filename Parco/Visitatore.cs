using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parco
{
    public class Visitatore
    {
        public string nome {  get; set; }
        public int eta { get; set; }
        public int altezza { get; set; }
        public int peso { get; set; }
        public int gettoni { get; set; }
        public bool haFastPass { get; set; }

        public Visitatore (string n, int e, int a, int p, int g, bool fp)
        {
            nome = n;
            eta = e;
            altezza = a;
            peso = p;
            gettoni = g;
            haFastPass = fp;
        }
    }
}
