using WSCADCodeChallenge.DrawableObjects;

namespace WSCADCodeChallenge;

public partial class MainPage : ContentPage 
{


	public MainPage()
	{
		InitializeComponent();
		GraphicsView.Drawable = new DrawableGraphic();
	}


}

