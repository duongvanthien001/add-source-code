using System;
using System.Collections.Generic;

namespace HaNeeStore.Models;

public partial class Order
{
    public int? OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? Paymentmethod { get; set; }

    public string? OrderStatus { get; set; }

    public int? CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }
}
