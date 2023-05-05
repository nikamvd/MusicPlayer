using System;
namespace MusicPlayer.Models
{
    public class Song
    {
        public string PictureUrl { get; init; } = "https://samusicplayer.blob.core.windows.net/cmusicplayer/Phulrani_Poster.jpg";
        public string SongUrl { get; init; } = "https://samusicplayer.blob.core.windows.net/cmusicplayer/Phulrani_HirveHirve.mp3";
        public string SongName { get; init; } = "Hirve Hirve Gaar Gaaliche";
        public string FilmName { get; init; } = "Phulrani";
    }
}

