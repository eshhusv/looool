using System;
using System.Collections.Generic;

namespace looool.Models;

public partial class Assignment
{
    public int TaskId { get; set; }

    public string? TaskName { get; set; }

    public virtual Project? Project { get; set; }

    public virtual Customer TaskNavigation { get; set; } = null!;
}
