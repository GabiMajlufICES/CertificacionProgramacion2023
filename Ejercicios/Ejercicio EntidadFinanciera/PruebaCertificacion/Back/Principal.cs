using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back
{
    public class Principal
    {
        public BaseDatos baseDatos = new BaseDatos();

        public void AgregarProducto(Producto producto) 
        { 
            baseDatos.Productos.Add(producto);
            baseDatos.SaveChanges();
        }

        public string AgregarCuentaBancaria(string tipo, int dniCliente)
        {
            var clienteEncontrado = baseDatos.Clientes.FirstOrDefault(x => x.dni == dniCliente);
            CuentaBancaria cuentaBancaria = new CuentaBancaria();
          
                       
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

                var cuentaBancariaEncontrada = baseDatos.CuentasBancarias.FirstOrDefault(x => x.nroCuenta == cuentaBancaria.nroCuenta);

                if (cuentaBancariaEncontrada == null)
                {
                    baseDatos.CuentasBancarias.Add(cuentaBancaria);
                    baseDatos.SaveChanges();
                    return "Cuenta agregada con exito";
                }
                else
                {
                    return "La cuenta ya existe";
                }
            }
            return "Cliente no encontrado";
                    
        }

    }
}
