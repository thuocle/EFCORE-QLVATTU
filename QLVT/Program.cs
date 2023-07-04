using QLVT.IServices;
using QLVT.Services;
using QLVT.Entities;
using QLVT.Helper;

void Main()
{
    IVatTuServices vatTuServices = new VatTuServices();
    vatTuServices.HienThiDanhSachVatTu();
    /*vatTuServices.HienThiDSVatTuCanNhap();*/
    vatTuServices.ThemMoiPhieuNhap(new PhieuNhap());
    /*vatTuServices.ThemMoiPhieuXuat(new PhieuXuat());*/
}
Main();
