using System;
using System.Collections.Generic;
using System.IO;
/// <summary>
/// Author: Mingi Kang
/// 
/// File Date: 10/31/2020
/// 
/// Purpose of the Program: Read the list of media stored in Data.txt file and sort them
/// by the category user chooses. The summary of movies and books are decrypted using
/// Rot13 algorithm.
/// 
/// Citation: NA, NA.(2020). C# ROT13 Method. Retrived from https://thedeveloperblog.com/rot13
/// reference used for sorting: https://thedeveloperblog.com/rot13
/// </summary>



namespace Media_Sorting
{
    /// <summary>
    /// This class allows the user to sort the media information
    /// using the different sets of category they can choose from
    /// </summary>
    class Program
    {
        /// <summary>
        /// The only part of the code with user interaction
        /// allowing the user to enter their choice for sorting category
        /// </summary>
        /// <param name="args">The choice is the command line argument in this code</param>
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green; // Change the text color green
            Console.WriteLine("Harry's Media Collection");
            Console.WriteLine("=======================");
            Console.ForegroundColor = ConsoleColor.White; // Change the etxt color back to white
            String choice;//User selection for the sorting category
            List<Media> allMedia = new List<Media>(); // Create a list array that will store all media
            allMedia = ReadData("Data.txt"); // Using ReadData method store the media information into allMedia variable
            Int32 length = allMedia.Count; // Count the total length of the media
            int i = 0;
            var temp1 = new Book("", 1, "", ""); // Creating empthy book object to compare the variable type
            var temp2 = new Movie("", 1, "", ""); // Creating empthy movie object to compare the variable type
            var temp3 = new Song("", 1, "", ""); // Creating empthy song object to compare the variable type
            do//This code is executed repeatedly unless the choice 6 is entered
            {
                choice = Menu();//Display the choices for the user
                switch (choice)//Determine the choice they made
                {
                    case "1": // Show all the books stored in the list
                        Console.WriteLine("");
                        while (i < length) // Loop until the end of the list
                        {
                            if (allMedia[i].GetType() == temp1.GetType()) // Compare and display all the books object
                            {
                                Console.WriteLine(allMedia[i]);
                                Console.WriteLine("-------------------------");
                            }
                            i++;
                        }
                        i = 0;
                        break;

                    case "2": // Show all the movies stored in the list
                        Console.WriteLine("");
                        while (i < length) // Loop until the end of the list
                        {
                            if (allMedia[i].GetType() == temp2.GetType()) // Compare and display all the movies object
                            {
                                Console.WriteLine(allMedia[i]);
                                Console.WriteLine("-------------------------");
                            }
                            i++;
                        }
                        i = 0;
                        break;

                    case "3": // Show all the songs stored in the list
                        Console.WriteLine("");
                        while (i < length) // Loop until the end of the list
                        {
                            if (allMedia[i].GetType() == temp3.GetType()) // Compare and display all the songs object
                            {
                                Console.WriteLine(allMedia[i]);
                                Console.WriteLine("-------------------------");
                            }
                            i++;
                        }
                        i = 0;
                        break;

                    case "4": // Show all media stored in the list
                        Console.WriteLine("");
                        while (i < length) // Loop until the end of the list
                        {
                            Console.WriteLine(allMedia[i]);
                            Console.WriteLine("-------------------------");
                            i++;
                        }
                        i = 0;
                        break;

                    case "5": // Search for title using key words
                        Console.Write("\nEnter Title: ");
                        String title = Console.ReadLine(); // Read the key word user has imputed
                        Console.WriteLine("");
                        while (i < length) // Loop until the end of the list
                        {
                            if (allMedia[i].Search(title)) // If the key word title does exist execute the following
                            {
                                Console.WriteLine(allMedia[i]);
                                if (allMedia[i].GetType() == temp1.GetType()) // If the title is related to a book display the summary
                                {
                                    Book some = (Book)allMedia[i]; // Creating a book object that is seperate from the list to use its funtions
                                    Console.WriteLine("");
                                    decrypt(some.GetSummary()); // Retrive the summary
                                    Console.WriteLine("-------------------------");
                                }
                                else if (allMedia[i].GetType() == temp2.GetType()) // If the title is related to a movie display the summary
                                {
                                    Movie some = (Movie)allMedia[i]; // Creating a movie object that is seperate from the list to use its funtions
                                    Console.WriteLine("");
                                    decrypt(some.GetSummary()); // Retrive the summary
                                    Console.WriteLine("-------------------------");
                                }
                            }
                            i++;
                        }
                        i = 0;
                        break;
                }
            } while (choice != "6");//Ends the loop and the program
        }

        /// <summary>
        /// Takes the text file and sort the media accordingly
        /// to create a list of different types of objects like books, movies, and songs.
        /// Book and Movie objects also stores the summary and Song will store the album
        /// </summary>
        /// <param name="fileName">Takes the text file and read the content</param>
        /// <returns>Returns list of media stored in the text file</returns>
        private static List<Media> ReadData(String fileName)
        {
            List<Media> media = new List <Media>(); // Creating a list array to store all the media
            try
            {
                StreamReader reader = new StreamReader(fileName); // Reading the content of the text file

                while (!reader.EndOfStream) //Read the text file until the end of data
                {
                    String line = reader.ReadLine(); // Read each line in the data

                    if (line.StartsWith("BOOK"))
                    {
                        String[] data = line.Split('|'); // Split the line into fields, seperated by |

                        String summary = reader.ReadLine();
                        String compare = "-----";
                        while (reader.ReadLine() != compare) // Store summary of the book until the next line is '-----' since books contain multiple lines of summary
                        {
                            summary = summary + "\n" + "\n" + reader.ReadLine();
                        }
                        media.Add(new Book(data[1], int.Parse(data[2]), data[3], summary)); // Create new book object
                    }
                    else if (line.StartsWith("MOVIE"))
                    {
                        String[] data = line.Split('|'); // Split the line into fields, seperated by |

                        String summary = reader.ReadLine(); // Store summary of the movie
                        String compare = "-----";
                        while (reader.ReadLine() != compare) // Store summary of the movie until the next line is '-----'
                        {
                            summary = summary + "\n" + "\n" + reader.ReadLine();
                        }
                        media.Add(new Movie(data[1], int.Parse(data[2]), data[3], summary)); // Create new movie object

                    }
                    else if (line.StartsWith("SONG"))
                    {
                        String[] data = line.Split('|'); // Split the line into fields, seperated by |

                        media.Add(new Song(data[1], int.Parse(data[2]), data[3], data[4])); // Create new song object
                    }
                }
                return media; // Will return employees Array to Main
            }
            catch (IOException) // Catch any specific exceptions that could be thrown
            {
                Console.WriteLine("ERROR FOUND WITH THE FILE");
                Environment.Exit(1);
            }
            return null; // Value is null if there is an error
        }

        /// <summary>
        /// Display the menu bar for the user to choose their option
        /// and collect the what the user entered as their choice
        /// </summary>
        /// <returns>choice for sorting category</returns>
        private static String Menu()
        {
            Console.WriteLine("\n1. List All Books");
            Console.WriteLine("2. List All Movies");
            Console.WriteLine("3. List All Songs");
            Console.WriteLine("4. List All Media");
            Console.WriteLine("5. Search All Media by Title");
            Console.WriteLine("\n6. Exit Program");
            Console.Write("\nEnter choice: ");
            String choice = Console.ReadLine();
            if (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6") // If user enters any other value, error message is prompt
            {
                Console.WriteLine("\nYou need to Enter a valid choice!!!"); // Error message
            }
            return choice;
        }

        /// <summary>
        /// Takes the summary from objects Book and Movie decrypt
        /// the words using Rot13 algorithm
        /// </summary>
        /// <param name="summary">Takes in the encrypted summary</param>
        private static void decrypt(String summary)
        {
            var decrypted = new List<IEncryptable>() // Creating a list encryptions
            {
                new Rot13(summary) // Add the encrypted summary to the list
            };
            foreach (var description in decrypted) // Decrypt each summary in the list
            {
                Console.WriteLine($"{description}"); // Display the decrypted summary
            }
        }
    }
}
