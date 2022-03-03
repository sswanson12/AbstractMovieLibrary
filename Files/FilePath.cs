namespace ApplicationTemplate.Files;

public class FilePath : IFilePath
{
    private readonly string _filePath = "mlLibrary/movies.csv";
    
    public string getFilePath()
    {
        return _filePath;
    }
}