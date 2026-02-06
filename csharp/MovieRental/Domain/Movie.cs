using System;

namespace MovieRental.Domain
{
    /// <summary>
    /// Represents a movie available for rental.
    /// </summary>
    public class Movie
    {
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
        }
    }
}