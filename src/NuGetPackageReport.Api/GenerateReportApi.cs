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
            var fileWithExtension = $"{nugetPackageJsonFileName}.json";
            var nugetPackageJsonLocation = Path.Combine("c:", "NuGetPackageJson", fileWithExtension);
            var json = await jsonReader.GetJsonAsync(nugetPackageJsonLocation, token);
            var output = generateReport.Generate(json);
            return output;
        });
    }
}