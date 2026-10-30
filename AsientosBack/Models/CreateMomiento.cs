using System.ComponentModel.DataAnnotations;

namespace AsientosBack.Models
{
    public class CreateMomiento
    {

        [Required(ErrorMessage ="Numero de cuenta requerido")]
        public string Ncuenta { get; set; } = null!;
        [Required(ErrorMessage ="Valor requerido")]
        public decimal Valor { get; set; }

        

        public string? Descripcion { get; set; }
        [Required(ErrorMessage ="Tipo de moviminto requerido")]
        public int IdTipo { get; set; }
    }
}
