using NuGetPackageReport.Lib.Services;
using System.Text.Json;

namespace NuGetPackageReport.LibTest.Services;

public partial class GenerateReport_Test
{
    private readonly Mock<IJsonSerializerOptionsGenerator> _optionsGeneratorMock;
    private readonly GenerateReport _generateReport;
    private readonly JsonSerializerOptions _options;

    public GenerateReport_Test()
    {
        _optionsGeneratorMock = new Mock<IJsonSerializerOptionsGenerator>();
        _generateReport = new(_optionsGeneratorMock.Object);
        _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
    }
}