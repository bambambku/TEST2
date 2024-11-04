using System;
using System.Collections.Generic;

namespace TEST2.Models;

public partial class Purchase
{
    public int Id { get; set; }

    public int Product { get; set; }

    public string SerialNo { get; set; } = null!;

    public int Wholeseller { get; set; }

    public int Staff { get; set; }

    public string TimeDate { get; set; } = null!;

    public string IsPaid { get; set; } = null!;

    public virtual Product ProductNavigation { get; set; } = null!;

    public virtual Staff StaffNavigation { get; set; } = null!;

    public virtual Wholeseller WholesellerNavigation { get; set; } = null!;
}
