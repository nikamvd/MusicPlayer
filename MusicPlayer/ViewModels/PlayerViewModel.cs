using System;
using MusicPlayer.Models;
namespace MusicPlayer.ViewModels
{
	public class PlayerViewModel : BaseViewModel
    {
        public PlayerViewModel() : this(new Song(), new List<Song>() { new Song() }) { }

        public PlayerViewModel(Song selectedSong, List<Song> songs)
		{
            SelectedSong = selectedSong;
            Songs = songs;
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
    }
}

