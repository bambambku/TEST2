using System;
using System.Collections.Generic;

namespace TEST2.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string FName { get; set; } = null!;

    public string? MName { get; set; }

    public string LName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PostCode { get; set; } = null!;

    public string Town { get; set; } = null!;

    public string Bank { get; set; } = null!;

    public string SortCode { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
