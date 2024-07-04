using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Unidadesmedida
{
    public byte IdUnidadMedida { get; set; }

    public string? AbreviaturaMedida { get; set; }

    public string? DescripcionMedida { get; set; }

    public ulong? MedidaStatus { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
