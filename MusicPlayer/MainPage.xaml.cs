namespace MusicPlayer;

using Microsoft.Extensions.DependencyInjection;
using MusicPlayer.ViewModels;

public partial class MainPage : ContentPage
{
    IDispatcherTimer _timer;
    private double _height;
	public MainPage()
	{
		InitializeComponent();
        var playerViewModel = MusicPlayer.Services.ServiceProvider.GetService<PlayerViewModel>();
        BindingContext = playerViewModel;

        _timer = Application.Current.Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromMilliseconds(50);
        _timer.Tick += (s, e) => RotateSongTitle();
        
    }

    private void RotateSongTitle()
    {
        lblSongName.TranslationX -= 5f;

        if (Math.Abs(lblSongName.TranslationX) > stackDetails.Width)
        {
            lblSongName.TranslationX = lblSongName.Width;
        }
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        SetAvatarHeight();
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

		if(height > 0)
        {
            _height = height;
            SetAvatarHeight();
        }
    }

    private void SetAvatarHeight()
    {
        if(BindingContext is PlayerViewModel playerViewModel && _height > 0)
        {
            var height = _height * 4 / 10;
            var roundHeight = Math.Round(height, 0, MidpointRounding.ToEven);
            playerViewModel.AvatarHeight = roundHeight;
            playerViewModel.AvatarCornerRadius = roundHeight / 2;
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //_timer.Start();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        //_timer.Stop();
    }
}


