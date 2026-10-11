using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parco
{
    namespace Fantasilandia
    {
        public class TorreCadutaLibera : MontagneRusse
        {
            public int PesoMassimo { get; set; }
            public double SupplementoTorre { get; set; }

            public TorreCadutaLibera(string nome, int capienza, double tariffaBase, int altezzaMinima, double supplementoFastPass, int pesoMassimo, double supplementoTorre) : base(nome, capienza, tariffaBase, altezzaMinima, supplementoFastPass)
            {
                PesoMassimo = pesoMassimo;
                SupplementoTorre = supplementoTorre;
            }

            public override double Costo(Visitatore v)
            {
                return base.Costo(v) + SupplementoTorre;
            }

            public override bool Verifica(Visitatore v)
            {
                return base.Verifica(v) && v.Peso <= PesoMassimo;
            }

            public override string Descrizione()
            {
                return base.Descrizione() + $"Peso Massimo: {PesoMassimo} | Supplemento Torre: {SupplementoTorre}";
            }
        }
    }
}
