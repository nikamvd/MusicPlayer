using System;
using System.Runtime.Serialization;

namespace MusicPlayer.Models
{
    //public class Song
    //{
    //    [DataMember(Name = "pictureUrl")]
    //    public string PictureUrl { get; set; }

    //    [DataMember(Name = "songUrl")]
    //    public string SongUrl { get; set; }

    //    [DataMember(Name = "songName")]
    //    public string SongName { get; set; }

    //    [DataMember(Name = "filmName")]
    //    public string FilmName { get; set; }
    //}

    //public class SongsCollection
    //{
    //    [DataMember(Name = "songs")]
    //    public List<Song> Songs { get; set; }
    //}

    public class Song
    {
        
        public string PictureUrl { get; set; }

        
        public string SongUrl { get; set; }

        
        public string SongName { get; set; }

        
        public string FilmName { get; set; }
    }

    public class SongsCollection
    {
        
        public List<Song> Songs { get; set; }
    }
}

