using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationTemplate.Media;

namespace ApplicationTemplate.Libraries;

public class ShowLibrary : MediaLibrary<Show>
{
    
    private readonly List<Show> _library;
    public ShowLibrary()
    {
        _library = new List<Show>();
        
    }
    public override void AddMedia(string csvLine)
    {
        var lineSplitUp = csvLine.Split(',');

        var writersSplitUp = lineSplitUp[4].Split('|');

        _library.Add(new Show(Convert.ToInt32(lineSplitUp[0]), lineSplitUp[1], Convert.ToInt32(lineSplitUp[2]), Convert.ToInt32(lineSplitUp[3]), writersSplitUp));
    }

    public override bool AddMedia(Show show)
    {
        int newId;
        
        if (_library.Count == 0)
        {
            newId = 1;
        } else newId = (_library[^1].Id) + 1;

        foreach (var testShow in _library)
        {
            if (show.Title == testShow.Title)
            {
                show = null;
                return false;
            }
        }

        show.Id = newId;

        _library.Add(show);

        return true;
    }

    public override string ListMedia()
    {
        return _library.Aggregate("Show ID: Show Title", (current, show) => current + $"\n{show.Id}: {show.Title}");
    }

    public override string ListMedia(int count)
    {
        var listedShows = "Show ID: Show Title";

        for (var i = 0; i < count; i++) listedShows += $"\n{_library[i].Id}: {_library[i].Title}";

        return listedShows;
    }

    public override List<Show> GetLibrary()
    {
        return _library;
    }
}