using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parco
{
    public interface IRiparabile
    {
        public bool IsGuasto { get; set; }
        public int TempoRiparazione { get; set; }
        public float CostoRiparazione { get; set; }

        public void SegnalaGuasto()
        {

        }

        public void Riparazione()
        {

        }
    }
}
