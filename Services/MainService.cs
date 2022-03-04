using System;
using System.Collections.Generic;
using ApplicationTemplate.Libraries;
using ApplicationTemplate.Media;

namespace ApplicationTemplate.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{
    private readonly IFileService _fileService;
    private readonly IMediaLibrary<Movie> _movieLibrary;

    public MainService(IFileService fileService)
    {
        _fileService = fileService;
        _movieLibrary = new MovieLibrary();
    }

    public void Invoke()
    {
        string choice;
        
        _fileService.ReadTo(_movieLibrary);
        do
        {
            Console.WriteLine("1) Add Movie");
            Console.WriteLine("2) Display All Movies");
            Console.WriteLine("X) Quit");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                AddToLibrary(_movieLibrary);
                _fileService.Write(_movieLibrary.SaveString());
            } else if (choice == "2") Console.WriteLine(_movieLibrary.ListMedia(10));
            
        } while (choice != "X");
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
        } while (!library.AddMedia(newTitle, genreList));
    }
}