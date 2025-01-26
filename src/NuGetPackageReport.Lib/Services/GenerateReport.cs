using NuGetPackageReport.Lib.InputModels;
using NuGetPackageReport.Lib.OutputModels;
using System.Text.Json;

namespace NuGetPackageReport.Lib.Services;

public interface IGenerateReport
{
    public IEnumerable<Package> Generate(string json);
}

public class GenerateReport(IJsonSerializerOptionsGenerator optionsGenerator) : IGenerateReport
{
    private readonly IJsonSerializerOptionsGenerator _optionsGenerator = optionsGenerator;

    public IEnumerable<Package> Generate(string json)
    {
        var options = _optionsGenerator.GetOptions();

        var inputModels = JsonSerializer.Deserialize<RootObject>(json, options)
            ?? throw new InvalidOperationException();

        var distinctpackageIds = inputModels.Projects
            .SelectMany(p => p.Frameworks)
            .Where(f => f.TopLevelPackages is not null)
            .SelectMany(f => f.TopLevelPackages)
            .Select(p => p.Id)
            .Distinct();

        var outputModels = new List<Package>();

        foreach (var packageId in distinctpackageIds)
        {
            var outputProjects = new List<OutputModels.Project>();
            var outputPackage = new Package(packageId, outputProjects);
            outputModels.Add(outputPackage);

            foreach (var inputProject in inputModels.Projects)
            {
                foreach (var inputFramework in inputProject.Frameworks)
                {
                    if (inputFramework.TopLevelPackages is null) continue;

                    foreach (var inputTopLevelPackage in inputFramework.TopLevelPackages)
                    {
                        if (inputTopLevelPackage.Id != packageId) continue;

                        var project = new OutputModels.Project(
                            Path.GetFileNameWithoutExtension(inputProject.Path),
                            inputFramework.Name,
                            inputTopLevelPackage.RequestedVersion,
                            inputTopLevelPackage.ResolvedVersion);

                        outputPackage.Projects.Add(project);
                    }
                }
            }
        }

        return outputModels.OrderBy(o => o.Id);
    }
}