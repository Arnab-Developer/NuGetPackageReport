using NuGetPackageReport.Lib.Services;

namespace NuGetPackageReport.Api;

public static class GenerateReportApi
{
    public static void MapGenerateReportApi(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/generate-report",
            async (string nugetPackageJsonFileName,
            IJsonReader jsonReader,
            IGenerateReport generateReport,
            CancellationToken token) =>
        {
            var json = await jsonReader.GetJsonAsync(nugetPackageJsonFileName, token);
            var output = generateReport.Generate(json);
            return output;
        });
    }
}