using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using System.Configuration;
namespace DAL.Data
{
    internal class MFSContext : DbContext
    {
        public DbSet<UniquePersons> uniquePersons { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MFSDatabase"].ConnectionString;
            if(!string.IsNullOrEmpty(connectionString))
                options.UseSqlServer(connectionString);
        }
    }
}
