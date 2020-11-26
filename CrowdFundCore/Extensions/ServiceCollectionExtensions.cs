using System;
using System.Collections.Generic;
using System.Text;
using CrowdFundCore.Data;
using CrowdFundCore.Services;
using CrowdFundCoreServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrowdFundCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCFServices(this IServiceCollection services)
        {
            services.AddDbContext<CFDBContext>(options => options.UseSqlServer(CFDBContext.connectionString));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IPackageService, PackageService>();
            //services.AddScoped<IFundingProjectService, FundingProjectService>();

        }
    }
}
