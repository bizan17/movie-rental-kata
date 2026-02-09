using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRental.Domain;
using MovieRental.Pricing;

namespace MovieRental.Tests
{
    [TestClass]
    public class PricingTests
    {
        #region Regular Movie Price Breaks

        [TestMethod]
        public void RegularMovie_OneDay_Returns2()
        {
            var strategy = new RegularMoviePricing();
            decimal amount = strategy.CalculateAmount(1);
            Assert.AreEqual(2m, amount, "1 day rental should cost base amount");
        }

        [TestMethod]
        public void RegularMovie_TwoDays_Returns2()
        {
            var strategy = new RegularMoviePricing();
            decimal amount = strategy.CalculateAmount(2);
            Assert.AreEqual(2m, amount, "2 days rental should cost base amount (at threshold)");
        }

        [TestMethod]
        public void RegularMovie_ThreeDays_Returns3Point5()
        {
            var strategy = new RegularMoviePricing();
            decimal amount = strategy.CalculateAmount(3);
            Assert.AreEqual(3.5m, amount, "3 days rental should add 1 extra day charge");
        }

        [TestMethod]
        public void RegularMovie_FiveDays_Returns6Point5()
        {
            var strategy = new RegularMoviePricing();
            decimal amount = strategy.CalculateAmount(5);
            Assert.AreEqual(6.5m, amount, "5 days rental should add 3 extra day charges");
        }

        [TestMethod]
        public void RegularMovie_Points_AlwaysReturns1()
        {
            var strategy = new RegularMoviePricing();
            
            Assert.AreEqual(1, strategy.CalculateFrequentRenterPoints(1));
            Assert.AreEqual(1, strategy.CalculateFrequentRenterPoints(2));
            Assert.AreEqual(1, strategy.CalculateFrequentRenterPoints(10));
        }

        #endregion

        #region New Release Price Breaks

        [TestMethod]
        public void NewRelease_OneDay_Returns3()
        {
            var strategy = new NewReleasePricing();
            decimal amount = strategy.CalculateAmount(1);
            Assert.AreEqual(3m, amount, "1 day rental should cost daily rate");
        }

        [TestMethod]
        public void NewRelease_TwoDays_Returns6()
        {
            var strategy = new NewReleasePricing();
            decimal amount = strategy.CalculateAmount(2);
            Assert.AreEqual(6m, amount, "2 days rental should cost 2x daily rate");
        }

        [TestMethod]
        public void NewRelease_ThreeDays_Returns9()
        {
            var strategy = new NewReleasePricing();
            decimal amount = strategy.CalculateAmount(3);
            Assert.AreEqual(9m, amount, "3 days rental should cost 3x daily rate");
        }

        [TestMethod]
        public void NewRelease_OneDay_Returns1Point()
        {
            var strategy = new NewReleasePricing();
            int points = strategy.CalculateFrequentRenterPoints(1);
            Assert.AreEqual(1, points, "1 day rental should give 1 point (at threshold)");
        }

        [TestMethod]
        public void NewRelease_TwoDays_Returns2Points()
        {
            var strategy = new NewReleasePricing();
            int points = strategy.CalculateFrequentRenterPoints(2);
            Assert.AreEqual(2, points, "2 days rental should give bonus point");
        }

        [TestMethod]
        public void NewRelease_ThreeDays_Returns2Points()
        {
            var strategy = new NewReleasePricing();
            int points = strategy.CalculateFrequentRenterPoints(3);
            Assert.AreEqual(2, points, "3+ days rental should give bonus point");
        }

        #endregion

        #region Childrens Movie Price Breaks

        [TestMethod]
        public void ChildrensMovie_OneDay_Returns1Point5()
        {
            var strategy = new ChildrensMoviePricing();
            decimal amount = strategy.CalculateAmount(1);
            Assert.AreEqual(1.5m, amount, "1 day rental should cost base amount");
        }

        [TestMethod]
        public void ChildrensMovie_ThreeDays_Returns1Point5()
        {
            var strategy = new ChildrensMoviePricing();
            decimal amount = strategy.CalculateAmount(3);
            Assert.AreEqual(1.5m, amount, "3 days rental should cost base amount (at threshold)");
        }

        [TestMethod]
        public void ChildrensMovie_FourDays_Returns3()
        {
            var strategy = new ChildrensMoviePricing();
            decimal amount = strategy.CalculateAmount(4);
            Assert.AreEqual(3m, amount, "4 days rental should add 1 extra day charge");
        }

        [TestMethod]
        public void ChildrensMovie_SixDays_Returns6()
        {
            var strategy = new ChildrensMoviePricing();
            decimal amount = strategy.CalculateAmount(6);
            Assert.AreEqual(6m, amount, "6 days rental should add 3 extra day charges");
        }

        [TestMethod]
        public void ChildrensMovie_Points_AlwaysReturns1()
        {
            var strategy = new ChildrensMoviePricing();
            
            Assert.AreEqual(1, strategy.CalculateFrequentRenterPoints(1));
            Assert.AreEqual(1, strategy.CalculateFrequentRenterPoints(3));
            Assert.AreEqual(1, strategy.CalculateFrequentRenterPoints(10));
        }

        #endregion
    }
}