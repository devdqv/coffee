namespace Coffee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TaiKhoans
    {
        public int id { get; set; }

        [StringLength(50)]
        [DisplayName("Tên người dùng")]
        public string TenNguoiDung { get; set; }

        [StringLength(50)]
        [DisplayName("Tên đăng nhập")]
        public string Username { get; set; }

        [StringLength(100)]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        [DisplayName("Vai trò")]
        public int? VaiTro { get; set; }

        public DateTime? NgayTao { get; set; }

        public bool? GioiTinh { get; set; }
    }
}
