using WSCADCodeChallenge.Broker.FileSystemBroker;
using WSCADCodeChallenge.Models;

namespace WSCADCodeChallenge.Services;

public class ShapeService
{
    private readonly IFileSystemBroker _fileSystemBroker;

    public ShapeService(IFileSystemBroker fileSystemBroker)
    {
        this._fileSystemBroker = fileSystemBroker;
    }

    public async Task<List<Shape>> GetAllShapesAync()
    {
        return await _fileSystemBroker.GetAllShapesAsync();
    }
}