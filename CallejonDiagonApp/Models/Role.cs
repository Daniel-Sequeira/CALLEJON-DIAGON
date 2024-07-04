using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Role
{
    public byte IdRol { get; set; }

    public string? NombreRol { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
