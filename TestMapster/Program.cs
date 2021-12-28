using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using TestMapster.Dtos.Dtos;
using TestMapster.Dtos.Mappers;
using TestMapster.Library.Models;

Console.WriteLine("Hello, World!");

var Configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + "\\appsettings.json", optional: true, reloadOnChange: true)
       .AddEnvironmentVariables()
       .Build();

Log.Logger = new LoggerConfiguration()
           .ReadFrom.Configuration(Configuration)
           .Enrich.FromLogContext()
           .CreateLogger();

var builder = new HostBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddSingleton<IFooService, FooService>();
        services.AddSingleton<ISubjectMapper, TestMapster.Dtos.Mappers.SubjectMapper>();
        services.AddSingleton<IStudentMapper, TestMapster.Dtos.Mappers.StudentMapper>();

        services.AddLogging(config =>
        {
            config.ClearProviders();
            config.AddProvider(new SerilogLoggerProvider(Log.Logger));
            var minimumLevel = Configuration.GetSection("Serilog:MinimumLevel")?.Value;
            if (!string.IsNullOrEmpty(minimumLevel))
            {
                config.SetMinimumLevel(Enum.Parse<LogLevel>(minimumLevel));
            }
        });
    })
    .UseConsoleLifetime();

var app = builder.Build();

await app.StartAsync();

// https://github.com/MapsterMapper/Mapster

#region Basic usage using reflexion and expression

var source = new Source {Prop1 = "1", Prop2 = "2"};

// Mapping to a new object
var destObject = source.Adapt<SourceDto>();

Log.Debug($"{destObject.Prop1} {destObject.Prop2}");

// Mapping to an existing object
var existingDto = new SourceDto { Prop1 = "3", Prop2 = "4"};
source.Adapt(existingDto);

Log.Debug($"{existingDto.Prop1} {existingDto.Prop2}");

#endregion

#region Basic usage using generated code with Mapster.Tool

var author = new Author { Firstname = "Philippe", Lastname = "Laval" };
var authorDto = author.AdaptToDto();

var authorDto2 = new AuthorDto { Firstname = "xx", Lastname = "xx" };

author.AdaptTo(authorDto2);


#endregion

#region Basic usage using ISubjectMapper generated code with Mapster.Tool

IServiceProvider services = app.Services;
using (var scope = services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    ISubjectMapper? subjectMapper = serviceProvider.GetService<ISubjectMapper>();
    if (subjectMapper != null)
    {
        var subject = new Subject { Name = "Mapster" };
        var subjectDto = subjectMapper.Map(subject);

        Log.Debug($"{subject.Name} {subjectDto.Name}");

        var subjectDto2 = new SubjectDto { Name = "xx" };
        subjectMapper.Map(subject, subjectDto2);
    }

}

#endregion

await app.StopAsync();


// How to generate the DTO and mapping :
// C:\Users\philippe\source\repos\Philippe-Laval\TestMapster\TestMapster.Dto\MyRegister.cs

// dotnet tool install -g Mapster.Tool
// See entries in csproj file
// dotnet msbuild -t:Mapster
// dotnet msbuild -t:CleanGenerated

// https://github.com/RdJNL/TextTemplatingCore*/

// Mono.TextTemplating is an open-source implementation of the T4 text templating engine, a simple general-purpose way to use C# to generate any kind of text files.
// https://github.com/mono/t4

// https://medium.com/swlh/build-a-command-line-interface-cli-program-with-net-core-428c4c85221


