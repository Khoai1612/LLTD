using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LLTD.Models
{
    public class LLTDDbContext :DbContext
    {
        public LLTDDbContext() : base("LLTDDbContext")
        {
        }

        public DbSet<QLMonHoc> QLMonHocs { get; set; }
        public DbSet<QLLop> QLLops { get; set; }
        public DbSet<QLHocSinh> QLHocSinhs { get; set; }
        public DbSet<QLGiaoVien> QLGiaoViens { get; set; }
        public DbSet<DiemHocSinh> DiemHocSinhs { get; set; }
        
    }
}