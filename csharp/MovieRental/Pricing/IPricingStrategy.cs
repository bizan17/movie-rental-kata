namespace MovieRental.Pricing
{
    /// <summary>
    /// Defines a strategy for calculating the rental price of a movie.
    /// </summary>
    public interface IPricingStrategy
    {
        /// <summary>
        /// Calculates the rental amount based on the number of days rented.
        /// </summary>
        /// <param name="daysRented">The number of days the movie is rented.</param>
        /// <returns>The calculated rental amount.</returns>
        decimal CalculateAmount(int daysRented);

        /// <summary>
        /// Calculates the frequent renter points earned for this rental.
        /// </summary>
        /// <param name="daysRented">The number of days the movie is rented.</param>
        /// <returns>The number of frequent renter points earned.</returns>
        int CalculateFrequentRenterPoints(int daysRented);
    }
}