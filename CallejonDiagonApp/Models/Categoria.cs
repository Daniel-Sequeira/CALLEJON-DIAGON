using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class Categoria
{
    public sbyte IdCategoria { get; set; }

    public string? NombreCategoria { get; set; }

    public ulong? CategoriaStatus { get; set; }

    public virtual ICollection<CategoriasHasProducto> CategoriasHasProductos { get; set; } = new List<CategoriasHasProducto>();
}
