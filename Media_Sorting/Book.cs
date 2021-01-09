using System;
/// <summary>
/// Author: Mingi Kang
/// 
/// File Date: 10/31/2020
/// 
/// Purpose of the Class: Create single Book that can store author's name
/// and summary of the book, and display it in a neat format.
/// 
/// Citation: NA, NA.(2020). C# ROT13 Method. Retrived from https://thedeveloperblog.com/rot13
/// reference used for sorting: https://thedeveloperblog.com/rot13
/// </summary>

namespace Media_Sorting
{
    /// <summary>
    /// Inherting from the Media to categorize the object as
    /// Book that is a Media
    /// </summary>
    class Book : Media
    {
        private String author; // Name of the author
        private String summary; // Summary of the book

        /// <summary>
        /// Creating a new Book with title, published year, author, and summary
        /// </summary>
        /// <param name="title">Enter the new title of the book</param>
        /// <param name="year">Enter the new year of the book</param>
        /// <param name="author">Enter the new author of the book</param>
        /// <param name="summary">Enter the new summary of the book</param>
        public Book(String title, int year, String author, String summary): base(title, year)
        {
            Title = title; // Set the Media title to new title
            Year = year; // Set the Media year to new year
            this.author = author; // Set the new author
            this.summary = summary; // Set the new summary
        }

        /// <summary>
        /// Set method that returns the stored summary
        /// </summary>
        /// <returns>Returns the summary of the Book</returns>
        public String GetSummary()
        {
            return summary;
        }

        /// <summary>
        /// Return the formatted data of the Book
        /// </summary>
        /// <returns>Return title, published year, and author of the book</returns>
        public override String ToString()
        {
            return "Book Title: " + Title + " " + "(" + Year + ")" + "\nAuthor: " + author;
        }
    }
}
