using WSCADCodeChallenge.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using WSCADCodeChallenge.Drawable;

namespace WSCADCodeChallenge.ViewModels;

public partial class MainViewModel : ObservableObject {

    private readonly ShapeService _shapeService;

    [ObservableProperty]
    Canvas drawableGraphic;

    public MainViewModel(ShapeService shapeService)
    {
        _shapeService = shapeService;

        var task = _shapeService.GetAllShapesAync();
        try
        {
               task.Wait();
        }
        catch (System.Exception)
        {
            
            Console.WriteLine("Exception");
        }

        drawableGraphic = new Canvas(task.Result);
    }
}