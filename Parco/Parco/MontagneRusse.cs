using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parco
{
    public class MontagneRusse : Attrazione
    {
        public int AltezzaMinima { get; set; }
        public double SupplementoFastPass { get; set; }

        public MontagneRusse(string nome, int capienza, double tariffaBase, int altezzaMinima, double supplementoFastPass) : base(nome, capienza, tariffaBase)
        {
            AltezzaMinima = altezzaMinima;
            SupplementoFastPass = supplementoFastPass;
        }

        public override double Costo(Visitatore v)
        {
            double totale = TariffaBase;
            if (v.HaFastPass)
            {
                totale += SupplementoFastPass;
            }
            return totale;
        }

        public override bool Verifica(Visitatore v)
        {
            return v.Altezza >= AltezzaMinima;
        }

        public override string Descrizione()
        {
            return base.Descrizione() + $"Altezza Minima: {AltezzaMinima} | Supplemento FastPass: {SupplementoFastPass}";
        }
    }
}
