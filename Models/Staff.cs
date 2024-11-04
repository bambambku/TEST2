using System;
using System.Collections.Generic;

namespace TEST2.Models;

public partial class Staff
{
    public int Id { get; set; }

    public int Branch { get; set; }

    public int Role { get; set; }

    public string FName { get; set; } = null!;

    public string? MName { get; set; }

    public string LName { get; set; } = null!;

    public string Nin { get; set; } = null!;

    public string Bank { get; set; } = null!;

    public string SortCode { get; set; } = null!;

    public string BabnkAccount { get; set; } = null!;

    public virtual Branch BranchNavigation { get; set; } = null!;

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual Role RoleNavigation { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
