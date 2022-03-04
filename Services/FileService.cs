using System;
using System.IO;
using ApplicationTemplate.Libraries;
using ApplicationTemplate.Media;
using Microsoft.Extensions.Logging;

namespace ApplicationTemplate.Services;

/// <summary>
///     This concrete service and method only exists an example.
///     It can either be copied and modified, or deleted.
/// </summary>
public class FileService : IFileService
{
    private readonly string _filePath = "Files/mlLibrary/movies.csv";
    private readonly ILogger<IFileService> _logger;

    public FileService(ILogger<IFileService> logger)
    {
        _logger = logger;
    }

    public void ReadTo(IMediaLibrary<Movie> library)
    {
        _logger.Log(LogLevel.Information, "Reading");

        var sr = new StreamReader(_filePath);
        sr.ReadLine(); //Skips first line of file (movieId,title,genres)


        while (!sr.EndOfStream)
        {
            var currentLine = sr.ReadLine() ?? throw new InvalidOperationException();

            library.AddMedia(currentLine);
        }

        sr.Close();
    }

    public void Write(string saveString)
    {
        _logger.Log(LogLevel.Information, "Writing");

        var sw = new StreamWriter(_filePath);
        
        sw.Write(saveString);

        sw.Close();
    }
}