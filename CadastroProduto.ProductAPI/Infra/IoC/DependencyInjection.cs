using CadastroProduto.ProductAPI.Infra.Context;
using CadastroProduto.ProductAPI.Infra.Repositories;
using CadastroProduto.ProductAPI.Infra.Repositories.Interface;
using CadastroProduto.ProductAPI.Services;
using CadastroProduto.ProductAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CadastroProduto.ProductAPI.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var mySqlConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ProductDbContext>(options =>
                            options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }

        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product.API", Version = "v1" });                
            });

            return services;
        }
    }
}
