using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PresentationApp.Areas.Identity.Data;

[assembly: HostingStartup(typeof(PresentationApp.Areas.Identity.IdentityHostingStartup))]
namespace PresentationApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PresentationAppIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PresentationAppIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PresentationAppIdentityDbContext>();
            });
        }
    }
}