namespace ApplicationTemplate.Media;

public class Show : Media
{
    private int _id;
    private string _title;
    private int _season;
    private int _episode;
    private string[] _writers;

    public Show(string title, int season, int episode, string[] writers)
    {
        _title = title;
        _season = season;
        _episode = episode;
        _writers = writers;
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Title
    {
        get => _title;
        set => _title = value;
    }

    public int Season
    {
        get => _season;
        set => _season = value;
    }

    public int Episode
    {
        get => _episode;
        set => _episode = value;
    }

    public string[] Writers
    {
        get => _writers;
        set => _writers = value;
    }
}