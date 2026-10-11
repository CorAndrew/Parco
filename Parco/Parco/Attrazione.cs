using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parco
{
    public abstract class Attrazione : IRiparabile
    {


        public string Nome { get; set; }
        public int Capienza { get; set; }
        public double TariffaBase { get; set; }
        public bool IsGuasto { get; set; }
        public int TempoRiparazione { get; set; }
        public double CostoRiparazione { get; set; }

        public Attrazione(string nome, int capienza, double tariffaBase)
        {
            Nome = nome;
            Capienza = capienza;
            TariffaBase = tariffaBase;
            IsGuasto = false;
            TempoRiparazione = 0;
            CostoRiparazione = 0.0;
        }

        public abstract double Costo(Visitatore v);
        public abstract bool Verifica(Visitatore v);

        public virtual string Descrizione()
        {
            string stato = IsGuasto ? "Guasta" : "Operativa";
            return $"{Nome} | Capienza: {Capienza} | Tariffa Base: {TariffaBase} | Stato: {stato}";
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
