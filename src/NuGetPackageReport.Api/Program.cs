using NuGetPackageReport.Api;
using NuGetPackageReport.Lib.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IJsonReader, JsonReader>();
builder.Services.AddSingleton<IJsonSerializerOptionsGenerator, JsonSerializerOptionsGenerator>();
builder.Services.AddTransient<IGenerateReport, GenerateReport>();

var app = builder.Build();

app.MapGenerateReportApi();

app.Run();