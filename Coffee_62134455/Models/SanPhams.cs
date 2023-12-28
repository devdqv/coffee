namespace Coffee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SanPhams
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPhams()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHangs>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string TenSanPham { get; set; }

        public decimal Gia { get; set; }

        public string MoTa { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        [StringLength(255)]
        public string Size { get; set; }

        [StringLength(1000)]
        public string GhiChu { get; set; }

        public int? id_danhmuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHangs> ChiTietDonHangs { get; set; }

        public virtual DanhMucs DanhMucs { get; set; }
    }
}
