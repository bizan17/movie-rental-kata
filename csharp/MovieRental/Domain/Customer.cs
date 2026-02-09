using System.Collections.Generic;
using System.Globalization;

namespace MovieRental.Domain
{
    public class Customer
    {
        private string _name;
        private List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public void addRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string getName()
        {
            return _name;
        }

        public string statement()
        {
            decimal totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + getName() + "\n";

            foreach (Rental each in _rentals)
            {
                decimal thisAmount = each.GetAmount();
                int thisPoints = each.GetFrequentRenterPoints();

                // show figures for this rental
                result += "\t" + each.Movie.Title + "\t" + FormatAmount(thisAmount) + "\n";
                
                totalAmount += thisAmount;
                frequentRenterPoints += thisPoints;
            }

            // add footer lines
            result += "Amount owed is " + FormatAmount(totalAmount) + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";

            return result;
        }

        private static string FormatAmount(decimal amount)
        {
            // Utilise la culture française (virgule comme séparateur)
            return amount.ToString("0.#", CultureInfo.GetCultureInfo("fr-FR"));
        }
    }
}