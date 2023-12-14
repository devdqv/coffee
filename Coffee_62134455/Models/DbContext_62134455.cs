using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Coffee_62134455.Models
{
    public partial class DbContext_62134455 : DbContext
    {
        public DbContext_62134455()
            : base("name=DbContext_62134455")
        {
        }

        public virtual DbSet<ChiTietDonHangs_62134455> ChiTietDonHangs_62134455 { get; set; }
        public virtual DbSet<DanhMucs_62134455> DanhMucs_62134455 { get; set; }
        public virtual DbSet<DonHangs_62134455> DonHangs_62134455 { get; set; }
        public virtual DbSet<SanPhams_62134455> SanPhams_62134455 { get; set; }
        public virtual DbSet<TaiKhoans_62134455> TaiKhoans_62134455 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMucs_62134455>()
                .Property(e => e.TenDanhMuc)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucs_62134455>()
                .HasMany(e => e.SanPhams_62134455)
                .WithOptional(e => e.DanhMucs_62134455)
                .HasForeignKey(e => e.id_danhmuc)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DonHangs_62134455>()
                .HasMany(e => e.ChiTietDonHangs_62134455)
                .WithOptional(e => e.DonHangs_62134455)
                .HasForeignKey(e => e.id_donhang)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SanPhams_62134455>()
                .Property(e => e.TenSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<SanPhams_62134455>()
                .Property(e => e.Gia)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SanPhams_62134455>()
                .Property(e => e.MoTa)
                .IsUnicode(false);
        }
    }
}
