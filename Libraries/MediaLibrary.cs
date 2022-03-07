using System.Collections.Generic;

namespace ApplicationTemplate.Libraries;

public abstract class MediaLibrary<TE> : IMediaLibrary<TE>
{
    public abstract void AddMedia(string csvLine);
    public abstract bool AddMedia(TE media);
    public abstract string ListMedia();
    public abstract string ListMedia(int count);
    public abstract List<TE> GetLibrary();
}