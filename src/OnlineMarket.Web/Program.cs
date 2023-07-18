using Microsoft.AspNetCore.Http;
using OnlineMarket.Web.Configurations.LayerConfigurations;
using OnlineMarket.Web.Middlewares;
using System.Net;

//-> Services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddService();
builder.Services.AddWeb(builder.Configuration);

//-> Middlewares
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
    {
        context.HttpContext.Response.Redirect("accounts/login");
    }
});
app.UseMiddleware<TokenRedirectMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

//-> Map routes
app.MapAreaControllerRoute(
   name: "administrator",
   areaName: "Administrator",
   pattern: "administrator/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}");

//-> Run Application
app.Run();
