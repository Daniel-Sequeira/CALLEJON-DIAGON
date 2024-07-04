using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Proveedore
{
    public uint IdProveedor { get; set; }

    public uint CedulaProveedor { get; set; }

    public string? NombreProveedor { get; set; }

    public string TelefonoProveedor { get; set; } = null!;

    public string EmailProveedor { get; set; } = null!;

    public ulong? ProveedorStatus { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
