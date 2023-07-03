using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.Entities
{
    public class PhieuNhap
    {
        public int PhieuNhapID { get; set; }
        public int MaPhieu { get; set; }
        public string TieuDe { get; set; }
        public DateTime NgayNhap { get; set; }
        public IEnumerable<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }
    }
}
