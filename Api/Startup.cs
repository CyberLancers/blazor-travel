using System;
using System.Configuration;
using BlazorAssemblyTravel.Api.Data;
using BlazorAssemblyTravel.Api.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(BlazorAssemblyTravel.Api.Startup))]
namespace BlazorAssemblyTravel.Api;
public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var configuration = builder.GetContext().Configuration;
        
        builder.Services.AddDbContext<CruisePriceWatchContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CruisePriceWatchContext")));
        
        builder.Services.AddScoped<ICruiseService, CruiseService>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}