using System;
using System.Collections.Generic;

namespace HaNeeStore.Models;

public partial class OrderDetail
{
    public int? OrderId { get; set; }
    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? Total { get; set; }

    public string? Information { get; set; }
    public virtual Order? Order { get; set; }
    public virtual Product? Product { get; set; }
}
