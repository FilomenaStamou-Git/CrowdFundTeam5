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
        //public DbSet<FundingPackage> FundingPackages { get; set; }
        //public DbSet<FundingProject> FundingProjects { get; set; }



        public readonly static string connectionString =
        "Server=tcp:danaikp.database.windows.net,1433;Initial Catalog=Team5FinalDB;Persist Security Info=False;User ID=dkape;Password=Zmt89950;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected override void OnConfiguring
           (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder
            //        .Entity<FundingPackage>()
            //        .HasKey(op => new
            //        {
            //            op.FundingProjectId,
            //            op.PackageId
            //        });

        }
            public CFDBContext(DbContextOptions<CFDBContext> options)
              : base(options)
        { }
        public CFDBContext()
        { }

    }
}
