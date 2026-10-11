using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parco
{
    public class Bagno : IRiparabile
    {
        public string Ubicazione { get; set; }
        public bool IsGuasto { get; private set; }
        public int TempoRiparazione { get; private set; }
        public double CostoRiparazione { get; private set; }

        public Bagno(string ubicazione)
        {
            Ubicazione = ubicazione;
            IsGuasto = false;
            TempoRiparazione = 0;
            CostoRiparazione = 0.0;
        }

        public void SegnalaGuasto(int tempo, double costo)
        {
            IsGuasto = true;
            TempoRiparazione = tempo;
            CostoRiparazione = costo;
        }

        public void Ripara()
        {
            IsGuasto = false;
            TempoRiparazione = 0;
            CostoRiparazione = 0.0;
        }
    }
}
