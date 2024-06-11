using Local_Api.Auto_Migration;
using Local_Api.Data;
using Local_Api.Interface;
using Local_Api.Models;
using Local_Api.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();  //enabling cors 
    });
});

Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()  //serilog
            .CreateLogger();

builder.Host.UseSerilog(Log.Logger);

Log.Information("Getting the motors running...");
try
{

    builder.Services.AddControllers();
    builder.Services.AddScoped<IDistrictRepo, DistrictRepo>();
    builder.Services.AddScoped<IProvinceRepo, ProvinceRepo>();
    builder.Services.AddScoped<IMunicipalityRepo, MunicipalityRepo>();
    builder.Services.AddScoped<IZoneRepo, ZoneRepo>();
    builder.Services.AddScoped<IOldDistrictRepo, OldDistrictService>();
    builder.Services.AddScoped<IOldMunicipalityRepo, OldMunicipalityRepo>();
    builder.Services.AddScoped<IDatabaseHelper, DatabaseHelperService>();

    builder.Services.AddScoped<IDbConnection>(c => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddDbContext<AppDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
       );



    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    app.UseCors("MyPolicy");

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        Auto_Mig.Initialize(dbContext);
    }

    //// Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    //{
        app.UseSwagger();
        app.UseSwaggerUI();
    //}

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

