using System.Text.Json.Serialization;

namespace NuGetPackageReport.Lib.InputModels;

public record Framework(IEnumerable<TopLevelPackage> TopLevelPackages)
{
    [JsonPropertyName("framework")]
    public required string Name { get; set; }
}