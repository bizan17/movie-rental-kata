namespace MovieRental.Pricing
{
    /// <summary>
    /// Pricing strategy for children's movies.
    /// Base price: $1.5 for up to 3 days, then $1.5 per additional day.
    /// </summary>
    public class ChildrensMoviePricing : IPricingStrategy
    {
        private const decimal BaseAmount = 1.5m;
        private const int FreeDays = 3;
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