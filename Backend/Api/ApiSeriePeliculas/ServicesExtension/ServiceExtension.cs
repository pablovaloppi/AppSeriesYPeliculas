using ApiSeriePeliculas.Core.Services;
using Contracts;
using Entities.Models;
using LoggerServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System.Text;

namespace ApiSeriePeliculas.ServicesExtension
{
    public static class ServiceExtension {

        public static void ConfigureCors( this IServiceCollection services ) {
            services.AddCors( options => {
                options.AddPolicy( "CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-Pagination"));
            } );
        }

        public static void ConfigureLoggerService( this IServiceCollection services ) {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
        public static void ConfigureIISIntegration( this IServiceCollection services ) {
            services.Configure<IISOptions>( options => { } ); // al dejar las llaves vacias queda como predeterminado las options
        }
        public static void ConfigureSqlServer( this IServiceCollection services, IConfiguration configuration ) {
            services.AddSqlServer<SitioSeriesConctext>( configuration.GetConnectionString( "SitioSeriesConection" ) );
        }

        public static void ConfigureDbContext( this IServiceCollection services, IConfiguration configuration ) {
            services.AddDbContext<SitioSeriesConctext>( opciones => {
                opciones.UseSqlServer( configuration.GetConnectionString( "SitioSeriesConection" ));
            } );
        }
        public static void ConfigureRepositoryWrapper( this IServiceCollection services ) {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureJWT( this IServiceCollection services, IConfiguration configuration ) {
            services.AddAuthentication( JwtBearerDefaults.AuthenticationScheme ).AddJwtBearer( options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.GetSection( "Jwt:Issuer" ).Value,
                    ValidAudience = configuration.GetSection( "Jwt:Audience" ).Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( configuration.GetSection( "Jwt:Key" ).Value) )
                };
            } );

            services.AddMvc();
        }

        public static void ConfigureFormOptions( this IServiceCollection services ) {
            services.Configure<FormOptions>( o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            } );
        }

        public static void ConfigureCoreServices(this IServiceCollection service ) {
            service.AddScoped<SerieFavoritaService>();
        }
    }
}
