using MovieRental.Domain;
using System;

namespace MovieRental.Pricing
{
    /// <summary>
    /// Factory for creating pricing strategies based on movie category.
    /// </summary>
    public class PricingStrategyFactory
    {
        /// <summary>
        /// Creates the appropriate pricing strategy for the given movie category.
        /// </summary>
        /// <param name="category">The category of the movie.</param>
        /// <returns>The pricing strategy instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the category is not recognized.</exception>
        public static IPricingStrategy CreateStrategy(MovieCategory category)
        {
            return category switch
            {
                MovieCategory.Regular => new RegularMoviePricing(),
                MovieCategory.NewRelease => new NewReleasePricing(),
                MovieCategory.Childrens => new ChildrensMoviePricing(),
                _ => throw new ArgumentException($"Unknown movie category: {category}", nameof(category))
            };
        }
    }
}