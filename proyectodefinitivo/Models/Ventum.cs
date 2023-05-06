using System;
using System.Collections.Generic;

namespace proyectodefinitivo.Models;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public int? IdCliente { get; set; }

    public int? IdProducto { get; set; }

    public int Cantidad { get; set; }

    public DateTime Fechapedido { get; set; }

    public decimal Total { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
