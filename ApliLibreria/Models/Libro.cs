using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Libro
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? Chapters { get; set; }

    public int? Pages { get; set; }

    public decimal? Price { get; set; }

    public int? AuthorId { get; set; }

    public virtual Autor? Author { get; set; }
}
