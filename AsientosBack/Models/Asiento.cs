using System;
using System.Collections.Generic;

namespace AsientosBack.Models;

public partial class Asiento
{
    public int IdAsiento { get; set; }

    public DateTime? FechaAsiento { get; set; }

    public int IdDepartamento { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdMovimiento { get; set; }

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual Movimiento IdMovimientoNavigation { get; set; } = null!;
}
