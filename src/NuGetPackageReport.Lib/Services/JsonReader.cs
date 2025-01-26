namespace NuGetPackageReport.Lib.Services;

public interface IJsonReader
{
    public Task<string> GetJsonAsync(string jsonFileName, CancellationToken token);
}

public class JsonReader : IJsonReader
{
    public async Task<string> GetJsonAsync(string jsonFileName, CancellationToken token)
    {
        var fileWithExtension = $"{jsonFileName}.json";
        var jsonLocation = Path.Combine("c:", "NuGetPackageJson", fileWithExtension);
        var jsonData = await File.ReadAllTextAsync(jsonLocation, token);
        return jsonData;
    }
}
