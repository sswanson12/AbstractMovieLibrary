using System;
using ApplicationTemplate.Files;
using ApplicationTemplate.Libraries;
using ApplicationTemplate.Media;
using ApplicationTemplate.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ApplicationTemplate;

/// <summary>
///     Used for registration of new interfaces
/// </summary>
internal class Startup
{
    public IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddFile("app.log");
        });

        // Add new lines of code here to register any interfaces and concrete services you create
        services.AddTransient<IMainService, MainService>();
        services.AddTransient<IFilePath, FilePath>();
        // services.AddTransient<IMediaLibrary<Movie>, MovieLibrary>();
        // services.AddTransient<IMediaLibrary<Show>, ShowLibrary>();
        // services.AddTransient<IMediaLibrary<Video>, VideoLibrary>();
        services.AddTransient<IFileService, FileService<MovieLibrary>>();

        return services.BuildServiceProvider();
    }
}
