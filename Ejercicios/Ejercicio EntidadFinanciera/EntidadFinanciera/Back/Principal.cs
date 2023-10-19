using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back
{
    public class Principal
    {
        public void AgregarCliente(Cliente nuevoCliente)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Clientes.Add(nuevoCliente);
                context.SaveChanges();
            }
        }

        //public void CrearCuentaBancaria(int clienteId, CuentaBancaria nuevaCuenta)
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        var cliente = context.Clientes.Include(c => c.CuentasBancarias).FirstOrDefault(c => c.Id == clienteId);
        //        if (cliente != null)
        //        {
        //            cliente.CuentasBancarias.Add(nuevaCuenta);
        //            context.SaveChanges();
        //        }
        //    }
        //}

        //public void EmitirTarjetaCredito(int clienteId, TarjetaCredito nuevaTarjeta)
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        var cliente = context.Clientes.Include(c => c.TarjetasCredito).FirstOrDefault(c => c.Id == clienteId);
        //        if (cliente != null)
        //        {
        //            cliente.TarjetasCredito.Add(nuevaTarjeta);
        //            context.SaveChanges();
        //        }
        //    }
        //}

        public void RealizarDeposito(int cuentaId, decimal monto)
        {
            using (var context = new ApplicationDbContext())
            {
                var cuenta = context.CuentasBancarias.FirstOrDefault(c => c.id == cuentaId);
                if (cuenta != null)
                {
                    cuenta.saldo += monto;
                    context.SaveChanges();
                }
            }
        }

        public void RealizarExtraccion(int cuentaId, decimal monto)
        {
            using (var context = new ApplicationDbContext())
            {
                var cuenta = context.CuentasBancarias.FirstOrDefault(c => c.id == cuentaId);
                if (cuenta != null && cuenta.saldo >= monto)
                {
                    cuenta.saldo -= monto;
                    context.SaveChanges();
                }
            }
        }

        public void RealizarTransferencia(int cuentaOrigenId, int cuentaDestinoId, decimal monto)
        {
            using (var context = new ApplicationDbContext())
            {
                var cuentaOrigen = context.CuentasBancarias.FirstOrDefault(c => c.id == cuentaOrigenId);
                var cuentaDestino = context.CuentasBancarias.FirstOrDefault(c => c.id == cuentaDestinoId);
                if (cuentaOrigen != null && cuentaDestino != null && cuentaOrigen.saldo >= monto)
                {
                    cuentaOrigen.saldo -= monto;
                    cuentaDestino.saldo += monto;
                    context.SaveChanges();
                }
            }
        }

        public void PagarTarjetaCredito(int tarjetaId, decimal monto)
        {
            using (var context = new ApplicationDbContext())
            {
                var tarjeta = context.TarjetasCredito.FirstOrDefault(t => t.id == tarjetaId);
                if (tarjeta != null && tarjeta.saldoActual >= monto)
                {
                    tarjeta.saldoActual -= monto;
                    context.SaveChanges();
                }
            }
        }

        public void GenerarResumenTarjeta(int tarjetaId)
        {
            using (var context = new ApplicationDbContext())
            {
                var tarjeta = context.TarjetasCredito.FirstOrDefault(t => t.id == tarjetaId);
                if (tarjeta != null)
                {
                    Console.WriteLine($"Resumen de Tarjeta de Crédito - Número de Tarjeta: {tarjeta.numeroTarjeta}");
                    Console.WriteLine($"Saldo Actual: {tarjeta.saldoActual:C}");
                    Console.WriteLine($"Límite de Crédito: {tarjeta.limiteCredito:C}");
                    Console.WriteLine($"Total a Pagar: {tarjeta.limiteCredito - tarjeta.saldoActual:C}");
                }
            }
        }
    }
}
