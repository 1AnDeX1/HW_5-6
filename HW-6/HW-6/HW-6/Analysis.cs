using System;
using System.Collections.Generic;

namespace HW_6;

public partial class Analysis
{
    public int AnId { get; set; }

    public string? AnName { get; set; }

    public double? AnCost { get; set; }

    public double? AnPrice { get; set; }

    public int AnGroup { get; set; }

    public virtual Group AnGroupNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
