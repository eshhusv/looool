using System;
using System.Collections.Generic;

namespace looool.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public virtual Assignment? Task { get; set; }
}
