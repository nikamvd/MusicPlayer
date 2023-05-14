using System;
using System.Windows.Input;
using MusicPlayer.Models;
using MusicPlayer.Base;

namespace MusicPlayer.ViewModels
{
	public class PlayerViewModel : BaseViewModel, ILazyNavigator, IMonitorAppearance
    {
        public PlayerViewModel() : this(new Song(), new List<Song>() { new Song() }) { }

        public PlayerViewModel(Song selectedSong, List<Song> songs)
		{
            SelectedSong = selectedSong;
            Songs = songs;
            BackCommand = new Command(async () => await NavigateBack());
        }

        private Song _selectedSong;
        public Song SelectedSong
        {
            get => _selectedSong;
            set { SetProperty(ref _selectedSong, value); }
        }

        private List<Song> _songs;
        public List<Song> Songs
        {
            get => _songs;
            set { SetProperty(ref _songs, value); }
        }

        private double _avatarHeight;
        public double AvatarHeight
        {
            get => _avatarHeight;
            set { SetProperty(ref _avatarHeight, value); }
        }

        private double _avatarCornerRadius;
        public double AvatarCornerRadius
        {
            get => _avatarCornerRadius;
            set { SetProperty(ref _avatarCornerRadius, value); }
        }

        private double _avatarWidth;
        public double AvatarWidth
        {
            get => _avatarWidth;
            set { SetProperty(ref _avatarWidth, value); }
        }

        public INavigation Navigation { get; set; }

        private ICommand _backCommand;
        public ICommand BackCommand
        {
            get => _backCommand;
            set { SetProperty(ref _backCommand, value); }
        }

        private async Task NavigateBack()
        {
            await Navigation?.PopAsync(false);
        }

        public void OnAppearing()
        {
            
        }

        public void OnDisappearing()
        {
            DisconnectCommand.Execute(null);
        }

        private ICommand _disconnectCommand;
        public ICommand DisconnectCommand
        {
            get => _disconnectCommand;
            set { SetProperty(ref _disconnectCommand, value); }
        }
    }
}

