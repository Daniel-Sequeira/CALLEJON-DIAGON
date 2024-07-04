using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Areastrabajo
{
    public byte IdArea { get; set; }

    public string? NombreArea { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
