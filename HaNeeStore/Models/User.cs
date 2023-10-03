using System;
using System.Collections.Generic;

namespace HaNeeStore.Models;


public partial class User
{
    public string UserName { get; set; } = null!;

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Password { get; set; }

    public int? RoleUser { get; set; } = 0;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
