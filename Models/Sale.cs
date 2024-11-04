using System;
using System.Collections.Generic;

namespace TEST2.Models;

public partial class Sale
{
    public int Id { get; set; }

    public int Product { get; set; }

    public int Customer { get; set; }

    public int Staff { get; set; }

    public string TimeDate { get; set; } = null!;

    public string IsPaid { get; set; } = null!;

    public virtual Customer CustomerNavigation { get; set; } = null!;

    public virtual Product ProductNavigation { get; set; } = null!;

    public virtual Staff StaffNavigation { get; set; } = null!;
}
