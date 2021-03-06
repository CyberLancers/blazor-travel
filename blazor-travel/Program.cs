using Business.Data;
using Business.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContextFactory<CruisePriceWatchContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("CruisePriceWatchContext")));
        
builder.Services.AddScoped<ICruiseService, CruiseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseRequestLocalization("en-US");

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

