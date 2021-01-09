using System;
/// <summary>
/// Author: Mingi Kang
/// 
/// File Date: 10/31/2020
/// 
/// Purpose of the Class: Create single Movie that can store director's name
/// and summary of the movie, and display it in a neat format.
/// 
/// Citation: NA, NA.(2020). C# ROT13 Method. Retrived from https://thedeveloperblog.com/rot13
/// reference used for sorting: https://thedeveloperblog.com/rot13
/// </summary>

namespace Media_Sorting
{
    /// <summary>
    /// Inherting from the Media to categorize the object as
    /// Movie that is a Media
    /// </summary>
    class Movie : Media
    {
        private String director; // Name of the director
        private String summary; // Summary of the movie

        /// <summary>
        /// Creating a new Movie with title, theater released year, director, and summary
        /// </summary>
        /// <param name="title">Enter the new title of the book</param>
        /// <param name="year">Enter the new year of the book</param>
        /// <param name="director">Enter the new director of the book</param>
        /// <param name="summary">Enter the new summary of the book</param>
        public Movie(String title, int year, String director, String summary) : base(title, year)
        {
            Title = title; // Set the Media title to new title
            Year = year; // Set the Media year to new year
            this.director = director; // Set the new director
            this.summary = summary; // Set the summary
        }

        /// <summary>
        /// Set method that returns the stored summary
        /// </summary>
        /// <returns>Returns the summary of the Movie</returns>
        public String GetSummary()
        {
            return summary;
        }

        /// <summary>
        /// Return the formatted data of the Movie
        /// </summary>
        /// <returns>Returns title, theater released year, and author of the Movie</returns>
        public override String ToString()
        {
            return "Movie Title: " + Title + " " + "(" + Year + ")" + "\nDirector: " + director;
        }
    }
}
