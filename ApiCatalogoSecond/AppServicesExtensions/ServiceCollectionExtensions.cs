using ApiCatalogoSecond.Data;
using ApiCatalogoSecond.Repositories.Interfaces;
using ApiCatalogoSecond.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AutoMapper;
using ApiCatalogoSecond.DTOs.Mappings;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

namespace ApiCatalogoSecond.AppServicesExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddApiServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddServices();
            return builder;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiCatalogo", Version = "v1" });
            });
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddDtoMapper();
            services.Configure<JsonOptions>(o =>
            {
                o.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            return services;
        }

        public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder, string ConnectionString)
        {
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(ConnectionString)
            );

            return builder;
        }

        private static IServiceCollection AddDtoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
