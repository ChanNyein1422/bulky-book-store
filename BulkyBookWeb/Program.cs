using BulkyBookWeb.AuthServices;
using Data.Models;
using Infra.Helper;
using Infra.Helper.BookApiRequest;
using Infra.Helper.CategoryApiRequest;
using Infra.Helper.OrderApiRequest;
using Infra.Helper.UserApiRequest;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Server.HttpSys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();


builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation()
                 .AddJsonOptions(options =>
                 {
                     options.JsonSerializerOptions.PropertyNamingPolicy = null;
                 });

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("") });


builder.Services.AddHttpClient();
builder.Services.AddScoped<IUserApiRequest, UserApiRequest>();
builder.Services.AddScoped<IBookApiRequest, BookApiRequest>();
builder.Services.AddScoped<ICategoryApiRequest, CategoryApiRequest>();
builder.Services.AddScoped<IOrderApiRequest, OrderApiRequest>();
builder.Services.AddScoped<IAuth, Auth>();
builder.Services.Configure<HttpSysOptions>(options =>
{
    options.MaxRequestBodySize = 52428800; // 50 MB
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o => o.LoginPath = new PathString("/authentication"));

var app = builder.Build();

//var app = builder.Build();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
