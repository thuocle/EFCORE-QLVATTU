using QLVT.Entities;

namespace QLVT.IServices
{
    public interface IVatTuServices
    {
        //Hiển thị danh sách vật tư hiện đang có trong kho cùng số lượng tồn kho theo mẫu
        void HienThiDanhSachVatTu();
        //Hiển thị danh sách vật tư cần nhập thêm(Biết rằng khi vật tư "Hết hàng" sẽ cần nhập thêm hàng mới)
        void HienThiDSVatTuCanNhap();
        //Thêm mới phiếu nhập/xuất(Cần tự động cập nhật số lượng tồn kho của vật tư)
        void ThemMoiPhieuNhap(PhieuNhap n);
        void ThemMoiPhieuXuat(PhieuXuat px);
    }
}
