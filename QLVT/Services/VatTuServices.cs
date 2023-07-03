using QLVT.Entities;
using QLVT.IServices;
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
            throw new NotImplementedException();
        }

        public void ThemMoiPhieuNhap()
        {
            throw new NotImplementedException();
        }

        public void ThemMoiPhieuXuat()
        {
            throw new NotImplementedException();
        }
    }
}
