using System.Text.Json;

namespace NuGetPackageReport.Lib.Services;

public interface IJsonSerializerOptionsGenerator
{
    public JsonSerializerOptions GetOptions();
}

public class JsonSerializerOptionsGenerator : IJsonSerializerOptionsGenerator
{
    public JsonSerializerOptions GetOptions() =>
        new() { PropertyNameCaseInsensitive = true };
}
