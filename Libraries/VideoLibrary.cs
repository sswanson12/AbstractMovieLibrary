using System.Collections.Generic;
using ApplicationTemplate.Media;

namespace ApplicationTemplate.Libraries;

public class VideoLibrary : MediaLibrary<Video>
{
    public override void AddMedia(string csvLine)
    {
        throw new System.NotImplementedException();
    }

    public override bool AddMedia(string newTitle, List<string> genreList)
    {
        throw new System.NotImplementedException();
    }

    public override string ListMedia()
    {
        throw new System.NotImplementedException();
    }

    public override string ListMedia(int count)
    {
        throw new System.NotImplementedException();
    }

    public override string SaveString()
    {
        throw new System.NotImplementedException();
    }
}