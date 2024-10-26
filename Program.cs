using Microsoft.EntityFrameworkCore;
using Cargo.Data; // Burada kendi projenin adını kullan

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Session servisini ekleyin
builder.Services.AddSession(options => 
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session'ın ne kadar süreyle aktif olacağını belirleyin
    options.Cookie.HttpOnly = true; // Güvenlik amacıyla cookie'lerin HttpOnly olarak ayarlandığından emin olun
    options.Cookie.IsEssential = true; // GDPR için gerekli
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Session'ı etkinleştirin
app.UseSession();  // Bu satırı ekleyin

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
