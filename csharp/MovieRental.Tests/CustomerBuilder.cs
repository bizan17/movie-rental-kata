using System.Collections.Generic;
using MovieRental.Domain;

namespace MovieRental.Tests
{
    /// <summary>
    /// Builder for creating <see cref="Customer"/> instances in tests.
    /// </summary>
    public class CustomerBuilder
    {
        /// <summary>
        /// The default customer name used when none is specified.
        /// </summary>
        public static readonly string Name = "Roberts";

        private string _name = Name;
        private List<Rental> _rentals = new List<Rental>();

        /// <summary>
        /// Builds and returns a <see cref="Customer"/> with the configured name and rentals.
        /// </summary>
        public Customer Build()
        {
            Customer result = new Customer(_name);
            foreach (Rental rental in _rentals)
            {
                result.AddRental(rental);
            }
            return result;
        }

        /// <summary>
        /// Sets the customer name.
        /// </summary>
        /// <param name="name">The name to assign.</param>
        public CustomerBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        /// <summary>
        /// Adds one or more rentals to the customer.
        /// </summary>
        /// <param name="rentals">The rentals to add.</param>
        public CustomerBuilder WithRentals(params Rental[] rentals)
        {
            _rentals.AddRange(rentals);
            return this;
        }
    }
}
