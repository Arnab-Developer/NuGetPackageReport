namespace NuGetPackageReport.Lib.OutputModels;

public record Project(
    string Name,
    string Framework,
    string RequestedVersion,
    string ResolvedVersion);