using System;
using System.Collections.Generic;
using System.Linq;
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

    public override bool AddMedia(string newTitle, List<string> genreList)
    {
        var newId = (_library[_library.Count - 1].Id) + 1;

        foreach (var item in _library)
            if (newTitle.Equals(item.Title))
                return false;
        _library.Add(new Movie(newId, newTitle, genreList));
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

    public override string SaveString()
    {
        var csvLines = "Movie ID,Movie Title (Release),Genres";

        foreach (var movie in _library)
        {
            csvLines += $"\n{movie.Id},{movie.Title},";
            
            //had this in a foreach loop, this was suggested by rider.
            csvLines = movie.Genres.Aggregate(csvLines, (current, genre) => current + $"{genre}|");

            csvLines = csvLines[..^1];
        }

        return csvLines;
    }
}