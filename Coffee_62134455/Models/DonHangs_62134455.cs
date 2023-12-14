namespace Coffee_62134455.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DonHangs_62134455
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHangs_62134455()
        {
            ChiTietDonHangs_62134455 = new HashSet<ChiTietDonHangs_62134455>();
        }

        public int id { get; set; }

        public DateTime NgayDatHang { get; set; }

        [StringLength(1000)]
        public string TenKhachHang { get; set; }

        [Required]
        [StringLength(1000)]
        public string DiaChiNhanHang { get; set; }

        [Required]
        [StringLength(20)]
        public string SDT { get; set; }

        public int? TrangThai { get; set; }

        [StringLength(1000)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHangs_62134455> ChiTietDonHangs_62134455 { get; set; }
    }
}
