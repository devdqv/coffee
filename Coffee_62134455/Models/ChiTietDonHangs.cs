namespace Coffee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChiTietDonHangs
    {
        public int id { get; set; }

        public int SoLuong { get; set; }

        public decimal? DonGia { get; set; }

        [StringLength(10)]
        public string Size { get; set; }

        [StringLength(1000)]
        public string GhiChu { get; set; }

        public int? id_sanpham { get; set; }

        public int? id_donhang { get; set; }

        public virtual DonHangs DonHangs { get; set; }

        public virtual SanPhams SanPhams { get; set; }
    }
}
