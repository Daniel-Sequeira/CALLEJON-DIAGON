using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Detallesalario
{
    public ulong IdDetalleSalario { get; set; }

    public byte IdSalario { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? SubtotalSalario { get; set; }

    public decimal? TotalSalario { get; set; }

    public virtual Salario IdSalarioNavigation { get; set; } = null!;
}
