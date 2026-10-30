using System;
using System.Collections.Generic;

namespace AsientosBack.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Asiento> Asientos { get; set; } = new List<Asiento>();
}
