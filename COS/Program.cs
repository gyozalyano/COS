using COS.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDinnerRepository, DinnerRepository>();


builder.Services.AddDbContext<CosDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:CosDbContextConnection"]);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapDefaultControllerRoute();

DbInitializer.Seed(app);

app.Run();