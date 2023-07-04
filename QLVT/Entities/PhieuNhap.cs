using QLVT.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.Entities
{
    public class PhieuNhap
    {
        public int PhieuNhapID { get; set; }
        [Required]
        public int MaPhieu { get; set; }
        public string TieuDe { get; set; }
        [Required]
        public DateTime NgayNhap { get; set; }
        public IEnumerable<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }
        public PhieuNhap()
        {
            MaPhieu = InputHelper.InputINT(Res.InputINT, Res.ErrINT);
            TieuDe = InputHelper.InputSTR(Res.InputSTR, Res.Err);
            NgayNhap = InputHelper.InputDT(Res.InputDT, Res.Err, new DateTime(2000, 1, 1), new DateTime(2023, 7, 3));
        }
    }
}
