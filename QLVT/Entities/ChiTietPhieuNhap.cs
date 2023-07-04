using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.Entities
{
    public class ChiTietPhieuNhap
    {
        public int ChiTietPhieuNhapID { get; set; }
        public int VatTuID { get; set; }
        public VatTu VatTu { get; set; }    
        public int PhieuNhapID { get; set; }
        public PhieuNhap PhieuNhap { get; set; }
        [Required]
        public int SoLuongNhap { get; set; }

    }
}
