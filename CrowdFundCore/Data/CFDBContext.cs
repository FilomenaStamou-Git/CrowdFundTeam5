﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CrowdFundCore.Models;

namespace CrowdFundCore.Data
{
    public class CFDBContext:DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<FundingProject> FundingProjects { get; set; }



        public readonly static string connectionString =
        //"Server=tcp:ioanchri-server.database.windows.net,1433;Initial Catalog=CrowdFundTeam5;Persist Security Info=False;User ID=ioanchri;Password=1234qwer!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        "Server=tcp:danaikp.database.windows.net,1433;Initial Catalog=Tm5;Persist Security Info=False;User ID=dkape;Password=Zmt89950;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected override void OnConfiguring
           (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
            public CFDBContext(DbContextOptions<CFDBContext> options)
              : base(options)
        { }
        public CFDBContext()
        { }

    }
}
