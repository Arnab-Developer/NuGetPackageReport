using Microsoft.AspNetCore.Mvc;

namespace NuGetPackageReport.Ui.Controllers;

public class ReportController(ReportApiClient reportApiClient) : Controller
{
    private readonly ReportApiClient _reportApiClient = reportApiClient;

    public IActionResult Index() => View();

    [HttpPost]
    public async Task<IActionResult> GenerateReport(
        string nugetPackageJsonLocation,
        CancellationToken token)
    {
        var packages = await _reportApiClient.GetReportAsync(nugetPackageJsonLocation, token);
        return View(packages);
    }
}