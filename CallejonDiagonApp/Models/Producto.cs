using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Producto
{
    public uint IdProducto { get; set; }

    public string? NombreProducto { get; set; }

    public string? DescripcionProducto { get; set; }

    public uint IdProveedor { get; set; }

    public byte? IdUnidadMedida { get; set; }

    public byte? IdCategoria { get; set; }

    public decimal PrecioCosto { get; set; }

    public decimal PrecioVenta { get; set; }

    public decimal? Descuento { get; set; }

    public int? IdEmpleado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public ulong? ProductoStatus { get; set; }

    public byte[]? ImagenProducto { get; set; }

    public int? Existencias { get; set; }

    public byte UnidadesMedidasIdUnidadMedida { get; set; }

    public int ProveedoresIdProveedor { get; set; }

    public virtual Proveedore IdProveedorNavigation { get; set; } = null!;

    public virtual Unidadesmedida UnidadesMedidasIdUnidadMedidaNavigation { get; set; } = null!;
}
