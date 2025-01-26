namespace NuGetPackageReport.Lib.OutputModels;

public record Package(string Id, IList<Project> Projects);