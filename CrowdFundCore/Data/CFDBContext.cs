using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CrowdFundCore.Models;
using ProjectCF_Console.Models;

namespace ProjectCF_Console.Data
{
    public class CFDBContext:DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Funding> Fundings { get; set; }


        public readonly static string connectionString =
            "Server=tcp:ioanchri-server.database.windows.net,1433;" +
            "Initial Catalog=Team5DB;Persist Security Info=False;" +
            "User ID=ioanchri;Password=1234qwer!;" +
            "MultipleActiveResultSets=False;Encrypt=True;" +
            "TrustServerCertificate=False;Connection Timeout=30;";

        protected override void OnConfiguring
           (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public CFDBContext(DbContextOptions<CFDBContext> options)
              : base(options)
        { }
        public CFDBContext()
        { }
    }
}
