using System;
using System.Collections.Generic;

namespace TEST2.Models;

public partial class Branch
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PostCode { get; set; } = null!;

    public string Town { get; set; } = null!;

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual Stock? Stock { get; set; }
}
