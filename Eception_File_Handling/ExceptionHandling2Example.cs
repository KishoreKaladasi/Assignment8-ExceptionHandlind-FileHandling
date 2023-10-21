using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eception_File_Handling
{

    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message) : base(message)
        {
        }
    }

    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Language { get; set; }

        public Movie(int movieId, string movieName, string language)
        {
            MovieId = movieId;
            MovieName = movieName ?? throw new InvalidDataException("Movie name cannot be null");
            Language = language ?? throw new InvalidDataException("Language cannot be null");
        }
    }

    public class Customer
    {
        public int CustId { get; set; }
        public DateTime BorrowDate { get; set; }
        public int MovieId { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Customer(int custId, int movieId)
        {
            CustId = custId;
            MovieId = movieId;
            BorrowDate = DateTime.Now;
        }

        public void Borrow(Movie movie, Dictionary<int, Movie> availableMovies, List<Movie> overdueMovies)
        {
            if (movie == null)
            {
                throw new InvalidDataException("Movie cannot be null");
            }

            if (!availableMovies.ContainsKey(movie.MovieId))
            {
                throw new InvalidDataException("Movie is not available");
            }

            availableMovies.Remove(movie.MovieId);
            ReturnDate = BorrowDate.AddDays(10);

            if (DateTime.Now > ReturnDate)
            {
                overdueMovies.Add(movie);
            }

            Console.WriteLine($"Customer {CustId} borrowed the movie '{movie.MovieName}' (ID: {movie.MovieId}) on {BorrowDate.ToShortDateString()}. Return by {ReturnDate?.ToShortDateString()}.");
        }
    }

}