namespace Coffee_62134455.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SanPhams_62134455
    {
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

        public virtual DanhMucs_62134455 DanhMucs_62134455 { get; set; }
    }
}
