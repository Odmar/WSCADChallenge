using WSCADCodeChallenge.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using WSCADCodeChallenge.DrawableObjects;

namespace WSCADCodeChallenge;

public partial class MainViewModel : ObservableObject {

    private readonly ShapeService _shapeService;

    [ObservableProperty]
    DrawableGraphic drawableGraphic;

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
     

        var bla = task.Result;
    }
}