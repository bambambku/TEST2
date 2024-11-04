using System;
using System.Collections.Generic;

namespace TEST2.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Price { get; set; } = null!;

    public string Weight { get; set; } = null!;

    public string Size { get; set; } = null!;

    public string Cpu { get; set; } = null!;

    public string Gpu { get; set; } = null!;

    public string Ram { get; set; } = null!;

    public string HardDrive { get; set; } = null!;

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
