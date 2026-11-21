using buoi12.Models;
using Microsoft.EntityFrameworkCore;

namespace buoi12.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<DongHo> DongHo { get; set; }
        public DbSet<ThuongHieu> ThuongHieu { get; set; }
        public DbSet<LoaiMay> LoaiMay { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DongHo>().ToTable("DongHo");
            modelBuilder.Entity<ThuongHieu>().ToTable("ThuongHieu");
            modelBuilder.Entity<LoaiMay>().ToTable("LoaiMay");

            modelBuilder.Entity<DongHo>()
                            .HasOne(d => d.ThuongHieu)
                            .WithMany(t => t.DongHos)
                            .HasForeignKey(d => d.MaTH)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DongHo>()
                            .HasOne(d => d.LoaiMay)
                            .WithMany(l => l.DongHos)
                            .HasForeignKey(d => d.MaLM)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
