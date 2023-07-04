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
            Console.WriteLine("Hay nhap hang moi!");
            ThemMoiPhieuNhap(new PhieuNhap());
        }
        private void UpDateSLN(int ctpID)
        {
           
            var vtN = dbContext.ChiTietPhieuNhap.FirstOrDefault(x => x.ChiTietPhieuNhapID == ctpID);
            var vt = dbContext.VatTu.FirstOrDefault(x => x.VatTuID == vtN.VatTuID);
            if (vtN != null)
            {
                vt.SoLuongTon += vtN.SoLuongNhap;
            }
        } 
        private void UpDateSLX(int ctpID)
        {
           
            var vtX = dbContext.ChiTietPhieuXuat.FirstOrDefault(x => x.ChiTietPhieuXuatID == ctpID);
            var vt = dbContext.VatTu.FirstOrDefault(x => x.VatTuID == vtX.VatTuID);
            if (vtX != null)
            {
                vt.SoLuongTon -= vtX.SoLuongXuat;
            }
        }
        public void ThemMoiPhieuNhap(PhieuNhap n)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (dbContext.PhieuNhap.Any(x => x.MaPhieu == n.MaPhieu))//kiem tra phieu nhap da ton tai 
                    {
                        Console.WriteLine("Phieu nhap " + Res.DaTonTai);
                        return;
                    }
                    dbContext.Add(n);
                    dbContext.SaveChanges();
                    ChiTietPhieuNhap ctn = new ChiTietPhieuNhap(inputType.ThemGT);//co phieu nhap -> tao chi tiet phieu nhap
                    ctn.PhieuNhapID = n.PhieuNhapID;
                    var vt = dbContext.VatTu.FirstOrDefault(x => x.VatTuID == ctn.VatTuID);//Kiem tra phieu nhap
                    if (vt != null)
                    {
                        dbContext.Add(ctn);
                        dbContext.SaveChanges();
                        UpDateSLN(ctn.ChiTietPhieuNhapID);
                        dbContext.Update(vt);
                        dbContext.SaveChanges();
                        Console.WriteLine(Res.ThanhCong);
                    }
                    else
                    {
                        Console.WriteLine(Res.ChuaTonTai + " Vat tu, ban can them vat tu vao danh sach Vat Tu!");
                        VatTu vatTu = new VatTu(inputType.ThemGT);//them vat tu moi
                        dbContext.Add(vatTu);
                        dbContext.SaveChanges();

                        ctn.VatTuID = vatTu.VatTuID;// them chi tiet nhap
                        dbContext.Add(ctn);
                        dbContext.SaveChanges();

                        UpDateSLN(ctn.ChiTietPhieuNhapID);// cap nhat so luong ton
                        dbContext.Update(vatTu);
                        dbContext.SaveChanges();
                        Console.WriteLine(Res.ThanhCong);
                    }
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }


        public void ThemMoiPhieuXuat(PhieuXuat px)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (dbContext.PhieuXuat.Any(x => x.MaPhieu == px.MaPhieu))//kiem tra phieu xuat da ton tai 
                    {
                        Console.WriteLine("Phieu xuat " + Res.DaTonTai);
                        return;
                    }
                    dbContext.Add(px);
                    dbContext.SaveChanges();
                    ChiTietPhieuXuat ctx = new ChiTietPhieuXuat(inputType.ThemGT);//co phieu xuat -> tao chi tiet phieu xuat
                    ctx.PhieuXuatID = px.PhieuXuatID;
                    var vt = dbContext.VatTu.FirstOrDefault(x => x.VatTuID == ctx.VatTuID);//Kiem tra phieu xuat

                    if (vt != null)
                    {
                        if(vt.SoLuongTon > ctx.SoLuongXuat)
                        {
                            dbContext.Add(ctx);
                            dbContext.SaveChanges();
                            UpDateSLX(ctx.ChiTietPhieuXuatID);
                            dbContext.Update(vt);
                            dbContext.SaveChanges();
                            Console.WriteLine(Res.ThanhCong);
                        }
                        else
                            Console.WriteLine(vt.TenVatTu + " " + Res.KhongDuHang);
                    }
                    else
                    {
                        dbContext.SaveChanges();
                        Console.WriteLine(Res.ChuaTonTai + " Vat tu, ban can them vat tu vao danh sach Vat Tu!");
                        VatTu vatTu = new VatTu(inputType.ThemGT);//them vat tu moi
                        dbContext.Add(vatTu);
                        dbContext.SaveChanges();
                        ctx.VatTuID = vatTu.VatTuID;// them chi tiet xuat
                        if(vatTu.SoLuongTon > ctx.SoLuongXuat)//sl xuat ra phai < sl ton
                        {
                            dbContext.Add(ctx);
                            dbContext.SaveChanges();
                            UpDateSLX(ctx.ChiTietPhieuXuatID);// cap nhat so luong ton
                            dbContext.Update(vatTu);
                            dbContext.SaveChanges();
                            Console.WriteLine(Res.ThanhCong);
                        }
                        else
                            Console.WriteLine(vt.TenVatTu + " " + Res.KhongDuHang);
                    }
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
    }
}
