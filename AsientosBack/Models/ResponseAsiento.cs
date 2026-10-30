namespace AsientosBack.Models
{
    public class ResponseAsiento
    {
        public int IdAsiento { get; set; }

        public DateTime? FechaAsiento { get; set; }

        public string Departamento { get; set; }

        public string Descripcion { get; set; } = null!;

        public int IdMovimiento { get; set; }
    }
}
