using System;
using System.Collections.Generic;

namespace AsientosBack.Models;

public partial class TipoMovimiento
{
    public int IdTipo { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
