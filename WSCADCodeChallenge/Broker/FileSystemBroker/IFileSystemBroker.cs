using WSCADCodeChallenge.Models;

namespace WSCADCodeChallenge.Broker.FileSystemBroker;
public interface IFileSystemBroker
{
     public Task<List<Shape>> GetAllShapesAsync();
}