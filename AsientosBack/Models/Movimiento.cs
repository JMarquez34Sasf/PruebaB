using System;
using System.Collections.Generic;

namespace AsientosBack.Models;

public partial class Movimiento
{
    public int IdMovimiento { get; set; }

    public string Ncuenta { get; set; } = null!;

    public decimal Valor { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public int IdTipo { get; set; }

    public virtual ICollection<Asiento> Asientos { get; set; } = new List<Asiento>();

    public virtual TipoMovimiento IdTipoNavigation { get; set; } = null!;
}
