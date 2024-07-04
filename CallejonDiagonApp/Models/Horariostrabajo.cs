using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Horariostrabajo
{
    public byte IdHorarioTrabajo { get; set; }

    public string? DescripcionHorario { get; set; }

    public uint IdEmpleado { get; set; }

    public virtual ICollection<Detallehorariotrabajo> Detallehorariotrabajos { get; set; } = new List<Detallehorariotrabajo>();

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
