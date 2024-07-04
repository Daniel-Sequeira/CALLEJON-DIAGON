using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Venta
{
    public ulong IdVenta { get; set; }

    public int? IdCliente { get; set; }

    public byte IdMetodoPago { get; set; }

    public DateTime? FechaVenta { get; set; }

    public decimal? SubttotalVenta { get; set; }

    public decimal? Iva { get; set; }

    public decimal? ImporteTotalVenta { get; set; }

    public uint IdEmpleado { get; set; }

    public ulong? VentaStatus { get; set; }

    public uint ClientesIdCliente { get; set; }

    public virtual Cliente ClientesIdClienteNavigation { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Metodopago IdMetodoPagoNavigation { get; set; } = null!;

    public virtual ICollection<Ventasdetalle> Ventasdetalles { get; set; } = new List<Ventasdetalle>();
}
