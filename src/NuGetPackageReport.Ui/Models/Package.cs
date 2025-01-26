namespace NuGetPackageReport.Ui.Models;

public record Package(string Id, IList<Project> Projects);