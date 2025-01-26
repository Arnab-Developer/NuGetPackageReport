namespace NuGetPackageReport.LibTest.Services;

public partial class GenerateReport_Test
{
    [Fact]
    public async Task Generate_WorkProperly_GivenValidInput()
    {
        _optionsGeneratorMock.Setup(o => o.GetOptions()).Returns(_options);

        var json = await File.ReadAllTextAsync("valid.json");
        var packages = _generateReport.Generate(json);

        _optionsGeneratorMock.Verify(o => o.GetOptions(), Times.Once());

        Assert.Single(packages);

        var package = packages.First();
        Assert.Equal("Asp.Versioning.Http", package.Id);
        Assert.Equal(2, package.Projects.Count);

        var firstProject = package.Projects.ElementAt(0);
        Assert.Equal("Api1", firstProject.Name);
        Assert.Equal("net8.0", firstProject.Framework);
        Assert.Equal("8.1.0", firstProject.RequestedVersion);
        Assert.Equal("8.1.0", firstProject.ResolvedVersion);

        var secondProject = package.Projects.ElementAt(1);
        Assert.Equal("Api2", secondProject.Name);
        Assert.Equal("net8.0", secondProject.Framework);
        Assert.Equal("8.1.0", secondProject.RequestedVersion);
        Assert.Equal("8.1.0", secondProject.ResolvedVersion);
    }

    [Fact]
    public async Task Generate_WorkProperly_GivenNullInput()
    {
        _optionsGeneratorMock.Setup(o => o.GetOptions()).Returns(_options);

        var json = await File.ReadAllTextAsync("null.json");
        var packages = _generateReport.Generate(json);

        _optionsGeneratorMock.Verify(o => o.GetOptions(), Times.Once());

        Assert.Single(packages);

        var package = packages.First();
        Assert.Equal("Asp.Versioning.Http", package.Id);
        Assert.Single(package.Projects);

        var firstProject = package.Projects.First();
        Assert.Equal("Api1", firstProject.Name);
        Assert.Equal("net8.0", firstProject.Framework);
        Assert.Equal("8.1.0", firstProject.RequestedVersion);
        Assert.Equal("8.1.0", firstProject.ResolvedVersion);
    }

    [Fact]
    public async Task Generate_SortProperly_GivenValidInput()
    {
        _optionsGeneratorMock.Setup(o => o.GetOptions()).Returns(_options);

        var json = await File.ReadAllTextAsync("order_by.json");
        var packages = _generateReport.Generate(json);

        _optionsGeneratorMock.Verify(o => o.GetOptions(), Times.Once());

        Assert.Equal(2, packages.Count());

        var firstPackage = packages.ElementAt(0);
        Assert.Equal("Asp.Versioning.Http", firstPackage.Id);
        Assert.Single(firstPackage.Projects);

        var firstProject = firstPackage.Projects.First();
        Assert.Equal("Api2", firstProject.Name);
        Assert.Equal("net8.0", firstProject.Framework);
        Assert.Equal("8.1.0", firstProject.RequestedVersion);
        Assert.Equal("8.1.0", firstProject.ResolvedVersion);

        var secondPackage = packages.ElementAt(1);
        Assert.Equal("System.Text.Json", secondPackage.Id);
        Assert.Single(secondPackage.Projects);

        firstProject = secondPackage.Projects.First();
        Assert.Equal("Api1", firstProject.Name);
        Assert.Equal("net8.0", firstProject.Framework);
        Assert.Equal("9.0.0", firstProject.RequestedVersion);
        Assert.Equal("9.0.0", firstProject.ResolvedVersion);
    }
}