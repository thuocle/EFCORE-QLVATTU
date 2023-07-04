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
            dbContext.Update(vt);
            dbContext.SaveChanges();
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
        private ChiTietPhieuNhap ThemChiTietNhap(PhieuNhap n)
        {
            ChiTietPhieuNhap ctn = new ChiTietPhieuNhap(inputType.ThemGT);//co phieu nhap -> tao chi tiet phieu nhap
            return ctn;
        }
        private ChiTietPhieuXuat ThemChiTietXuat(PhieuXuat n)
        {
            ChiTietPhieuXuat ctx = new ChiTietPhieuXuat(inputType.ThemGT);//co phieu xuat -> tao chi tiet phieu xuat
            return ctx;

        }
        private void checkSLXuat(VatTu vt, ChiTietPhieuXuat ctx )
        {
            if (vt.SoLuongTon > ctx.SoLuongXuat)
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

        private void CheckPhieuXuat(PhieuXuat px )
        {
            if (dbContext.PhieuXuat.Any(x => x.MaPhieu == px.MaPhieu))//kiem tra phieu xuat da ton tai 
            {
                Console.WriteLine("Phieu xuat " + Res.DaTonTai);
                return;
            }
            dbContext.Add(px);
            dbContext.SaveChanges();
        }
        private void CheckPhieuNhap(PhieuNhap n)
        {
            if (dbContext.PhieuNhap.Any(x => x.MaPhieu == n.MaPhieu))//kiem tra phieu nhap da ton tai 
            {
                Console.WriteLine("Phieu nhap " + Res.DaTonTai);
                return;
            }
            dbContext.Add(n);
            dbContext.SaveChanges();
        }
        private void ThemVatTuXuat(ChiTietPhieuXuat ctx)
        {
            VatTu vatTu = new VatTu(inputType.ThemGT);//them vat tu moi
            dbContext.Add(vatTu);
            dbContext.SaveChanges();
            ctx.VatTuID = vatTu.VatTuID;// them chi tiet xuat
            checkSLXuat(vatTu, ctx);
        }
        private void ThemVatTuNhap(ChiTietPhieuNhap ctn)
        {
            VatTu vatTu = new VatTu(inputType.ThemGT);//them vat tu moi
            dbContext.Add(vatTu);
            dbContext.SaveChanges();

            ctn.VatTuID = vatTu.VatTuID;// them chi tiet nhap
            dbContext.Add(ctn);
            dbContext.SaveChanges();

            UpDateSLN(ctn.ChiTietPhieuNhapID);// cap nhat so luong ton
            dbContext.Update(vatTu);
            dbContext.SaveChanges();
        }
        public VatTu getVatTuXuat(ChiTietPhieuXuat ctx)
        {
            return dbContext.VatTu.FirstOrDefault(x => x.VatTuID == ctx.VatTuID);
        }
        public VatTu getVatTuNhap(ChiTietPhieuNhap ctn)
        {
            return dbContext.VatTu.FirstOrDefault(x => x.VatTuID == ctn.VatTuID);
        }
        public ChiTietPhieuXuat getCTXuat(ChiTietPhieuXuat ctx)
        {
            return dbContext.ChiTietPhieuXuat.FirstOrDefault(x => x.ChiTietPhieuXuatID == ctx.ChiTietPhieuXuatID && x.VatTuID == ctx.VatTuID);
        } 
        public ChiTietPhieuNhap getCTNhap(ChiTietPhieuNhap ctn)
        {
            return dbContext.ChiTietPhieuNhap.FirstOrDefault(x => x.PhieuNhapID == ctn.PhieuNhapID && x.VatTuID == ctn.VatTuID);
        }
        public void ThemMoiPhieuNhap(PhieuNhap n)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    CheckPhieuNhap(n);
                    Console.WriteLine("Nhap so vat tu can Nhap Vao: ");
                    int so = int.Parse(Console.ReadLine());
                    for (int i = 0; i < so; i++)
                    {
                        var ctn = ThemChiTietNhap(n);//co phieu nhap -> tao chi tiet phieu nhap
                        ctn.PhieuNhapID = n.PhieuNhapID;
                        var vt = getCTNhap(ctn);
                        var vtn = getCTNhap(ctn);
                        if(vtn!= null)
                        {
                            Console.WriteLine("Da nhap vat tu nay trong phieu nhap nay! "+Res.DaTonTai);
                            so += 1;
                            continue;
                        }
                        else if(vt != null)
                        {
                            dbContext.Add(ctn);
                            dbContext.SaveChanges();
                            UpDateSLN(ctn.ChiTietPhieuNhapID);
                            
                            Console.WriteLine(Res.ThanhCong);
                        }
                        else
                        {
                            Console.WriteLine(Res.ChuaTonTai + " Vat tu, ban can them vat tu vao danh sach Vat Tu!");
                            ThemVatTuNhap(ctn);
                            Console.WriteLine(Res.ThanhCong);
                        }
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
                    CheckPhieuXuat(px);
                    Console.WriteLine("Nhap so vat tu can Xuat di: ");
                    int so = int.Parse(Console.ReadLine());
                    for (int i = 0; i < so; i++)
                    {
                        var ctx = ThemChiTietXuat(px);
                        ctx.PhieuXuatID = px.PhieuXuatID;
                        var vt = getVatTuXuat(ctx);//Kiem tra phieu xuat
                        var vtx = getCTXuat(ctx);
                        if (vtx != null)
                        {
                            Console.WriteLine("Da xuat vat tu nay trong phieu xuat nay! " + Res.DaTonTai);
                            so += 1;
                            continue;
                        }
                        if (vt != null)
                        {
                            checkSLXuat(vt, ctx);
                        }
                        else
                        {
                            dbContext.SaveChanges();
                            Console.WriteLine(Res.ChuaTonTai + " Vat tu, ban can them vat tu vao danh sach Vat Tu!");
                            ThemVatTuXuat(ctx);
                        }
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
