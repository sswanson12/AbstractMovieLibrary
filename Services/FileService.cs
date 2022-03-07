using System;
using System.IO;
using System.Linq;
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
    private string _filePath;
    private readonly ILogger<IFileService> _logger;

    public FileService(ILogger<IFileService> logger)
    {
        _logger = logger;
    }

    public void ReadTo(IMediaLibrary<Movie> library)
    {
        _logger.Log(LogLevel.Information, "Reading to movie library");

        var sr = new StreamReader(_filePath);
        sr.ReadLine(); //Skips first line of file


        while (!sr.EndOfStream)
        {
            var currentLine = sr.ReadLine() ?? throw new InvalidOperationException();

            library.AddMedia(currentLine);
        }

        sr.Close();
    }

    public void ReadTo(IMediaLibrary<Show> library)
    {
        _logger.Log(LogLevel.Information, "Reading to show library");

        var sr = new StreamReader(_filePath);
        sr.ReadLine(); //Skips first line of file


        while (!sr.EndOfStream)
        {
            var currentLine = sr.ReadLine() ?? throw new InvalidOperationException();

            library.AddMedia(currentLine);
        }

        sr.Close();
    }

    public void ReadTo(IMediaLibrary<Video> library)
    {
        _logger.Log(LogLevel.Information, "Reading to video library");

        var sr = new StreamReader(_filePath);
        sr.ReadLine(); //Skips first line of file


        while (!sr.EndOfStream)
        {
            var currentLine = sr.ReadLine() ?? throw new InvalidOperationException();

            library.AddMedia(currentLine);
        }

        sr.Close();
    }

    public void Write(IMediaLibrary<Movie> library)
    {
        _logger.Log(LogLevel.Information, "Writing Movie Library");

        var sw = new StreamWriter(_filePath);

        var libraryList = library.GetLibrary();
        
        sw.WriteLine("Movie ID,Movie Title (Release),Genres");

        foreach (var movie in libraryList)
        {
            string csvLine = $"{movie.Id},{movie.Title},";

            csvLine = movie.Genres.Aggregate(csvLine, (current, genre) => current + $"{genre}|");

            csvLine = csvLine[..^1];
            sw.WriteLine(csvLine);
        }

        sw.Close();
    }

    public void Write(IMediaLibrary<Show> library)
    {
        _logger.Log(LogLevel.Information, "Writing Show Library");

        var sw = new StreamWriter(_filePath);

        var libraryList = library.GetLibrary();
        
        sw.WriteLine("ShowId,Title,Season,Episode,Writers");

        foreach (var show in libraryList)
        {
            string csvLine = $"{show.Id},{show.Title},{show.Season},{show.Episode},";

            csvLine = show.Writers.Aggregate(csvLine, (current, writer) => current + $"{writer}|");

            csvLine = csvLine[..^1];
            sw.WriteLine(csvLine);
        }

        sw.Close();
    }

    public void Write(IMediaLibrary<Video> library)
    {
        _logger.Log(LogLevel.Information, "Writing Video Library");

        var sw = new StreamWriter(_filePath);

        var libraryList = library.GetLibrary();
        
        sw.WriteLine("VideoId,Title,Format,Length,Regions");

        foreach (var video in libraryList)
        {
            string csvLine = $"{video.Id},{video.Title},{video.Format},{video.Length},";

            csvLine = video.Regions.Aggregate(csvLine, (current, region) => current + $"{region}|");

            csvLine = csvLine[..^1];
            sw.WriteLine(csvLine);
        }

        sw.Close();
    }

    public void SetFilePath(string filePath)
    {
        _filePath = filePath;
    }
}