using WSCADCodeChallenge.Models.Shapes;

namespace WSCADCodeChallenge.Broker.FileSystemBroker;
public interface IFileSystemBroker
{
     public Task<List<Shape>> GetAllShapesAsync();
}