using System.Collections.Generic;

namespace ApplicationTemplate.Libraries;

public interface IMediaLibrary<TE>
{
    void addMedia(string csvLine);

    void AddMedia(TE media);

    string ListMedia();

    string SaveString();
}