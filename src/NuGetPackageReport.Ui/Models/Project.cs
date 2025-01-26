using System.ComponentModel;

namespace NuGetPackageReport.Ui.Models;

public record Project
{
    [DisplayName("Project Name")]
    public required string Name { get; set; }

    [DisplayName("Framework")]
    public required string Framework { get; set; }

    [DisplayName("Requested Version")]
    public required string RequestedVersion { get; set; }

    [DisplayName("Resolved Version")]
    public required string ResolvedVersion { get; set; }
}