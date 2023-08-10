using Newtonsoft.Json;
using WSCADCodeChallenge.Models;

namespace WSCADCodeChallenge.Broker.FileSystemBroker;

public class JsonFileSystemBroker : IFileSystemBroker
{
    private readonly string jsonPath = "Shapes.json";
    private async Task<string> ReadJsonFile()
    {
        using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(jsonPath);
        using StreamReader reader = new(fileStream);
        string result = reader.ReadToEnd();
        reader.Close();
        fileStream.Close();
        return result;
    }

    public async Task<List<Shape>> GetAllShapesAsync()
    {
        Console.WriteLine("Start Reading JSON");
        string jsonContent = await ReadJsonFile();
        Console.WriteLine("Start Deserialize JSON");
        var shapesFromJson = JsonConvert.DeserializeObject<List<object>>(jsonContent);

        var shapes = new List<Shape>();
        Console.WriteLine("Start Iterating over JSON");
        foreach (var shapeFromList in shapesFromJson)
        {
            Shape shape = JsonConvert.DeserializeObject<Shape>(shapeFromList.ToString());
            Console.WriteLine(shapeFromList);
            switch (shape.Type)
            {
                case ShapeType.Line:
                    var line = JsonConvert.DeserializeObject<Line>(shapeFromList.ToString());
                    shapes.Add(line);
                    break;

                case ShapeType.Circle:
                    var circle = JsonConvert.DeserializeObject<Circle>(shapeFromList.ToString());
                    shapes.Add(circle);
                    break;

                case ShapeType.Triangle:
                    var triangle = JsonConvert.DeserializeObject<Triangle>(shapeFromList.ToString());
                    shapes.Add(triangle);
                    break;
                    
                default:
                    Console.WriteLine(shape.Type + " is an unkown shape");
                    break;
            }
        }

        return shapes;
    }

}