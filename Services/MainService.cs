using System;
using System.Collections.Generic;
using ApplicationTemplate.Libraries;
using ApplicationTemplate.Media;
using ApplicationTemplate.Searching;

namespace ApplicationTemplate.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{
    private readonly IFileService _fileService;
    private readonly ISearchService _searchService;
    private readonly IMediaLibrary<Movie> _movieLibrary;
    private readonly IMediaLibrary<Show> _showLibrary;
    private readonly IMediaLibrary<Video> _videoLibrary;

    public MainService(IFileService fileService)
    {
        _fileService = fileService;
        _movieLibrary = new MovieLibrary();
        _showLibrary = new ShowLibrary();
        _videoLibrary = new VideoLibrary();

        _fileService.SetFilePath("Files/jsonFiles/movies.json");
        _fileService.ReadTo(_movieLibrary);
        
        _fileService.SetFilePath("Files/jsonFiles/shows.json");
        _fileService.ReadTo(_showLibrary);
        
        _fileService.SetFilePath("Files/jsonFiles/videos.json");
        _fileService.ReadTo(_videoLibrary);
        
        _searchService = new SearchService(_movieLibrary, _showLibrary, _videoLibrary);
    }

    public void Invoke()
    {
        string choice;

        do
        {
            Console.WriteLine("What would you like to do?\n"
                              + "1) Open Movie Library\n2) Open Show Library\n3) Open Video Library\n4) Search Libraries");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    MovieMenu();
                    break;
                case "2":
                    ShowMenu();
                    break;
                case "3":
                    VideoMenu();
                    break;
                case "4":
                    SearchMenu();
                    break;
                default:
                    choice = "x";
                    break;
            }
        } while (!choice.Equals("x"));
    }

    private void MovieMenu()
    {
        _fileService.SetFilePath("Files/jsonFiles/movies.json");
        string choice;
        do
        {
            Console.WriteLine("1) Add Movie");
            Console.WriteLine("2) Display All Movies");
            Console.WriteLine("X) Quit");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                AddToLibrary(_movieLibrary);
                _fileService.Write(_movieLibrary);
            }
            else if (choice == "2") Console.WriteLine(_movieLibrary.ListMedia());
        } while (choice != "X");
    }

    private void ShowMenu()
    {
        _fileService.SetFilePath("Files/jsonFiles/shows.json");
        string choice;
        do
        {
            Console.WriteLine("1) Add Show");
            Console.WriteLine("2) Display All Shows");
            Console.WriteLine("X) Quit");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                AddToLibrary(_showLibrary);
                _fileService.Write(_showLibrary);
            }
            else if (choice == "2") Console.WriteLine(_showLibrary.ListMedia());
        } while (choice != "X");
    }

    private void VideoMenu()
    {
        _fileService.SetFilePath("Files/jsonFiles/videos.json");
        string choice;
        do
        {
            Console.WriteLine("1) Add Video");
            Console.WriteLine("2) Display All Videos");
            Console.WriteLine("X) Quit");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                AddToLibrary(_videoLibrary);
                _fileService.Write(_videoLibrary);
            }
            else if (choice == "2") Console.WriteLine(_videoLibrary.ListMedia());
        } while (choice != "X");
    }

    private void SearchMenu()
    {
        Console.WriteLine("Please enter the title you're looking for: ");

        var results = _searchService.Search(Console.ReadLine());

        foreach (var media in results)
        {
            Console.WriteLine($"{media.GetType()} - {media.GetName()}");
        }
    }

    private static void AddToLibrary(IMediaLibrary<Movie> library)
    {
        string newTitle;
        var genreList = new List<string>();
        do
        {
            Console.Write("Please enter the year the movie was released: ");
            var releaseYear = Console.ReadLine();

            Console.Write("Please enter the movie title: ");
            newTitle = Convert.ToString(Console.ReadLine());

            while (newTitle is {Length: <= 0})
            {
                Console.Write("Looks like you left the title blank! Please try again: ");
                newTitle = Convert.ToString(Console.ReadLine());
            }

            newTitle = $"{newTitle} ({releaseYear})";

            Console.Write("Please enter all the movie's genres (when done entering, enter (x) to exit): ");

            while (true)
            {
                var currentGenre = Convert.ToString(Console.ReadLine());
                while (currentGenre is null)
                {
                    Console.Write("Looks like you left a blank genre! Please try again: ");
                    currentGenre = Convert.ToString(Console.ReadLine());
                }

                if (currentGenre.ToLower().Equals("x")) break;

                genreList.Add(currentGenre);
            }
        } while (!library.AddMedia(new Movie(-1, newTitle, genreList)));
    }

    private static void AddToLibrary(IMediaLibrary<Show> library)
    {
        string newTitle;
        int season;
        int episode;
        string[] writers;
        do
        {
            Console.Write("Please enter the year the show was released: ");
            var releaseYear = Convert.ToString(Console.ReadLine());

            Console.Write("Please enter the movie title: ");
            newTitle = Convert.ToString(Console.ReadLine());

            while (newTitle is {Length: <= 0})
            {
                Console.Write("Looks like you left the title blank! Please try again: ");
                newTitle = Convert.ToString(Console.ReadLine());
            }

            newTitle = $"{newTitle} ({releaseYear})";

            Console.Write("Please enter which season the episode is from: ");
            season = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter the episode number: ");
            episode = Convert.ToInt32(Console.ReadLine());

            Console.Write("How many writers does this show have? ");
            var numWriters = Convert.ToInt32(Console.ReadLine());
            writers = new string[numWriters];
            for (var i = 0; i < numWriters; i++)
            {
                Console.Write($"Please enter writer {i+1}: ");
                writers[i] = Console.ReadLine();
            }
        } while (!library.AddMedia(new Show(-1, newTitle, season, episode, writers)));
    }

    private static void AddToLibrary(IMediaLibrary<Video> library)
    {
        string newTitle;
        string format;
        int length;
        int[] regions;
        do
        {
            Console.Write("Please enter the year the video was released: ");
            var releaseYear = Convert.ToString(Console.ReadLine());

            Console.Write("Please enter the movie title: ");
            newTitle = Convert.ToString(Console.ReadLine());

            while (newTitle is {Length: <= 0})
            {
                Console.Write("Looks like you left the title blank! Please try again: ");
                newTitle = Convert.ToString(Console.ReadLine());
            }

            newTitle = $"{newTitle} ({releaseYear})";

            Console.Write("Please enter what format the video is in: ");
            format = Convert.ToString(Console.ReadLine());

            Console.Write("Please enter the length of the video in minutes: ");
            length = Convert.ToInt32(Console.ReadLine());

            Console.Write("How many regions is this video available in? ");
            var numRegions = Convert.ToInt32(Console.ReadLine());
            regions = new int[numRegions];
            for (var i = 0; i < numRegions; i++)
            {
                Console.Write($"Please enter region {i+1}: ");
                regions[i] = Convert.ToInt32(Console.ReadLine());
            }
        } while (!library.AddMedia(new Video(-1, newTitle, format, length, regions)));
    }
}