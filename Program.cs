using _03_EmployeesMvc.Models;
using _03_EmployeesMvc.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// St�d f�r controllers och views
builder.Services.AddControllersWithViews();

// H�mta connection-str�ngen fr�n AppSettings.json
var connString = builder.Configuration
    .GetConnectionString("DefaultConnection");

// Registrera Context-klassen f�r dependency injection
builder.Services.AddDbContext<ApplicationContext>
    (o => o.UseSqlServer(connString));

//builder.Services.AddSingleton<DataService>(); // DI
//builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<IDataService, DBDataService>();

var app = builder.Build();

// St�d f�r att mappa HTTP-anrop till v�ra controllers
app.UseRouting();

// St�d f�r Route-attribut p� v�ra Action-metoder
app.UseEndpoints(c => c.MapControllers());

//
app.UseStaticFiles();

app.Run();