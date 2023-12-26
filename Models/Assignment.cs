using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace looool.Models;

public partial class Assignment
{
    public int TaskId { get; set; }

    public string? TaskName { get; set; }
    [JsonIgnore] 
    public virtual Project? Project { get; set; }

    public int TaskNavigationCustomerId { get; set; }

    public int ExecutorId { get; set; }
}
