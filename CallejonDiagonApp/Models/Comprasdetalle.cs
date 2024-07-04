using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Comprasdetalle
{
    public long IdCompraDetalle { get; set; }

    public ulong? IdCompra { get; set; }

    public int? IdProducto { get; set; }

    public decimal? PrecioCostoUnitario { get; set; }

    public int? Cantidad { get; set; }

    public decimal? ImporteTotalCompra { get; set; }

    public ulong ComprasIdCompra { get; set; }

    public uint ComprasProveedoresIdProveedor { get; set; }

    public virtual Compra Compra { get; set; } = null!;
}
