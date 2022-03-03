using System;
using System.Collections.Generic;
using System.IO;
using ApplicationTemplate.Files;
using ApplicationTemplate.Libraries;
using ApplicationTemplate.Media;
using Microsoft.Extensions.Logging;

namespace ApplicationTemplate.Services;

/// <summary>
///     This concrete service and method only exists an example.
///     It can either be copied and modified, or deleted.
/// </summary>
public class FileService<TE> : IFileService
{
    private readonly IFilePath _filePath;
    private readonly ILogger<IFileService> _logger;
    private readonly IMediaLibrary<TE> _library;

    public FileService(IFilePath filePath, ILogger<IFileService> logger, IMediaLibrary<TE> library)
    {
        _filePath = filePath;
        _logger = logger; 
        _library = library;
    }
    public void Read()
    {
        _logger.Log(LogLevel.Information, "Reading");
        
        StreamReader sr = new StreamReader(_filePath.getFilePath());
        sr.ReadLine(); //Skips first line of file (movieId,title,genres)
        
        
        while (!sr.EndOfStream)
        {
            var currentLine = sr.ReadLine() ?? throw new InvalidOperationException();
            
            _library.addMedia(currentLine);
        }
        sr.Close();
    }

    public void Write(string saveString)
    {
        _logger.Log(LogLevel.Information, "Writing");

        StreamWriter sw = new StreamWriter(_filePath.getFilePath());

        sw.Close();
    }
}
