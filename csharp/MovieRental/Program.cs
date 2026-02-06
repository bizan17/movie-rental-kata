using System;

namespace MovieRental
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Movie Rental System ===\n");

            // Create films
            var movie1 = new Movie("The Matrix", Movie.NEW_RELEASE);
            var movie2 = new Movie("Toy Story", Movie.CHILDRENS);
            var movie3 = new Movie("Casablanca", Movie.REGULAR);

            // Create rent
            var rental1 = new Rental(movie1, 3);
            var rental2 = new Rental(movie2, 5);
            var rental3 = new Rental(movie3, 2);

            // Create client
            var customer = new Customer("John Doe");
            customer.addRental(rental1);
            customer.addRental(rental2);
            customer.addRental(rental3);

            // display statement
            string statement = customer.statement();
            Console.WriteLine(statement);
        }
    }
}