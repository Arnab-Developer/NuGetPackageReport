namespace NuGetPackageReport.Lib.InputModels;

public record RootObject(int Version, string Parameters, IEnumerable<Project> Projects);