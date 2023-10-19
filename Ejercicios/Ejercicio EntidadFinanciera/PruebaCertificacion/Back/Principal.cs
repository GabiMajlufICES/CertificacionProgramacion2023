using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back
{
    public class Principal
    {
        BaseDatos baseDatos = new BaseDatos();

        public void AgregarProducto(Producto producto) 
        { 
            baseDatos.Productos.Add(producto);
            baseDatos.SaveChanges();
        }

        public void AgregarCuentaBancaria(string tipo, int idCliente)
        {
            CuentaBancaria cuentaBancaria = new CuentaBancaria();

            var clienteEncontrado = baseDatos.Clientes.Find(idCliente);
                       
            if (clienteEncontrado != null)
            {
                cuentaBancaria.saldo = 0;
                cuentaBancaria.clienteCuentaBancaria = clienteEncontrado;
                cuentaBancaria.tipo= tipo;

                var nroCuenta = (clienteEncontrado.dni).ToString();

                if (tipo == "CC")
                {
                    nroCuenta = nroCuenta + "1111"; 
                }
                else
                {
                    nroCuenta = nroCuenta + "2222";
                }
                cuentaBancaria.nroCuenta = long.Parse(nroCuenta);

                baseDatos.CuentasBancarias.Add(cuentaBancaria);
                baseDatos.SaveChanges();
            }                
        }

    }
}
