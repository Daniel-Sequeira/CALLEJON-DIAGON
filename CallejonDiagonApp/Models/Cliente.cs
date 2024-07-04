using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Cliente
{
    public uint IdCliente { get; set; }

    public uint CedulaCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? ApellidosCliente { get; set; }

    public string TelefonoCliente { get; set; } = null!;

    public string EmailCliente { get; set; } = null!;

    public string? DireccionCliente { get; set; }

    public ulong? ClienteStatus { get; set; }

    public virtual ICollection<Historialventa> Historialventa { get; set; } = new List<Historialventa>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
