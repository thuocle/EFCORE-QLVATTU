using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.Entities
{
    public class PhieuXuat
    {
        public int PhieuXuatID { get; set; }
        public int MaPhieu { get; set; }
        public string TieuDe { get; set; }
        public DateTime NgayNhap { get; set; }
        public IEnumerable<ChiTietPhieuXuat> ChiTietPhieuXuat { get; set; }
    }
}
