using WSCADCodeChallenge.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using WSCADCodeChallenge.Drawable;
using WSCADCodeChallenge.Models;

namespace WSCADCodeChallenge.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ShapeService _shapeService;

    [ObservableProperty]
    IDrawable drawable;

    public MainViewModel(ShapeService shapeService)
    {
          _shapeService = shapeService;
          _ = Init();
    }

    public async Task Init() {    
        List<Shape> shapes = await _shapeService.GetAllShapesAync();      
        Drawable = new Canvas(shapes);
    }
}