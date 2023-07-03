namespace QLVT.Entities
{
    public class VatTu
    {
        public int VatTuID { get; set; }
        public string TenVatTu { get; set; }
        public int SoLuongTon { get; set; }
        public IEnumerable<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }
        public IEnumerable<ChiTietPhieuXuat> ChiTietPhieuXuat { get; set; }
    }
}
