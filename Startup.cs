using EL_KooD_API.Data.Context;
using EL_KooD_API.Infrastructure.Contracts;
using EL_KooD_API.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EL_KooD_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.UseNetTopologySuite()));
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IMain_BranchRepository, Main_BranchRepository>();
            services.AddScoped<IManufacturing_ProcessRepository, Manufacturing_ProcessRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISecondary_BranchRepository, Secondary_BranchRepository>();
            services.AddScoped<ISupply_ProcessRepository, Supply_ProcessRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EL_KooD API - V1");
                });
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
