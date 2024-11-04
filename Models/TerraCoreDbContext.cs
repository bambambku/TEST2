using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TEST2.Models;

public partial class TerraCoreDbContext : DbContext
{
    public TerraCoreDbContext()
    {
    }

    public TerraCoreDbContext(DbContextOptions<TerraCoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Wholeseller> Wholesellers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Data/Terra_Core_DB.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.ToTable("Branch");

            entity.HasIndex(e => e.Id, "IX_Branch_ID").IsUnique();

            entity.HasIndex(e => e.Name, "IX_Branch_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PostCode).HasColumnName("post_code");
            entity.Property(e => e.Town).HasColumnName("town");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.HasIndex(e => e.AccountNumber, "IX_Customer_account_number").IsUnique();

            entity.HasIndex(e => e.Id, "IX_Customer_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountNumber).HasColumnName("account_number");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Bank).HasColumnName("bank");
            entity.Property(e => e.FName).HasColumnName("f_name");
            entity.Property(e => e.LName).HasColumnName("l_name");
            entity.Property(e => e.MName).HasColumnName("m_name");
            entity.Property(e => e.PostCode).HasColumnName("post_code");
            entity.Property(e => e.SortCode).HasColumnName("sort_code");
            entity.Property(e => e.Town).HasColumnName("town");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.Id, "IX_Product_ID").IsUnique();

            entity.HasIndex(e => e.Name, "IX_Product_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cpu).HasColumnName("CPU");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Gpu).HasColumnName("GPU");
            entity.Property(e => e.HardDrive).HasColumnName("hard_drive");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Ram).HasColumnName("RAM");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.ToTable("Purchase");

            entity.HasIndex(e => e.Id, "IX_Purchase_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsPaid).HasColumnName("is_paid");
            entity.Property(e => e.Product).HasColumnName("product");
            entity.Property(e => e.SerialNo).HasColumnName("serial_no");
            entity.Property(e => e.Staff).HasColumnName("staff");
            entity.Property(e => e.TimeDate).HasColumnName("time_date");
            entity.Property(e => e.Wholeseller).HasColumnName("wholeseller");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.Product)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.StaffNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.Staff)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.WholesellerNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.Wholeseller)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.HasIndex(e => e.Id, "IX_Role_ID").IsUnique();

            entity.HasIndex(e => e.Name, "IX_Role_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("Sale");

            entity.HasIndex(e => e.Id, "IX_Sale_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Customer).HasColumnName("customer");
            entity.Property(e => e.IsPaid).HasColumnName("is_paid");
            entity.Property(e => e.Product).HasColumnName("product");
            entity.Property(e => e.Staff).HasColumnName("staff");
            entity.Property(e => e.TimeDate).HasColumnName("time_date");

            entity.HasOne(d => d.CustomerNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Customer)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Product)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.StaffNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Staff)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasIndex(e => e.BabnkAccount, "IX_Staff_babnk_account").IsUnique();

            entity.HasIndex(e => e.Id, "IX_Staff_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BabnkAccount).HasColumnName("babnk_account");
            entity.Property(e => e.Bank).HasColumnName("bank");
            entity.Property(e => e.Branch).HasColumnName("branch");
            entity.Property(e => e.FName).HasColumnName("f_name");
            entity.Property(e => e.LName).HasColumnName("l_name");
            entity.Property(e => e.MName).HasColumnName("m_name");
            entity.Property(e => e.Nin).HasColumnName("NIN");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.SortCode).HasColumnName("sort_code");

            entity.HasOne(d => d.BranchNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.Branch)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.Branch);

            entity.ToTable("Stock");

            entity.HasIndex(e => e.Branch, "IX_Stock_branch").IsUnique();

            entity.Property(e => e.Branch)
                .ValueGeneratedOnAdd()
                .HasColumnName("branch");
            entity.Property(e => e.Product).HasColumnName("product");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.BranchNavigation).WithOne(p => p.Stock)
                .HasForeignKey<Stock>(d => d.Branch)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.Product)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Wholeseller>(entity =>
        {
            entity.ToTable("Wholeseller");

            entity.HasIndex(e => e.AccountNumber, "IX_Wholeseller_account_number").IsUnique();

            entity.HasIndex(e => e.Id, "IX_Wholeseller_ID").IsUnique();

            entity.HasIndex(e => e.Name, "IX_Wholeseller_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountNumber).HasColumnName("account_number");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Bank).HasColumnName("bank");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PostCode).HasColumnName("post_code");
            entity.Property(e => e.SortCode).HasColumnName("sort_code");
            entity.Property(e => e.Town).HasColumnName("town");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
