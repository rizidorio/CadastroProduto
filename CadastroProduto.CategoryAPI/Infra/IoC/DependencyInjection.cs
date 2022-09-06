using CadastroProduto.CategoryAPI.Infra.Context;
using CadastroProduto.CategoryAPI.Infra.Repository;
using CadastroProduto.CategoryAPI.Infra.Repository.Interface;
using CadastroProduto.CategoryAPI.Services;
using CadastroProduto.CategoryAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CadastroProduto.CategoryAPI.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var mySqlConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CategoryDbContext>(options =>
                            options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }

        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Category.API", Version = "v1" });                
            });

            return services;
        }
    }
}
