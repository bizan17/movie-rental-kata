using System;

namespace MovieRental.Domain
{
    /// <summary>
    /// Represents a movie rental transaction.
    /// </summary>
    public class Rental
    {
        /// <summary>
        /// Gets the movie being rented.
        /// </summary>
        public Movie Movie { get; }

        /// <summary>
        /// Gets the number of days the movie is rented.
        /// </summary>
        public int DaysRented { get; }

        /// <summary>
        /// Initializes a new instance of the Rental class.
        /// </summary>
        /// <param name="movie">The movie being rented.</param>
        /// <param name="daysRented">The number of days the movie is rented.</param>
        /// <exception cref="ArgumentNullException">Thrown when movie is null.</exception>
        /// <exception cref="ArgumentException">Thrown when daysRented is less than or equal to 0.</exception>
        public Rental(Movie movie, int daysRented)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "Movie cannot be null.");

            if (daysRented <= 0)
                throw new ArgumentException("Days rented must be greater than zero.", nameof(daysRented));

            Movie = movie;
            DaysRented = daysRented;
        }
    }
}