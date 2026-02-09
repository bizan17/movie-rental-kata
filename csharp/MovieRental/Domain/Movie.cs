using MovieRental.Pricing;
using System;

namespace MovieRental.Domain
{
    /// <summary>
    /// Represents a movie available for rental.
    /// </summary>
    public class Movie
    {
        private readonly IPricingStrategy _pricingStrategy;

        /// <summary>
        /// Gets the title of the movie.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the category of the movie.
        /// </summary>
        public MovieCategory Category { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Movie class.
        /// </summary>
        /// <param name="title">The title of the movie.</param>
        /// <param name="category">The category of the movie.</param>
        /// <exception cref="ArgumentNullException">Thrown when title is null or empty.</exception>
        public Movie(string title, MovieCategory category)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title), "Movie title cannot be null or empty.");

            Title = title;
            Category = category;
            _pricingStrategy = PricingStrategyFactory.CreateStrategy(category);
        }

        /// <summary>
        /// Calculates the rental amount for this movie.
        /// </summary>
        /// <param name="daysRented">The number of days the movie is rented.</param>
        /// <returns>The calculated rental amount.</returns>
        public decimal CalculateAmount(int daysRented)
        {
            return _pricingStrategy.CalculateAmount(daysRented);
        }

        /// <summary>
        /// Calculates the frequent renter points for this rental.
        /// </summary>
        /// <param name="daysRented">The number of days the movie is rented.</param>
        /// <returns>The number of frequent renter points earned.</returns>
        public int CalculateFrequentRenterPoints(int daysRented)
        {
            return _pricingStrategy.CalculateFrequentRenterPoints(daysRented);
        }
    }
}