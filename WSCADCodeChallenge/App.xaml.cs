namespace WSCADCodeChallenge;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}

	/// <summary>
	/// Override base CreateWindow to set fixed dimensions
	/// and set App Title
	/// </summary>
	/// <param name="activationState"></param>
	/// <returns></returns>
	protected override Window CreateWindow(IActivationState activationState)
	{
		Window window = base.CreateWindow(activationState);
		window.Title = "WSCAD Code Challenge";

		window.Height = Constants.WINDOW_HEIGHT_WIDTH + 100;
		window.Width = Constants.WINDOW_HEIGHT_WIDTH + 100;

		window.MaximumHeight = Constants.WINDOW_HEIGHT_WIDTH + 100;
		window.MinimumHeight = Constants.WINDOW_HEIGHT_WIDTH + 100;

		window.MaximumWidth = Constants.WINDOW_HEIGHT_WIDTH + 100;
		window.MinimumWidth = Constants.WINDOW_HEIGHT_WIDTH + 100;

		return window;
	}
}
