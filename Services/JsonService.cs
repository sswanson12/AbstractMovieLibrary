using System;
using System.IO;
using ApplicationTemplate.Libraries;
using ApplicationTemplate.Media;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ApplicationTemplate.Services;

public class JsonService : IFileService
{
    private string _filePath;
    private readonly ILogger<IFileService> _logger;

    public JsonService(ILogger<IFileService> logger)
    {
        _logger = logger;
    }

    public void ReadTo(IMediaLibrary<Movie> library)
    {
        _logger.Log(LogLevel.Information, "Reading JSON to movie library");
        StreamReader sr = new StreamReader(_filePath);
        
        while (!sr.EndOfStream)
        {
            Movie currentMovie = JsonConvert.DeserializeObject<Movie>(sr.ReadLine() ?? throw new InvalidOperationException());
            library.AddMedia(currentMovie);
        }
        
        sr.Close();
    }

    public void ReadTo(IMediaLibrary<Show> library)
    {
        _logger.Log(LogLevel.Information, "Reading JSON to show library");
        StreamReader sr = new StreamReader(_filePath);
        
        while (!sr.EndOfStream)
        {
            Show currentShow = JsonConvert.DeserializeObject<Show>(sr.ReadLine() ?? throw new InvalidOperationException());
            library.AddMedia(currentShow);
        }
        
        sr.Close();
    }

    public void ReadTo(IMediaLibrary<Video> library)
    {
        _logger.Log(LogLevel.Information, "Reading JSON to video library");
        StreamReader sr = new StreamReader(_filePath);
        
        while (!sr.EndOfStream)
        {
            Video currentVideo = JsonConvert.DeserializeObject<Video>(sr.ReadLine() ?? throw new InvalidOperationException());
            library.AddMedia(currentVideo);
        }
        
        sr.Close();
    }

    public void Write(IMediaLibrary<Movie> library)
    {
        _logger.Log(LogLevel.Information, "Writing movie library to JSON");
        StreamWriter sw = new StreamWriter(_filePath);

        foreach (var movie in library.GetLibrary())
        {
            string jsonString = JsonConvert.SerializeObject(movie);
            sw.WriteLine(jsonString);
        }
        
        sw.Close(); 
    }

    public void Write(IMediaLibrary<Show> library)
    {
        _logger.Log(LogLevel.Information, "Writing show library to JSON");
        StreamWriter sw = new StreamWriter(_filePath);
        
        foreach (var show in library.GetLibrary())
        {
            string jsonString = JsonConvert.SerializeObject(show);
            sw.WriteLine(jsonString);
        }
        
        sw.Close();
    }

    public void Write(IMediaLibrary<Video> library)
    {
        _logger.Log(LogLevel.Information, "Writing video to JSON");
        StreamWriter sw = new StreamWriter(_filePath);
        
        foreach (var video in library.GetLibrary())
        {
            string jsonString = JsonConvert.SerializeObject(video);
            sw.WriteLine(jsonString);
        }
        
        sw.Close();
    }

    public void SetFilePath(string filePath)
    {
        _filePath = filePath;
    }
}