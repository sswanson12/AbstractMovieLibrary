using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using ApplicationTemplate.Media;

namespace ApplicationTemplate.Libraries;

public class MovieLibrary : MediaLibrary<Movie>
{

    private readonly List<Movie> _library;
    public MovieLibrary()
    {
        _library = new List<Movie>();
        
    }


    public override void AddMedia(string csvLine)
    {
        var lineSplitUp = csvLine.Split(',');

        var genresSplitUp = lineSplitUp[2].Split('|');

        var genresList = new List<string>();

        foreach (var genre in genresSplitUp) genresList.Add(genre);

        _library.Add(new Movie(Convert.ToInt32(lineSplitUp[0]), lineSplitUp[1], genresList));
    }

    public override bool AddMedia(Movie movie)
    {
        int newId;
        
        if (_library.Count == 0)
        {
            newId = 1;
        } else newId = (_library[^1].Id) + 1;

        foreach (var testMovie in _library)
        {
            if (movie.Title == testMovie.Title)
            {
                movie = null; //I didn't like the idea of having a random movie floating around the heap for no reason
                return false;
            }
        }

        movie.Id = newId;

        _library.Add(movie);

        return true;
    }

    public override string ListMedia()
    {
        //had this in a foreach loop, this was suggested by rider.
        return _library.Aggregate("Movie ID: Movie Title", (current, movie) => current + $"\n{movie.Id}: {movie.Title}");
    }

    public override string ListMedia(int count)
    {
        var listedMovies = "Movie ID: Movie Title";

        for (var i = 0; i < count; i++) listedMovies += $"\n{_library[i].Id}: {_library[i].Title}";

        return listedMovies;
    }

    public override List<Movie> GetLibrary()
    {
        return _library;
    }
}