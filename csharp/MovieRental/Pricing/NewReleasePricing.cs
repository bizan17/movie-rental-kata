namespace MovieRental.Pricing
{
    /// <summary>
    /// Pricing strategy for new release movies.
    /// Price: $3 per day.
    /// Bonus: 2 frequent renter points if rented for more than 1 day.
    /// </summary>
    public class NewReleasePricing : IPricingStrategy
    {
        private const decimal DailyRate = 3m;
        private const int BonusPointsThreshold = 1;

        public decimal CalculateAmount(int daysRented)
        {
            return daysRented * DailyRate;
        }

        public int CalculateFrequentRenterPoints(int daysRented)
        {
            return daysRented > BonusPointsThreshold ? 2 : 1;
        }
    }
}