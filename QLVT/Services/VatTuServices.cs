using QLVT.Entities;
using QLVT.IServices;
using QLVT.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.Services
{
    public class VatTuServices : IVatTuServices
    {
        private readonly AppDbContext dbContext;

        public VatTuServices()
        {
            this.dbContext = new AppDbContext();
        }
        public void HienThiDanhSachVatTu()
        {
            var lstVT = dbContext.VatTu.ToList();
            foreach (var vt in lstVT)
            {
                var msg = vt.SoLuongTon == 0 ? "Het Hang" : "";
                Console.WriteLine($"{vt.TenVatTu} - SLTK {vt.SoLuongTon} - {msg}");
            }
        }

        public void HienThiDSVatTuCanNhap()
        {
            var lstVT = dbContext.VatTu.Where(x=>x.SoLuongTon == 0).ToList();
            foreach (var vt in lstVT)
            {
                Console.WriteLine($"{vt.TenVatTu} - {Res.HetHang}");
            }
        }
        private void UpDateSL(int vattuID)
        {
            var vt = dbContext.VatTu.FirstOrDefault(x => x.VatTuID == vattuID);
            var vtN = dbContext.ChiTietPhieuNhap.FirstOrDefault(x => x.VatTuID == vattuID);
            var vtX = dbContext.ChiTietPhieuXuat.FirstOrDefault(x => x.VatTuID == vattuID);
            if(vtN != null)
            {
                vt.SoLuongTon += vtN.SoLuongNhap;
            }
            else if(vtX != null)
            {
                vt.SoLuongTon += vtX.SoLuongXuat;
            }
        }
        public void ThemMoiPhieuNhap(PhieuNhap n)
        {
            if(dbContext.PhieuNhap.Any(x => x.MaPhieu == n.MaPhieu))
            {
                Console.WriteLine("Phieu nhap "+Res.DaTonTai);
                return;
            }
            dbContext.Add(n);
            dbContext.SaveChanges();
            ChiTietPhieuNhap ctn = new ChiTietPhieuNhap();
            ctn.PhieuNhapID = n.PhieuNhapID;
            var vt = dbContext.VatTu.FirstOrDefault(x => x.VatTuID == ctn.VatTuID);
            if (vt!=null)
            {
                dbContext.Add(ctn);
                dbContext.SaveChanges();
                UpDateSL(ctn.VatTuID);
                dbContext.Update(vt); 
                dbContext.SaveChanges();
                Console.WriteLine(Res.ThanhCong);
            }
            else
            {
                Console.WriteLine(Res.ChuaTonTai + " Vat tu, ban can them vat tu vao danh sach Vat Tu!");
                VatTu vatTu = new VatTu();
                vatTu.VatTuID = ctn.VatTuID;
                dbContext.Add(vatTu);
                dbContext.Add(ctn);
                dbContext.SaveChanges();
                UpDateSL(ctn.VatTuID);
                dbContext.Update(vatTu);
                dbContext.SaveChanges();
                Console.WriteLine(Res.ThanhCong);
            }


        }


        public void ThemMoiPhieuXuat(PhieuXuat x)
        {
            throw new NotImplementedException();
        }
    }
}
