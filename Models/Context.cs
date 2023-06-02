using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MuhtarlıkOtomasyon.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("workstation id=muhtarlikOtomasyon.mssql.somee.com;packet size=4096;user id=mrthcgl_SQLLogin_1;pwd=r9y58f159s;data source=muhtarlikOtomasyon.mssql.somee.com;persist security info=False;initial catalog=muhtarlikOtomasyon;TrustServerCertificate=True");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
    }
}
