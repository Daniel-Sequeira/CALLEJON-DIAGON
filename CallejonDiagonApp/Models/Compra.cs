using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Compra
{
    public ulong IdCompra { get; set; }

    public uint IdProveedor { get; set; }

    public DateTime? FechaCompra { get; set; }

    public decimal? SubtotalCompra { get; set; }

    public decimal? Iva { get; set; }

    public decimal? ImporteTotalCompra { get; set; }

    public uint IdEmpleado { get; set; }

    public ulong? CompraStatus { get; set; }

    public uint ProveedoresIdProveedor { get; set; }

    public byte IdMetodoPago { get; set; }

    public virtual ICollection<Comprasdetalle> Comprasdetalles { get; set; } = new List<Comprasdetalle>();

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Metodopago IdMetodoPagoNavigation { get; set; } = null!;

    public virtual Proveedore ProveedoresIdProveedorNavigation { get; set; } = null!;
}
