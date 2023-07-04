using QLVT.Helper;

namespace QLVT.Entities
{
    public class VatTu
    {
        public int VatTuID { get; set; }
        public string TenVatTu { get; set; }
        public int SoLuongTon { get; set; }
        public IEnumerable<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }
        public IEnumerable<ChiTietPhieuXuat> ChiTietPhieuXuat { get; set; }
        public VatTu()
        {
            
        }
        public VatTu(inputType it)
        {
            if(it == inputType.ThemGT)
            {
                TenVatTu = InputHelper.InputSTR(Res.InputSTR, Res.Err);
            }
        }
    }
}
