namespace NuGetPackageReport.Lib.Services;

public interface IJsonReader
{
    public Task<string> GetJsonAsync(string jsonLocation, CancellationToken token);
}

public class JsonReader : IJsonReader
{
    public async Task<string> GetJsonAsync(string jsonLocation, CancellationToken token)
    {
        var jsonData = await File.ReadAllTextAsync(jsonLocation, token);
        return jsonData;
    }
}
