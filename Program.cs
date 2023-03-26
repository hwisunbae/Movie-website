
using Vidly.Models;
using Vidly.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDBContext>(opts => opts.UseSqlServer("name=ConnectionString:Vidly"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();




// routes.MapMvcAttributeRoutes();
//app.MapControllerRoute(
//    name: "MoviesByReleaseDate",
//    pattern: "movies/released/{year}/{month}",
//    new { controller = "Movies", action = "ByReleaseDate" },
//    new {year =@"2022|2023", month = @"\d{2}"});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
