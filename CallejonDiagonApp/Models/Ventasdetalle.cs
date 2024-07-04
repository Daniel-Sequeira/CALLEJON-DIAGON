using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Ventasdetalle
{
    public ulong IdVentaDetalle { get; set; }

    public ulong? IdVenta { get; set; }

    public uint? IdProducto { get; set; }

    public decimal? PrecioVentaUnitario { get; set; }

    public int? Cantidad { get; set; }

    public decimal? ImporteTotalVenta { get; set; }

    public ulong VentasIdVenta { get; set; }

    public uint VentasClientesIdCliente { get; set; }

    public uint ProductosIdProducto { get; set; }

    public byte ProductosUnidadesMedidasIdUnidadMedida { get; set; }

    public int ProductosProveedoresIdProveedor { get; set; }

    public virtual Venta VentasIdVentaNavigation { get; set; } = null!;
}
