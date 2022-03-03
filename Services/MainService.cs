using System;
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
    public MainService(IFileService fileService, IMediaLibrary<Movie> movieLibrary)
    {
        _fileService = fileService;
        _movieLibrary = movieLibrary;
    }

    public void Invoke()
    {
    string choice;
     do
     {
         Console.WriteLine("1) Add Movie");
         Console.WriteLine("2) Display All Movies");
         Console.WriteLine("X) Quit");
         choice = Console.ReadLine();
    
         // Logic would need to exist to validate inputs and data prior to writing to the file
         // You would need to decide where this logic would reside.
         // Is it part of the FileService or some other service?
         if (choice == "1")
         {
           _fileService.Write(_movieLibrary.SaveString());
         }
         else if (choice == "2")
         {
            Console.WriteLine(_movieLibrary.ListMedia());
         }
     }
     while (choice != "X");
    }
}
