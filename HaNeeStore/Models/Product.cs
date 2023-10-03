using System;
using System.Collections.Generic;

namespace HaNeeStore.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ShortDecs { get; set; }

    public string? Description { get; set; }

    public string? Size { get; set; }

    public int? Price { get; set; }

    public string? ProductPhoto { get; set; }

    public int? CatId { get; set; }

    public string? UnitsInStock { get; set; }

    public virtual Category? Cat { get; set; }
}
