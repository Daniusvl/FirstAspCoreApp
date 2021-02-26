using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Terabaitas.Core;
using Terabaitas.Core.Domain;
using Terabaitas.Core.Services;
using Terabaitas.Core.Services.Abstract;
using Terabaitas.Data;
using Terabaitas.Data.Entities;
using Terabaitas.Data.Repositories;
using Terabaitas.Data.Repositories.Abstract;
using Terabaitas.Models;

namespace Terabaitas
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=TerabaitasDB;Integrated Security=True");
                options.UseInMemoryDatabase("_");
                options.EnableSensitiveDataLogging();
            });

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            
            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/User/Login";
            });

            services.AddSession();

            services.AddTransient<IShopItemService, ShopItemService>();
            services.AddTransient<ICartHelper, ShopItemService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderHelper, OrderService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();

            services.AddTransient<IEntityRepository<ShopItemEntity>, ShopItemRepository>();
            services.AddTransient<IEntityRepository<OrderEntity>, OrderRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
