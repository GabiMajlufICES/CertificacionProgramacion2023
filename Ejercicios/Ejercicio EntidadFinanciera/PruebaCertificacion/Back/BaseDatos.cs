using Microsoft.EntityFrameworkCore;

namespace Back
{
    public class BaseDatos : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<CuentaBancaria> CuentasBancarias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=GABI\\SQLEXPRESS;database=Certificacion;trusted_connection=true;Encrypt=False");
        }

    }
}
