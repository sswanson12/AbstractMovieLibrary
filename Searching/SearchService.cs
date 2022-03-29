using System.Collections.Generic;
using System.Linq;
using ApplicationTemplate.Libraries;
using ApplicationTemplate.Media;

namespace ApplicationTemplate.Searching;

public class SearchService : ISearchService
{

    private readonly List<Media.Media> _mediaList;

    private readonly IMediaLibrary<Movie> _movieLibrary;
    private readonly IMediaLibrary<Show> _showLibrary;
    private readonly IMediaLibrary<Video> _videoLibrary;

    public SearchService(IMediaLibrary<Movie> ml, IMediaLibrary<Show> sl, IMediaLibrary<Video> vl)
    {
        _mediaList = new List<Media.Media>();

        _movieLibrary = ml;
        _showLibrary = sl;
        _videoLibrary = vl;

        Update();
    }
    
    public List<Media.Media> Search(string searchString)
    {
        Update();
        
        var results = _mediaList.Where(media => media.GetName().ToLower().Contains(searchString.ToLower())).ToList();
        
        return results;
    }

    private void Update()
    {
        _mediaList.Clear();

        foreach (var movie in _movieLibrary.GetLibrary())
        {
            _mediaList.Add(movie);
        }
        
        foreach (var show in _showLibrary.GetLibrary())
        {
            _mediaList.Add(show);
        }
        
        foreach (var video in _videoLibrary.GetLibrary())
        {
            _mediaList.Add(video);
        }
    }
}