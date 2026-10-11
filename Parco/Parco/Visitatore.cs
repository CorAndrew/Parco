using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parco
{
    public class Visitatore
    {
        public string Nome { get; set; }
        public int Eta { get; set; }
        public int Altezza { get; set; }
        public int Peso { get; set; }
        public bool HaFastPass { get; set; }
        public int Gettoni { get; set; }

        public Visitatore(string nome, int eta, int altezza, int peso, bool haFastPass, int gettoni)
        {
            Nome = nome;
            Eta = eta;
            Altezza = altezza;
            Peso = peso;
            HaFastPass = haFastPass;
            Gettoni = gettoni;
        }


    }
}
