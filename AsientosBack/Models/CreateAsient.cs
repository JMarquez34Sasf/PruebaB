namespace AsientosBack.Models
{
    public class CreateAsient
    {
        

        public DateTime? FechaAsiento { get; set; }

        public int IdDepartamento { get; set; }

        public string Descripcion { get; set; } = null!;

        public int IdMovimiento { get; set; }
    }
}
