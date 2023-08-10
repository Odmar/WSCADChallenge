namespace WSCADCodeChallenge;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

	protected override Window CreateWindow(IActivationState activationState)
	{
		Window window = base.CreateWindow(activationState);

		window.Height = Constants.WINDOW_HEIGHT_WIDTH + Constants.TOP_BAR_HEIGHT;
		window.Width = Constants.WINDOW_HEIGHT_WIDTH;

		window.MaximumHeight = Constants.WINDOW_HEIGHT_WIDTH + Constants.TOP_BAR_HEIGHT;
		window.MinimumHeight = Constants.WINDOW_HEIGHT_WIDTH;

		window.MaximumWidth = Constants.WINDOW_HEIGHT_WIDTH + Constants.TOP_BAR_HEIGHT;
		window.MinimumWidth = Constants.WINDOW_HEIGHT_WIDTH;

		return window;
	}
}
