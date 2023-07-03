using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.Entities
{
    public class ChiTietPhieuXuat
    {
        public int ChiTietPhieuXuatID { get; set; }
        public int VatTuID { get; set; }
        public VatTu VatTu { get; set; }
        public int PhieuXuatID { get; set; }
        public PhieuXuat PhieuXuat { get; set; }

        public int SoLuongXuat { get; set; }
    }
}
