using System;
using Channel_A_Doctor_MVC_App.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Channel_A_Doctor_MVC_App.Areas.Identity.IdentityHostingStartup))]
namespace Channel_A_Doctor_MVC_App.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Channel_A_Doctor_Identity_MVC_AppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Channel_A_Doctor_Identity_MVC_AppContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<Channel_A_Doctor_Identity_MVC_AppContext>();
            });
        }
    }
}