using System;
using System.Linq;
using System.Windows.Input;
using MusicPlayer.Base;
using MusicPlayer.Models;
using MusicPlayer.Pages;
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

            IsRunning = true;
            PlayerViewPage playerViewPage = new PlayerViewPage()
            {
                BindingContext = new PlayerViewModel(selectedSong, Songs)
            };
            await Navigation.PushAsync(playerViewPage, false);
            SelectedSong = null;
            IsRunning = false;
        }

        private List<Song> _songs;
        public List<Song> Songs
        {
            get => _songs;
            set { SetProperty(ref _songs, value); }
        }

        private List<Song> _filteredSongs;
        public List<Song> FilteredSongs
        {
            get => _filteredSongs;
            set { SetProperty(ref _filteredSongs, value); }
        }

        private async void InitializeSongsList()
        {
            IsRunning = true;
            if(Songs == null || Songs.Count <= 0)
            {
                var songs = await _songsService.GetSongs();
                Songs = songs.ToList();
            }
            FilteredSongs = Songs;
            IsRunning = false;
        }

        public void OnAppearing()
        {
            InitializeSongsList();
        }

        public void OnDisappearing()
        {

        }

        public ICommand SearchSong => new Command<string>((string query) =>
        {
            Search(query);
        });

        private void Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                FilteredSongs = Songs;
            }
            else
            {
                var filteredSongs = Songs.Where(song => song.FilmName.Contains(query, StringComparison.OrdinalIgnoreCase)
                || song.SongName.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
                FilteredSongs = filteredSongs;
            }
        }

        private string searchText;
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                if (searchText.Length > 2)
                {
                    Search(searchText);
                }
                else
                {
                    Search(string.Empty);
                }
            }
        }

        private bool _isRunning;
        public bool IsRunning
        {
            get => _isRunning;
            set { SetProperty(ref _isRunning, value); }
        }
    }
}

