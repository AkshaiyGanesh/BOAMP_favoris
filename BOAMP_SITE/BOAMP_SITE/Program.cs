using BOAMP_SITE.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<FavorisDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("FavorisDatabase")));


// Add services to the container.
builder.Services.AddRazorPages();

// Configure DbContext with the connection string
builder.Services.AddDbContext<FavorisDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FavorisDatabase")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();