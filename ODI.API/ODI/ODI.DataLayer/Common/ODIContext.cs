using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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




    }
}
