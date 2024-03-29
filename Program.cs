using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication().AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt => { opt.ExpireTimeSpan = TimeSpan.FromMinutes(5); opt.SlidingExpiration = true; opt.Cookie.MaxAge = opt.ExpireTimeSpan; });

builder.Services.AddScoped<MvcApp1.Mssql.IExternalDataResolver>(
    _ =>
        new MvcApp1.Mssql.SqlServerDataResolver()
        {
            ConnectionString = builder.Configuration.GetConnectionString("SqlServerConnectionString")
        }
);

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
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

app.MapControllerRoute(name: "default", pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
