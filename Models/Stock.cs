using System;
using System.Collections.Generic;

namespace TEST2.Models;

public partial class Stock
{
    public int Branch { get; set; }

    public int Product { get; set; }

    public int Quantity { get; set; }

    public virtual Branch BranchNavigation { get; set; } = null!;

    public virtual Product ProductNavigation { get; set; } = null!;
}
