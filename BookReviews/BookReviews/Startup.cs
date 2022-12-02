#define SQLITE // enable a database provider with #define, disable with #undef
#undef  SQLSERVER
// MySQL is the default database provider

using System.Runtime.InteropServices;
using BookReviews.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookReviews
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            #if SQLSERVER
                services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(Configuration["ConnectionStrings:SQLServerConnection"]));
            #elif SQLITE
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlite(Configuration["ConnectionStrings:SQLiteConnection"]));
            #else
                services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseMySql(Configuration["ConnectionStrings:MySqlConnection"]));
            #endif

            services.AddTransient<IReviewRepository, ReviewRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedData.Seed(context);
        }
    }
}
