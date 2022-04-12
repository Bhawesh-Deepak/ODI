using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ODI.DataLayer.Master;
using ODI.DataLayer.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODI.DataLayer.Common
{
    public class ODIContext : DbContext
    {
        private readonly string _connectionString;

        public ODIContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
        public ODIContext(IConfiguration configuration, string dbName)
        {
            _connectionString = configuration.GetSection($"ConnectionStrings:{dbName}").Value;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        public virtual DbSet<UserDetails> UserDetailss { get; set; }
        public virtual DbSet<Authenticate> Authenticates { get; set; }
        public virtual DbSet<CompanyMaster> CompanyMasters { get; set; }
        public virtual DbSet<ClaimHeadMaster> ClaimHeadMasters { get; set; }





    }
}
