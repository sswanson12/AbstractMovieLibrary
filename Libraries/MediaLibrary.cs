using System.Collections.Generic;

namespace ApplicationTemplate.Libraries;

public abstract class MediaLibrary<TE> : IMediaLibrary<TE>
{
    public abstract void addMedia(string csvLine);
    public abstract void AddMedia(TE media);
    public abstract string ListMedia();
    public abstract string SaveString();
}