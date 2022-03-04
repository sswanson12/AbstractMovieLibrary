using System.Linq;

namespace ApplicationTemplate.Media;

public class Video : Media
{
    private int _id;
    private string _title;
    private string _format;
    private int _length;
    private int[] _regions;

    public Video(string title, string format, int length, int[] regions)
    {
        _title = title;
        _format = format;
        _length = length;
        _regions = regions;
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

    public string Format
    {
        get => _format;
        set => _format = value;
    }

    public int Length
    {
        get => _length;
        set => _length = value;
    }

    public int[] Regions
    {
        get => _regions;
        set => _regions = value;
    }
}