namespace MusicPlayer;
using MusicPlayer.ViewModels;
using MusicPlayer.Pages;

public partial class App : Application
{
	public App(SongsListViewModel songsListViewModel)
	{
		InitializeComponent();

        var songsListPage = new SongsListPage() { BindingContext = songsListViewModel };
        var navPage = new NavigationPage(songsListPage)
        {
            //BarBackgroundColor = Color.FromRgba("#512BD4"),
            //BackgroundColor = Color.FromRgba("#512BD4"),
            //BarTextColor = Color.FromRgba("#FFFFFF")
        };
        MainPage = navPage;
    }
}

