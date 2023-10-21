using Eception_File_Handling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SecondMain
{
    static void Main()
    {
        Dictionary<int, Movie> availableMovies = new Dictionary<int, Movie>
        {
            { 1, new Movie(1, "Movie A", "English") },
            { 2, new Movie(2, "Movie B", "Spanish") }
            // Add more movies as needed
        };

        List<Movie> overdueMovies = new List<Movie>();

        try
        {
            Customer customer1 = new Customer(1, 1);
            customer1.Borrow(availableMovies[customer1.MovieId], availableMovies, overdueMovies);

            // Simulate returning the movie after 12 days (2 days overdue)
            customer1.ReturnDate = DateTime.Now.AddDays(-2);

            // Attempt to borrow another movie that does not exist
            Customer customer2 = new Customer(2, 3);
            customer2.Borrow(availableMovies[customer2.MovieId], availableMovies, overdueMovies);
        }
        catch (Eception_File_Handling.InvalidDataException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Print list of overdue movies
        Console.WriteLine("\nOverdue Movies:");
        foreach (var movie in overdueMovies)
        {
            Console.WriteLine($"Movie ID: {movie.MovieId}, Name: {movie.MovieName}, Language: {movie.Language}");
        }
        Console.ReadLine();
    }
}

