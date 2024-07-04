using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Empleado
{
    public uint IdEmpleado { get; set; }

    public uint CedulaEmpleado { get; set; }

    public string? NombreEmpleado { get; set; }

    public string? ApellidosEmpleado { get; set; }

    public byte IdRol { get; set; }

    public byte IdArea { get; set; }

    public string TelefonoEmpleado { get; set; } = null!;

    public string EmailEmpleado { get; set; } = null!;

    public string? DireccionEmpleado { get; set; }

    public string LoginUs { get; set; } = null!;

    public string PasswordEmpleado { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }

    public DateTime? FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }

    public ulong? EmpleadoStatus { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Historialventa> Historialventa { get; set; } = new List<Historialventa>();

    public virtual ICollection<Horariostrabajo> Horariostrabajos { get; set; } = new List<Horariostrabajo>();

    public virtual Areastrabajo IdAreaNavigation { get; set; } = null!;

    public virtual Role IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Salario> Salarios { get; set; } = new List<Salario>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
