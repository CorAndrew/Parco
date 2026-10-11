using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parco
{
    namespace Fantasilandia
    {
        public class GiostraBambini : Attrazione
        {
            public int EtaMassima { get; set; }

            public GiostraBambini(string nome, int capienza, double prezzoFisso, int etaMassima)
                : base(nome, capienza, prezzoFisso)
            {
                EtaMassima = etaMassima;
            }

            public override double Costo(Visitatore v)
            {
                return TariffaBase;
            }

            public override bool Verifica(Visitatore v)
            {
                return v.Eta <= EtaMassima;
            }

            public override string Descrizione()
            {
                return base.Descrizione() + $"Età Massima consentita: {EtaMassima} anni";
            }
        }
    }
}
