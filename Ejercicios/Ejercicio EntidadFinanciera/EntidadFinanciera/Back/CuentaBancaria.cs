using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back
{
    public class CuentaBancaria
    {
        public int id { get; set; }
        public string numeroCuenta { get; set; }
        public decimal saldo { get; set; }
        public string tipo { get; set; }
        public int clienteId { get; set; }
        public Cliente clienteCB { get; set; }
    }
}
