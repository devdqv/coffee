using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Coffee_62134455.Models.DtoEdit
{
    [NotMapped]
    public partial class ChiTietDonHangsDtoEdit_62134455: ChiTietDonHangs_62134455
    {
        //Thuộc tính để biết khách hàng thay đổi gì trong giỏ hàng
        public string actionEdit { get; set; }

        public string TenSanPham { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }

    }
}