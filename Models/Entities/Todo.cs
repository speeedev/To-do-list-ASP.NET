using System;
using System.Collections.Generic;

namespace _1.Models.Entities;

public partial class Todo
{
    public int Id { get; set; }

    public bool? IsComplated { get; set; }

    public string? Title { get; set; }
}
