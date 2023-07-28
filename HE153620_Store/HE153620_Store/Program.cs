using HE153620_Store.Hubs;
using HE153620_Store.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<StoreManagerContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DBConnect")));


builder.Services.AddSession(opt => opt.IdleTimeout = TimeSpan.FromMinutes(5));

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapHub<CategoryHub>("/categoryHub");

app.MapRazorPages();

app.Run();