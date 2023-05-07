using System;
namespace MusicPlayer.Constants
{
    public static class ApiUrls
    {
        /// <summary>
        /// Use this base address to retrieve json data from cloud
        /// </summary>
        public const string BaseAddress = "https://samusicplayer.blob.core.windows.net";
        public const string SongsUrl = @"/cmusicplayer/songs.json";
    }
}

