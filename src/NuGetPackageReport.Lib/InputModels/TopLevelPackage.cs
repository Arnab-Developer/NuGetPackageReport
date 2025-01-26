namespace NuGetPackageReport.Lib.InputModels;

public record TopLevelPackage(string Id, string RequestedVersion, string ResolvedVersion);