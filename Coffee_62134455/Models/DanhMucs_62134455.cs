namespace Coffee_62134455.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DanhMucs_62134455
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucs_62134455()
        {
            SanPhams_62134455 = new HashSet<SanPhams_62134455>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string TenDanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPhams_62134455> SanPhams_62134455 { get; set; }
    }
}
