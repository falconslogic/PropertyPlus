using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PropertyManagementApp.Areas.Identity.Data;
using PropertyManagementApp.Data;

[assembly: HostingStartup(typeof(PropertyManagementApp.Areas.Identity.IdentityHostingStartup))]
namespace PropertyManagementApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PropertyManagementAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PropertyManagementAppContextConnection")));

                services.AddDefaultIdentity<PropertyManagementAppUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<PropertyManagementAppContext>();
            });
        }
    }
}