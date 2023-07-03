using QLVT.IServices;
using QLVT.Services;

void Main()
{
    IVatTuServices vatTuServices = new VatTuServices();
    vatTuServices.HienThiDanhSachVatTu();
}
Main();
