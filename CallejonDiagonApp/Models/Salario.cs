using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Salario
{
    public byte IdSalario { get; set; }

    public decimal? SalarioBase { get; set; }

    public decimal? ValorHora { get; set; }

    public decimal? ValorHoraExtra { get; set; }

    public uint IdEmpleado { get; set; }

    public virtual ICollection<Detallesalario> Detallesalarios { get; set; } = new List<Detallesalario>();

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
