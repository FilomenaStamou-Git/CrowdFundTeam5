using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CrowdFundCore.Models;
using CrowdFundCore.Models;

namespace CrowdFundCore.Data
{
    public class CFDBContext:DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Funding> Fundings { get; set; }


        public readonly static string connectionString =
            "Server=tcp:katha-filomena.database.windows.net,1433;Initial Catalog=CrowdFundTeam5;Persist Security Info=False;User ID=katha;Password=2212962014AthFilo;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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
