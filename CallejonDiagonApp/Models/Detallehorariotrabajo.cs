using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Detallehorariotrabajo
{
    public ulong IdDetalleHorarioT { get; set; }

    public DateTime? Fecha { get; set; }

    public TimeSpan? HoraEntada { get; set; }

    public TimeSpan? HoraSalida { get; set; }

    public byte? CantidadHoras { get; set; }

    public byte IdHorarioTrabajo { get; set; }

    public virtual Horariostrabajo IdHorarioTrabajoNavigation { get; set; } = null!;
}
