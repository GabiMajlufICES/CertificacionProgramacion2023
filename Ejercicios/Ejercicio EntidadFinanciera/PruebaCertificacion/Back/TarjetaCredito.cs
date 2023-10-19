using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back
{
    public class TarjetaCredito
    {
        public int id { get; set; }
        public int nroTarjeta { get; set; }
        public int limiteCredito { get; set; }
        public float saldoDisponible { get; set; }
        public float montoDeuda { get; set; }
        public string estado { get; set; }
        public Cliente clienteTarjetaCredito { get; set; }
    }
}
