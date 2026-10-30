namespace AsientosBack.Models
{
    public class ResponseMovimiento
    {
        public int IdMovimiento { get; set; }

        public string Ncuenta { get; set; } = null!;

        public decimal Valor { get; set; }

        public DateTime? Fecha { get; set; }

        public string? Descripcion { get; set; }

        public string Tipo { get; set; }
    }
}
