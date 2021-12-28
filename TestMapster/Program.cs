// https://medium.com/swlh/build-a-command-line-interface-cli-program-with-net-core-428c4c85221

using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using TestMapster.Dtos;
using TestMapster.Models;

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

        //services.AddHttpClient();

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

// Basic usage

var source = new Source {Prop1 = "1", Prop2 = "2"};

// Mapping to a new object
var destObject = source.Adapt<SourceDto>();

Log.Debug($"{destObject.Prop1} {destObject.Prop2}");

// Mapping to an existing object
var existingDto = new SourceDto { Prop1 = "3", Prop2 = "4"};
source.Adapt(existingDto);

Log.Debug($"{existingDto.Prop1} {existingDto.Prop2}");

// dotnet tool install -g Mapster.Tool
// See entries in csproj file
// dotnet msbuild -t:Mapster
// dotnet msbuild -t:CleanGenerated


// dotnet mapster model -a
// dotnet mapster model -a "C:\Users\philippe\source\repos\TestMapster\TestMapster\bin\Debug\net6.0\TestMapster.dll" -n TestMapster.Dtos -o Dtos
// cd C:\Users\philippe\source\repos\TestMapster\TestMapster
// C:\Users\philippe\Downloads\Mapster-master\src\Mapster.Tool\bin\Debug\net6.0\Mapster.Tool.exe model -a "C:\Users\philippe\source\repos\TestMapster\TestMapster\bin\Debug\net6.0\TestMapster.dll" -n TestMapster.Dtos -o Dtos
// C:\Users\philippe\Downloads\Mapster-master\src\Mapster.Tool\bin\Debug\net6.0\Mapster.Tool.exe extension -a "C:\Users\philippe\source\repos\TestMapster\TestMapster\bin\Debug\net6.0\TestMapster.dll" -n TestMapster.Dtos -o Dtos
// C:\Users\philippe\Downloads\Mapster-master\src\Mapster.Tool\bin\Debug\net6.0\Mapster.Tool.exe mapper -a "C:\Users\philippe\source\repos\TestMapster\TestMapster\bin\Debug\net6.0\TestMapster.dll" -n TestMapster.Mappers -o Mappers


await app.StopAsync();