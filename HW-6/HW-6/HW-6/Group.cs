using System;
using System.Collections.Generic;

namespace HW_6;

public partial class Group
{
    public int GrId { get; set; }

    public string? GrName { get; set; }

    public string? GrTemp { get; set; }

    public virtual ICollection<Analysis> Analyses { get; set; } = new List<Analysis>();
}
