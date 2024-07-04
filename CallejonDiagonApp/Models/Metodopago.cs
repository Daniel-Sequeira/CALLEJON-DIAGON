using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Metodopago
{
    public byte IdMetodoPago { get; set; }

    public string? TipoPago { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Historialventa> Historialventa { get; set; } = new List<Historialventa>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
