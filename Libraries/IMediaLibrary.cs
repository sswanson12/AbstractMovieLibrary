using System.Collections.Generic;

namespace ApplicationTemplate.Libraries;

public interface IMediaLibrary<TE>
{
    void AddMedia(string csvLine);

    bool AddMedia(string newTitle, List<string> genreList);

    string ListMedia();

    string ListMedia(int count);

    string SaveString();
}