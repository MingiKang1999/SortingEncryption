using System;
/// <summary>
/// Author: Mingi Kang
/// 
/// File Date: 10/31/2020
/// 
/// Purpose of the Class: Create single Song that can store artist's name
/// and album of the song, and display it in a neat format.
///
/// Citation: NA, NA.(2020). C# ROT13 Method. Retrived from https://thedeveloperblog.com/rot13
/// reference used for sorting: https://thedeveloperblog.com/rot13
/// </summary>

namespace Media_Sorting
{
    /// <summary>
    /// Inherting from the Media to categorize the object as
    /// Song that is a Media
    /// </summary>
    class Song : Media
    {
        private String album; // Name of the album
        private String artist; // Name of the artist

        /// <summary>
        ///  Creating a new Song with title, released year, album, and artist
        /// </summary>
        /// <param name="title">Enter the new title of the book</param>
        /// <param name="year">Enter the new year of the book</param>
        /// <param name="album">Enter the new album of the book</param>
        /// <param name="artist">Enter the new artist of the book</param>
        public Song(String title, int year, String album, String artist) : base(title, year)
        {
            Title = title; // Set the Media title to new title
            Year = year; // Set the Media year to new year
            this.album = album; // Set the new album
            this.artist = artist; // Set the new artist
        }

        /// <summary>
        /// Return the formatted data of the Song
        /// </summary>
        /// <returns>Return title, released year, album, and author of the song</returns>
        public override String ToString()
        {
            return "Song Title: " + Title + " " + "(" + Year + ")" + "\nAlbum: " + album + "  Artist: " + artist;
        }
    }
}
