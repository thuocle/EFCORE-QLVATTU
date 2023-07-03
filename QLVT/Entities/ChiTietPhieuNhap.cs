using System;
using System.Collections.Generic;
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

        public int SoLuongNhap { get; set; }

    }
}
