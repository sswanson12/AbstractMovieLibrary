using System;
using System.Collections.Generic;

namespace ApplicationTemplate.Media;

public class Movie : Media
{
    private readonly int _id;

    private string _title;
    private List<string> _genres;

    public Movie(int movieId, string title, List<string> genres)
    {
        this._id = movieId;
        this._title = title;
        this._genres = genres;
        
    }

    public int Id => _id;

    public string Title
    {
        get => _title;
        set => _title = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<string> Genres
    {
        get => _genres;
        set => _genres = value ?? throw new ArgumentNullException(nameof(value));
    }
}