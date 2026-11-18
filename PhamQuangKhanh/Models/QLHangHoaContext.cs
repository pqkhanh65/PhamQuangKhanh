using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PhamQuangKhanh.Models;

public partial class QLHangHoaContext : DbContext
{
    public QLHangHoaContext(DbContextOptions<QLHangHoaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HangHoa> HangHoas { get; set; }

    public virtual DbSet<LoaiHang> LoaiHangs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HangHoa>(entity =>
        {
            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.HangHoas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HangHoa_LoaiHang");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
