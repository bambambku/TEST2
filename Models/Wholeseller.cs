using System;
using System.Collections.Generic;

namespace TEST2.Models;

public partial class Wholeseller
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PostCode { get; set; } = null!;

    public string Town { get; set; } = null!;

    public string Bank { get; set; } = null!;

    public string SortCode { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
