using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.Entities
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<VatTu> VatTu { get; set; }
        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhap { get; set; }
        public virtual DbSet<ChiTietPhieuXuat> ChiTietPhieuXuat { get; set; }
        public virtual DbSet<PhieuXuat> PhieuXuat { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server = THUOCLE\\THUOCLE; Database = QLVATTU; Trusted_Connection = True; " +
                $"TrustServerCertificate=True");
        }
    }
}
