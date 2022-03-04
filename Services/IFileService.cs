using ApplicationTemplate.Libraries;
using ApplicationTemplate.Media;

namespace ApplicationTemplate.Services;

/// <summary>
///     This service interface only exists an example.
///     It can either be copied and modified, or deleted.
/// </summary>
public interface IFileService
{
    void ReadTo(IMediaLibrary<Movie> library);
    void Write(string saveString);
}