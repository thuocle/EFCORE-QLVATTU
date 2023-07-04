using QLVT.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public int SoLuongXuat { get; set; }
        public ChiTietPhieuXuat(inputType it)
        {
            if (it == inputType.ThemGT)
            {
                VatTuID = InputHelper.InputINT(Res.InputINT, Res.ErrINT);
                SoLuongXuat = InputHelper.InputINT(Res.InputINT, Res.ErrINT);
            }
        }
        public ChiTietPhieuXuat()
        {

        }
    }
}
