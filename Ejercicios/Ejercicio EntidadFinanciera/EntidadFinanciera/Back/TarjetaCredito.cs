namespace Back
{
    public class TarjetaCredito
    {
        public int id { get; set; }
        public string numeroTarjeta { get; set; }
        public decimal limiteCredito { get; set; }
        public decimal saldoActual { get; set; }
        public int clienteId { get; set; }
        public Cliente clienteTC { get; set; }
        public EstadoTarjeta estado { get; set; } // Agregar la propiedad de estado

        public enum EstadoTarjeta
        {
            Activa,
            Pausada,
            Bloqueada
        }
    }

}