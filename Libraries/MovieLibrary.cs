using System;
using System.Collections.Generic;
using ApplicationTemplate.Media;

namespace ApplicationTemplate.Libraries;

public class MovieLibrary : MediaLibrary<Movie>
{
    private List<Movie> library;

    public MovieLibrary(List<Movie> library)
    {
        this.library = library;
    }
    
    public override void addMedia(string csvLine)
    {
        var lineSplitUp = csvLine.Split(',');

        var genresSplitUp = lineSplitUp[2].Split('|');

        List<string> genresList = new List<string>();

        foreach (var genre in genresSplitUp)
        {
            genresList.Add(genre);
        }

        library.Add(new Movie(Convert.ToInt32(lineSplitUp[0]), lineSplitUp[1], genresList));
    }

    public override void AddMedia(Movie movie)
    {
        library.Add(movie);
    }

    public override string ListMedia()
    {
        string listedMovies = "Movie ID: Movie Title";
        
        foreach (var movie in library)
        {
            listedMovies += $"\n{movie.Id}: {movie.Title}";
        }

        return listedMovies;
    }

    public override string SaveString()
    {
        string csvLines = "Movie ID,Movie Title (Release),Genres";
        
        foreach (var movie in library)
        {
            csvLines += $"\n{movie.Id},{movie.Title},";
            
            foreach (var genre in movie.Genres)
            {
                csvLines += $"{genre}|";
            }

            csvLines = csvLines.Substring(0, csvLines.Length - 1);
        }

        return csvLines;
    }
}