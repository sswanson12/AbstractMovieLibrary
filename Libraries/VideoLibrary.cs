using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ApplicationTemplate.Media;

namespace ApplicationTemplate.Libraries;

public class VideoLibrary : MediaLibrary<Video>
{
    
    private readonly List<Video> _library;
    public VideoLibrary()
    {
        _library = new List<Video>();
        
    }
    public override void AddMedia(string csvLine)
    {
        var lineSplitUp = csvLine.Split(',');

        var regionsSplitUp = lineSplitUp[4].Split('|');

        var regionsIntArray = new int[regionsSplitUp.Length];

        for (var i = regionsSplitUp.Length; i > 0; i--)
        {
            regionsIntArray[i] = Convert.ToInt32(regionsSplitUp[i]);
        }
        
        _library.Add(new Video(Convert.ToInt32(lineSplitUp[0]), lineSplitUp[1], lineSplitUp[2], Convert.ToInt32(lineSplitUp[3]), regionsIntArray));
    }

    public override bool AddMedia(Video video)
    {
        int newId;
        
        if (_library.Count == 0)
        {
            newId = 1;
        } else newId = (_library[^1].Id) + 1;

        foreach (var testVideo in _library)
        {
            if (video.Title == testVideo.Title)
            {
                video = null;
                return false;
            }
        }

        video.Id = newId;

        _library.Add(video);

        return true;
    }

    public override string ListMedia()
    {
        return _library.Aggregate("Video ID: Video Title", (current, video) => current + $"\n{video.Id}: {video.Title}");
    }

    public override string ListMedia(int count)
    {
        var listedVideos = "Video ID: Video Title";

        for (var i = 0; i < count; i++) listedVideos += $"\n{_library[i].Id}: {_library[i].Title}";

        return listedVideos;
    }
    
    public override List<Video> GetLibrary()
    {
        return _library;
    }
}