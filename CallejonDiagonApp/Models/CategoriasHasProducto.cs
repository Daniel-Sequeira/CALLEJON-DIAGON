using System;
using System.Collections.Generic;

namespace CallejonDiagonApp.Models;

public partial class CategoriasHasProducto
{
    public sbyte CategoriasIdCategoria { get; set; }

    public uint ProductosIdProducto { get; set; }

    public virtual Categoria CategoriasIdCategoriaNavigation { get; set; } = null!;
}
