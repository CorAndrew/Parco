using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parco
{
    public interface IRiparabile
    {
            bool IsGuasto { get; }
            int TempoRiparazione { get; }
            double CostoRiparazione { get; }

            void SegnalaGuasto(int tempo, double costo);
            void Ripara();
        }
    }
