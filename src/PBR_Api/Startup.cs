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
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IApplicationDepartmentRepository, ApplicationDepartmentRepository>();
            services.AddScoped<IApplicationAccountRepository, ApplicationAccountRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            // Add Application Layer
            services.AddScoped<PBR.Application.Interfaces.IProductService, ProductService>();
            services.AddScoped<PBR.Application.Interfaces.ICategoryService, CategoryService>();
            services.AddScoped<PBR.Application.Interfaces.IAccountService, AccountService>();
            services.AddScoped<PBR.Application.Interfaces.IApplicationAccountService, ApplicationAccountService>();
            services.AddScoped<PBR.Application.Interfaces.IApplicationDepartmentService,ApplicationDepartmentService>();

            // Add Web Layer
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper
            //services.AddScoped<IIndexPageService, IndexPageService>();
            //services.AddScoped<IProductService, ProductPageService>();
            //services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<PBR.PBR_Api.Interfaces.IAccountService, PBR.PBR_Api.Services.AccountService>();
            services.AddScoped<PBR.PBR_Api.Interfaces.IApplicationAccountService, PBR.PBR_Api.Services.ApplicationAccountService>();
            services.AddScoped<PBR.PBR_Api.Interfaces.IApplicationDepartmentService, PBR.PBR_Api.Services.ApplicationDepartmentService>();
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
