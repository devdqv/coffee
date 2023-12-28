using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Coffee.Models
{
    public partial class DbContextEntity : DbContext
    {
        public DbContextEntity()
            : base("name=DbContextEntity")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<ChiTietDonHangs> ChiTietDonHangs { get; set; }
        public virtual DbSet<DanhMucs> DanhMucs { get; set; }
        public virtual DbSet<DonHangs> DonHangs { get; set; }
        public virtual DbSet<SanPhams> SanPhams { get; set; }
        public virtual DbSet<TaiKhoans> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonHangs>()
                .Property(e => e.DonGia)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ChiTietDonHangs>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucs>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.DanhMucs)
                .HasForeignKey(e => e.id_danhmuc)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DonHangs>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithOptional(e => e.DonHangs)
                .HasForeignKey(e => e.id_donhang)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SanPhams>()
                .Property(e => e.Gia)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SanPhams>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithOptional(e => e.SanPhams)
                .HasForeignKey(e => e.id_sanpham)
                .WillCascadeOnDelete();
        }
    }
}
