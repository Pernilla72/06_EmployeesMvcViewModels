using _03_EmployeesMvc.Models;
using _03_EmployeesMvc.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Stöd för controllers och views
builder.Services.AddControllersWithViews();

// Hämta connection-strängen från AppSettings.json
var connString = builder.Configuration
    .GetConnectionString("DefaultConnection");

// Registrera Context-klassen för dependency injection
builder.Services.AddDbContext<ApplicationContext>
    (o => o.UseSqlServer(connString));

//builder.Services.AddSingleton<DataService>(); // DI
//builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<IDataService, DBDataService>();

var app = builder.Build();

// Stöd för att mappa HTTP-anrop till våra controllers
app.UseRouting();

// Stöd för Route-attribut på våra Action-metoder
app.UseEndpoints(c => c.MapControllers());

//
app.UseStaticFiles();

app.Run();