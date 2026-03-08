using System.Collections.Generic;

namespace MovieRental.Domain
{
    /// <summary>
    /// Represents a customer who can rent movies.
    /// </summary>
    public class Customer
    {
        private readonly string _name;
        private readonly List<Rental> _rentals = new List<Rental>();

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// Gets the rentals associated with this customer.
        /// </summary>
        public IReadOnlyList<Rental> Rentals => _rentals;

        /// <summary>
        /// Initializes a new instance of the Customer class.
        /// </summary>
        /// <param name="name">The name of the customer.</param>
        public Customer(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Adds a rental to the customer's list of rentals.
        /// </summary>
        /// <param name="rental">The rental to add.</param>
        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }
    }
}
