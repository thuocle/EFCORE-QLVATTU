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
            dbContext.Add(ctn); 
            dbContext.SaveChanges();
            Console.WriteLine(Res.ThanhCong);
        }


        public void ThemMoiPhieuXuat(PhieuXuat x)
        {
            throw new NotImplementedException();
        }
    }
}
