using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Coffee_62134455.Models.DtoEdit
{
    [NotMapped]
    public class DonHangsDtoEdit_62134455: DonHangs_62134455
    {
        public DonHangsDtoEdit_62134455()
        {
            ChiTietDonHangsDtoEdit_62134455 = new HashSet<ChiTietDonHangsDtoEdit_62134455>();
        }
        public virtual ICollection<ChiTietDonHangsDtoEdit_62134455> ChiTietDonHangsDtoEdit_62134455 { get; set; }
    }
}