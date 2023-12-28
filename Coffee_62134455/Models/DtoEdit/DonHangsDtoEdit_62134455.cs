using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Coffee.Models.DtoEdit
{
    [NotMapped]
    public class DonHangsDtoEdit: DonHangs
    {
        public DonHangsDtoEdit()
        {
            ChiTietDonHangsDtoEdit = new HashSet<ChiTietDonHangsDtoEdit>();
        }
        public virtual ICollection<ChiTietDonHangsDtoEdit> ChiTietDonHangsDtoEdit { get; set; }
        public string GhiChuDonHang { get; set; }
    }
}