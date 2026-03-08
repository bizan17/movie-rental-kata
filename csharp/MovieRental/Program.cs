using System;
using MovieRental.Domain;
using MovieRental.Services;

namespace MovieRental
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Movie Rental System ===\n");

            var movie1 = new Movie("The Matrix", MovieCategory.NewRelease);
            var movie2 = new Movie("Toy Story", MovieCategory.Children);
            var movie3 = new Movie("Casablanca", MovieCategory.Regular);

            var rental1 = new Rental(movie1, 3);
            var rental2 = new Rental(movie2, 5);
            var rental3 = new Rental(movie3, 2);

            var customer = new Customer("John Doe");
            customer.AddRental(rental1);
            customer.AddRental(rental2);
            customer.AddRental(rental3);

            var statementService = new RentalStatementService();
            string statement = statementService.GenerateStatement(customer);
            Console.WriteLine(statement);
        }
    }
}
