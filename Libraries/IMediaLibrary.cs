using System.Collections.Generic;

namespace ApplicationTemplate.Libraries;

public interface IMediaLibrary<TE>
{
    void AddMedia(string csvLine);

    bool AddMedia(TE media);

    string ListMedia();

    string ListMedia(int count);

    List<TE> GetLibrary();
}