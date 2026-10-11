using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parco
{
    namespace Fantasilandia
    {
        public class SalaGiochi : Attrazione
        {
            public double CostoPerGettone { get; set; }

            public SalaGiochi(string nome, int capienza, double costoPerGettone) : base(nome, capienza, 0.0)
            {
                CostoPerGettone = costoPerGettone;
            }

            public override double Costo(Visitatore v)
            {
                return v.Gettoni * CostoPerGettone;
            }

            public override bool Verifica(Visitatore v)
            {
                return true; // acesso sempre libero
            }

            public override string Descrizione()
            {
                return base.Descrizione() + $" Costo per gettone: {CostoPerGettone}";
            }
        }
    }
}
