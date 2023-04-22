using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RCBCurrencyAnalyser.ORM;

public partial class CurrenciesContext : DbContext
{
    public CurrenciesContext()
    {
    }

    public CurrenciesContext(DbContextOptions<CurrenciesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<CurrencyDatum> CurrencyData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=currencies;Username=postgres;Password=1985postgres1989");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Currencies_pkey");
        });

        modelBuilder.Entity<CurrencyDatum>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Currency).WithMany()
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CurrencyId_Currencies_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
