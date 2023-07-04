using QLVT.Helper;
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

        public ChiTietPhieuNhap(inputType it)
        {
            if(it == inputType.ThemGT)
            {
                VatTuID = InputHelper.InputINT(Res.InputINT, Res.ErrINT);
                SoLuongNhap = InputHelper.InputINT(Res.InputINT, Res.ErrINT);
            }
        }
        public ChiTietPhieuNhap()
        {
            
        }
    }
}
