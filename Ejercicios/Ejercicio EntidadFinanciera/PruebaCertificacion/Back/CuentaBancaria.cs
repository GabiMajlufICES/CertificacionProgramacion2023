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
        public long nroCuenta { get; set; }
        public float saldo { get; set; }
        public string tipo { get; set; }//Cuenta Corriente o Ahorro

         //public Enum tipoCuenta { Ahorro, Corriente}

        public Cliente clienteCuentaBancaria { get; set; }

    }
}
