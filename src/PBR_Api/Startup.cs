using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft;
using PBR.Core.Configuration;
using PBR.Infrastructure.Data;
using PBR.Core.Repositories.Base;
using PBR.Infrastructure.Repository.Base;
using PBR.Core.Repositories;
using PBR.Infrastructure.Repository;
using PBR.Core.Interfaces;
using PBR.Infrastructure.Logging;
using AutoMapper;
using PBR.Application.Services;
using PBR.Core.Entities;

namespace PBR_Api
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
            // Add Core Layer
            services.Configure<Settings>(Configuration);

            // Add Infrastructure Layer
            ConfigureDatabases(services);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPowerBiAccountRepository, PowerBiAccountRepository>();
            services.AddScoped<IPowerBiApplicationDepartmentRepository, PowerBiApplicationDepartmentRepository>();
            services.AddScoped<IPowerBiApplicationAccountRepository, PowerBiApplicationAccountRepository>();
            services.AddScoped<IPowerBiApplicationRepository, PowerBiApplicationRepository>();
            services.AddScoped<IPowerBiDepartmentRepository, PowerBiDepartmentRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            // Add Application Layer
            services.AddScoped<PBR.Application.Interfaces.IProductService, ProductService>();
            services.AddScoped<PBR.Application.Interfaces.ICategoryService, CategoryService>();
            services.AddScoped<PBR.Application.Interfaces.IPowerBiAccountService, PowerBiAccountService>();
            services.AddScoped<PBR.Application.Interfaces.IPowerBiApplicationAccountService, PowerBiApplicationAccountService>();
            services.AddScoped<PBR.Application.Interfaces.IPowerBiApplicationDepartmentService,PowerBiApplicationDepartmentService>();

            // Add Web Layer
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper
            //services.AddScoped<IIndexPageService, IndexPageService>();
            //services.AddScoped<IProductService, ProductPageService>();
            //services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<PBR.PBR_Api.Interfaces.IPowerBiAccountService, PBR.PBR_Api.Services.PowerBiAccountService>();
            services.AddScoped<PBR.PBR_Api.Interfaces.IPowerBiApplicationAccountService, PBR.PBR_Api.Services.PowerBiApplicationAccountService>();
            services.AddScoped<PBR.PBR_Api.Interfaces.IPowerBiApplicationDepartmentService, PBR.PBR_Api.Services.PowerBiApplicationDepartmentService>();
//            Add Miscellaneous
            services.AddHttpContextAccessor();
            services.AddControllers().AddNewtonsoftJson();
            services.AddControllers();
            services.AddCors();

            //services.AddDbContext<PBRContext>(Option => 
            //Option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddScoped<IPBR_Repo,PBR_Repo>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }
        private void ConfigureDatabases(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(c =>
                          c.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
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
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });
        }
    }
}
