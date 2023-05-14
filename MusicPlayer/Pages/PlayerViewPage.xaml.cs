namespace MusicPlayer.Pages;
using MusicPlayer.ViewModels;

public partial class PlayerViewPage : Base.BaseContentPage
{
    private double _height;
    public PlayerViewPage()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        SetAvatarHeight();
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (height > 0)
        {
            _height = height;
            SetAvatarHeight();
        }
    }

    private void SetAvatarHeight()
    {
        if (BindingContext is PlayerViewModel playerViewModel && _height > 0)
        {
            var height = _height * 4 / 10;
            var roundHeight = Math.Round(height, 0, MidpointRounding.ToEven);
            playerViewModel.AvatarHeight = roundHeight;
            playerViewModel.AvatarCornerRadius = roundHeight / 2;
        }
    }
}
