namespace NuGetPackageReport.Lib.InputModels;

public record Project(string Path, IEnumerable<Framework> Frameworks);