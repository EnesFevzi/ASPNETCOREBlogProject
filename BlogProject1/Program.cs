using BlogProject1.BusinessLayer.Abstract;
using BlogProject1.BusinessLayer.Concrete;
using BlogProject1.BusinessLayer.Extensions;
using BlogProject1.BusinessLayer.ValidationRules;
using BlogProject1.DataAccessLayer.Abstract;
using BlogProject1.DataAccessLayer.Concrete;
using BlogProject1.DataAccessLayer.Concrete.EntityFramework;
using BlogProject1.DataAccessLayer.Extensions;
using BlogProject1.EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<TContext>();
builder.Services.AddIdentity<WriterUser, WriterRole>(x =>
{
    x.Password.RequireUppercase = false;
    x.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<TContext>().AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<UserManager<WriterUser>>();
builder.Services.AddScoped<RoleManager<WriterRole>>();

builder.Services.AddAuthorization();
builder.Services.LoadDataLayerExtension();
builder.Services.LoadServiceLayerExtension();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSession();

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));

});

builder.Services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index";
                }
            );



builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.AccessDeniedPath = "/ErrorPage/Index";
    options.LoginPath = "/Login/Index/";
    options.LogoutPath = "/Login/Logout";
    options.SlidingExpiration = true;

});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Writer", policy =>
    {
        policy.RequireRole("Writer");
    });
});




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
app.UseAuthentication();
app.UseSession();
app.UseRouting();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
   );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Blog}/{action=Index}/{id?}"
        );

});

//app.UseEndpoints(endpoints =>
//{

//});

app.Run();
