using System;
using System.Collections.Generic;

namespace looool.Models;

public partial class Executor
{
    public int executor_id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public virtual Project? Project { get; set; }
}
