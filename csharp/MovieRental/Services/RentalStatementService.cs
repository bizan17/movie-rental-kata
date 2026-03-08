using System.Globalization;
using System.Text;
using MovieRental.Domain;

namespace MovieRental.Services
{
    /// <summary>
    /// Generates rental statements for customers.
    /// </summary>
    public class RentalStatementService
    {
        /// <summary>
        /// Generates a formatted statement of all rentals and the total amount owed for a customer.
        /// </summary>
        /// <param name="customer">The customer for whom to generate the statement.</param>
        /// <returns>A formatted rental statement string.</returns>
        public string GenerateStatement(Customer customer)
        {
            decimal totalAmount = 0;
            int frequentRenterPoints = 0;
            var result = new StringBuilder("Rental Record for " + customer.Name + "\n");

            foreach (Rental rental in customer.Rentals)
            {
                decimal rentalAmount = rental.Amount;
                int rentalPoints = rental.FrequentRenterPoints;

                result.Append("\t" + rental.Movie.Title + "\t" + FormatAmount(rentalAmount) + "\n");

                totalAmount += rentalAmount;
                frequentRenterPoints += rentalPoints;
            }

            result.Append("Amount owed is " + FormatAmount(totalAmount) + "\n");
            result.Append("You earned " + frequentRenterPoints.ToString() + " frequent renter points");

            return result.ToString();
        }

        private static string FormatAmount(decimal amount)
        {
            // Utilise la culture française (virgule comme séparateur)
            return amount.ToString("0.#", CultureInfo.GetCultureInfo("fr-FR"));
        }
    }
}
