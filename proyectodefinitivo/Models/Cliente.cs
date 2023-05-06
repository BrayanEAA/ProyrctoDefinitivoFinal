using System;
using System.Collections.Generic;

namespace proyectodefinitivo.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
