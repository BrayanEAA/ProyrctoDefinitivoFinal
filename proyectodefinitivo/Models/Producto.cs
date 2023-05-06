using System;
using System.Collections.Generic;

namespace proyectodefinitivo.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public decimal Precio { get; set; }

    public string Descripcion { get; set; } = null!;

    public string NombreProducto { get; set; } = null!;

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
