namespace MusicPlayer;
using MusicPlayer.ViewModels;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}
}

