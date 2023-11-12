using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Autor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
