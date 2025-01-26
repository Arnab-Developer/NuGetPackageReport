using NuGetPackageReport.Ui;
using NuGetPackageReport.Ui.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ReportApiClient>();
builder.Services.AddOptions<ApiOptions>().BindConfiguration("ApiOptions");

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Report}/{action=Index}/{id?}");

app.Run();