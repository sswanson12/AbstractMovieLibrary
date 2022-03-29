using System.Collections.Generic;

namespace ApplicationTemplate.Searching;

public interface ISearchService
{
    List<Media.Media> Search(string searchString);
}