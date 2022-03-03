using ApplicationTemplate.Media;

namespace ApplicationTemplate.Libraries;

public class VideoLibrary : MediaLibrary<Video>
{
    public override void addMedia(string csvLine)
    {
        throw new System.NotImplementedException();
    }

    public override void AddMedia(Video media)
    {
        throw new System.NotImplementedException();
    }

    public override string ListMedia()
    {
        throw new System.NotImplementedException();
    }

    public override string SaveString()
    {
        throw new System.NotImplementedException();
    }
}