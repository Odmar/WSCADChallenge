using WSCADCodeChallenge.ViewModels;

namespace WSCADCodeChallenge.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

