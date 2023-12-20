using System;
using System.Collections.Generic;

namespace looool.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public int? Price { get; set; }

    public string? Status { get; set; }

    public int? TaskId { get; set; }

    public DateOnly? PeriodOfExecution { get; set; }

    public virtual Assignment Project1 { get; set; } = null!;

    public virtual Executor ProjectNavigation { get; set; } = null!;
}
