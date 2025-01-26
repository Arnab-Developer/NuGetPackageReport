using Microsoft.Extensions.Options;
using NuGetPackageReport.Ui.Models;

namespace NuGetPackageReport.Ui;

public class ReportApiClient(HttpClient httpClient, IOptionsMonitor<ApiOptions> optionsMonitor)
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ApiOptions _apiOptions = optionsMonitor.CurrentValue;

    public async Task<IEnumerable<Package>> GetReportAsync(
        string nugetPackageJsonLocation,
        CancellationToken token)
    {
        var requestUrl = $"{_apiOptions.Url}?nugetPackageJsonLocation={nugetPackageJsonLocation}";

        var packages = await _httpClient.GetFromJsonAsync<IEnumerable<Package>>(requestUrl, token)
            ?? throw new InvalidOperationException();

        return packages;
    }
}