namespace MovieRental.Pricing
{
    /// <summary>
    /// Pricing strategy for regular movies.
    /// Base price: $2 for up to 2 days, then $1.5 per additional day.
    /// </summary>
    public class RegularMoviePricing : IPricingStrategy
    {
        private const decimal BaseAmount = 2m;
        private const int FreeDays = 2;
        private const decimal AdditionalDayRate = 1.5m;

        public decimal CalculateAmount(int daysRented)
        {
            var amount = BaseAmount;
            
            if (daysRented > FreeDays)
            {
                amount += (daysRented - FreeDays) * AdditionalDayRate;
            }
            
            return amount;
        }

        public int CalculateFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}