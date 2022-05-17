using HealthPlus.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using System.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HealthPlus.Data;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HealthPlusUsersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HealthPlusUsersContext") ?? throw new InvalidOperationException("Connection string 'HealthPlusUsersContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
   name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "account",
    pattern: "{controller=Account}/{action=Account}/{id?}"
    );


app.Run();
