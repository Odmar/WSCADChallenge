using WSCADCodeChallenge.DrawableObjects;
using WSCADCodeChallenge.Models.Shapes;
using WSCADCodeChallenge.Services;

namespace WSCADCodeChallenge;

public partial class MainPage : ContentPage 
{
	public MainPage(MainViewModel viewModel)
	{

		 InitializeComponent();
    	 BindingContext = viewModel;
		
	}


}

