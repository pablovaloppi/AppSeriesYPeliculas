

using ApiSeriePeliculas.ServicesExtension;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.FileProviders;
using NLog;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

//LogManager.LoadConfiguration( string.Concat( Directory.GetCurrentDirectory(), "./nlog.config" ) );
LogManager.Setup().LoadConfigurationFromFile( string.Concat( Directory.GetCurrentDirectory(), "./log.config" ));
// CORS
builder.Services.ConfigureCors();

// FormOptions
builder.Services.ConfigureFormOptions();

// ISS
builder.Services.ConfigureIISIntegration();

// DB Context
builder.Services.ConfigureSqlServer( builder.Configuration );

builder.Services.ConfigureDbContext( builder.Configuration );
// Automapper
builder.Services.AddAutoMapper( typeof( Program ) );

// Enlazo la Repository Wrapper
builder.Services.ConfigureRepositoryWrapper();

// Inyeccion de dependencia de los serivcios core (mios)
builder.Services.ConfigureCoreServices();

// Enlaza el logger manager
builder.Services.ConfigureLoggerService();

builder.Services.ConfigureJWT( builder.Configuration );

builder.Services.AddControllers();



var app = builder.Build();

// Configure the HTTP request pipeline.
if( app.Environment.IsDevelopment() )
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders( new ForwardedHeadersOptions {
    ForwardedHeaders = ForwardedHeaders.All
} );

app.UseCors( "CorsPolicy" );

app.UseStaticFiles();
app.UseStaticFiles( new StaticFileOptions() {
    FileProvider = new PhysicalFileProvider( Path.Combine( Directory.GetCurrentDirectory(), @"Resources" ) ),
    RequestPath = new PathString( "/Resources" )
} );


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
