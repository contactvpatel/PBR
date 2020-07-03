using AutoMapper;
using PBR.Application.Interfaces;
using PBR.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PBR.Core.Configuration;
using PBR.Core.Interfaces;
using PBR.Core.Repositories;
using PBR.Core.Repositories.Base;
using PBR.Infrastructure.Data;
using PBR.Infrastructure.Logging;
using PBR.Infrastructure.Repository;
using PBR.Infrastructure.Repository.Base;
using PBR.UI.Interfaces;
using PBR.UI.Services;
using CategoryService = PBR.UI.Services.CategoryService;
using ICategoryService = PBR.UI.Interfaces.ICategoryService;
using IProductService = PBR.UI.Interfaces.IProductService;

namespace PBR.UI
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
            ConfigureApplicationServices(services);
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
        }

        private void ConfigureApplicationServices(IServiceCollection services)
        {
            // Add Core Layer
            services.Configure<Settings>(Configuration);

            // Add Infrastructure Layer
            ConfigureDatabases(services);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            // Add Application Layer
            services.AddScoped<Application.Interfaces.IProductService, ProductService>();
            services.AddScoped<Application.Interfaces.ICategoryService, Application.Services.CategoryService>();

            // Add Web Layer
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper
            services.AddScoped<IIndexPageService, IndexPageService>();
            services.AddScoped<IProductService, ProductPageService>();
            services.AddScoped<ICategoryService, CategoryService>();

            // Add Miscellaneous
            services.AddHttpContextAccessor();
        }

        
        public void ConfigureDatabases(IServiceCollection services)
        {
            // use in-memory database
            //services.AddDbContext<DataContext>(c =>
            //    c.UseInMemoryDatabase("DatabaseConnection"));

            // use real database
            services.AddDbContext<DataContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
        }
    }
}
