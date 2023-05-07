using System;
using System.Windows.Input;
using MusicPlayer.Base;
using MusicPlayer.Models;
using MusicPlayer.Services;

namespace MusicPlayer.ViewModels
{
    public class SongsListViewModel : BaseViewModel, ILazyNavigator, IMonitorAppearance
    {
        private readonly ISongsService _songsService;
        public SongsListViewModel(ISongsService songsService)
        {
            _songsService = songsService;
        }

        public INavigation Navigation { get; set; }
        public ICommand SongSelectedCommand => new Command<Song>(async (Song selectedSong) => await NavigateToPlayerView(selectedSong));

        private Song _selectedSong;
        public Song SelectedSong
        {
            get => _selectedSong;
            set { SetProperty(ref _selectedSong, value); }
        }

        private async Task NavigateToPlayerView(Song selectedSong)
        {
            if (selectedSong == null)
            {
                return;
            }

            //ProfileViewPage profileViewPage = new ProfileViewPage()
            //{
            //    BindingContext = new PlayerViewModel(selectedSong, Songs)
            //};
            //await Navigation.PushAsync(profileViewPage, false);
            SelectedSong = null;
        }

        private List<Song> _songs;
        public List<Song> Songs
        {
            get => _songs;
            set { SetProperty(ref _songs, value); }
        }

        private async void InitializeSongsList()
        {
            var songs = await _songsService.GetSongs();
            Songs = songs.ToList();
        }

        public void OnAppearing()
        {
            InitializeSongsList();
        }

        public void OnDisappearing()
        {

        }
    }
}

