using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Historialventa
{
    public ulong IdHistorialVentas { get; set; }

    public DateTime? FechaVenta { get; set; }

    public uint IdEmpleado { get; set; }

    public uint IdCliente { get; set; }

    public uint IdProducto { get; set; }

    public byte IdMetodoPago { get; set; }

    public decimal? TotalVenta { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Metodopago IdMetodoPagoNavigation { get; set; } = null!;
}
