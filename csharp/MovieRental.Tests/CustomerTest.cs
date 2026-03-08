using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRental.Domain;
using MovieRental.Services;

namespace MovieRental.Tests
{
    [TestClass]
    public class CustomerTest
    {
        private readonly RentalStatementService _statementService = new RentalStatementService();

        [TestMethod]
        public void Customer_Default_IsNotNull()
        {
            Customer c = new CustomerBuilder().Build();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void Customer_AddRental_StatementContainsMovie()
        {
            Customer customer = new CustomerBuilder().WithName("Julia").Build();
            Movie movie = new Movie("Gone with the Wind", MovieCategory.Regular);
            Rental rental = new Rental(movie, 3);
            customer.AddRental(rental);
            StringAssert.Contains(_statementService.GenerateStatement(customer), "Gone with the Wind");
        }

        [TestMethod]
        public void Customer_Name_ReturnsConstructorValue()
        {
            Customer c = new Customer("David");
            Assert.AreEqual("David", c.Name);
        }

        [TestMethod]
        public void GenerateStatement_RegularMovie_ReturnsFormattedStatement()
        {
            Movie movie1 = new Movie("Gone with the Wind", MovieCategory.Regular);
            Rental rental1 = new Rental(movie1, 3); // 3 day rental
            Customer customer2 =
                    new CustomerBuilder()
                            .WithName("Sallie")
                            .WithRentals(rental1)
                            .Build();
            string expected = "Rental Record for Sallie\n" +
                    "\tGone with the Wind\t3,5\n" +
                    "Amount owed is 3,5\n" +
                    "You earned 1 frequent renter points";
            string statement = _statementService.GenerateStatement(customer2);
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void GenerateStatement_NewReleaseMovie_ReturnsFormattedStatement()
        {
            Movie movie1 = new Movie("Star Wars", MovieCategory.NewRelease);
            Rental rental1 = new Rental(movie1, 3); // 3 day rental
            Customer customer2 =
                    new CustomerBuilder()
                            .WithName("Sallie")
                            .WithRentals(rental1)
                            .Build();
            string expected = "Rental Record for Sallie\n" +
                    "\tStar Wars\t9\n" +
                    "Amount owed is 9\n" +
                    "You earned 2 frequent renter points";
            string statement = _statementService.GenerateStatement(customer2);
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void GenerateStatement_ChildrenMovie_ReturnsFormattedStatement()
        {
            Movie movie1 = new Movie("Madagascar", MovieCategory.Children);
            Rental rental1 = new Rental(movie1, 3); // 3 day rental
            Customer customer2
                    = new CustomerBuilder()
                    .WithName("Sallie")
                    .WithRentals(rental1)
                    .Build();
            string expected = "Rental Record for Sallie\n" +
                    "\tMadagascar\t1,5\n" +
                    "Amount owed is 1,5\n" +
                    "You earned 1 frequent renter points";
            string statement = _statementService.GenerateStatement(customer2);
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void GenerateStatement_MultipleMovies_ReturnsFormattedStatement()
        {
            Movie movie1 = new Movie("Madagascar", MovieCategory.Children);
            Rental rental1 = new Rental(movie1, 6); // 6 day rental
            Movie movie2 = new Movie("Star Wars", MovieCategory.NewRelease);
            Rental rental2 = new Rental(movie2, 2); // 2 day rental
            Movie movie3 = new Movie("Gone with the Wind", MovieCategory.Regular);
            Rental rental3 = new Rental(movie3, 8); // 8 day rental
            Customer customer1
                    = new CustomerBuilder()
                    .WithName("David")
                    .WithRentals(rental1, rental2, rental3)
                    .Build();
            string expected = "Rental Record for David\n" +
                    "\tMadagascar\t6\n" +
                    "\tStar Wars\t6\n" +
                    "\tGone with the Wind\t11\n" +
                    "Amount owed is 23\n" +
                    "You earned 4 frequent renter points";
            string statement = _statementService.GenerateStatement(customer1);
            Assert.AreEqual(expected, statement);
        }
    }
}
