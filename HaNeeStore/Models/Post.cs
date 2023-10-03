using System;
using System.Collections.Generic;

namespace HaNeeStore.Models;

public partial class Post
{
    public int PostId { get; set; }

    public string? PostName { get; set; }

    public string? Contents { get; set; }

    public string? PostPhoto { get; set; }

    public DateTime? CreateDate { get; set; }
}
