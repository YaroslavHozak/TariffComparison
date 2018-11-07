using System;
using NUnit.Framework;
using TariffComparison;

namespace UnitTests
{
    [TestFixture]
    public class BasicTariff_GetAnnualCosts
    {
        [Test]
        [TestCase(3500, 830)]
        [TestCase(6000, 1380)]
        [TestCase(0, 60)]
        public void ShouldReturnValidAnnualCosts(int consumption, int cost)
        {
            // Arrange
            var basicTariff = new BasicTariff();

            // Act
            var annualCosts = basicTariff.GetAnnualCosts(consumption);

            // Assert
            Assert.AreEqual(cost, annualCosts, "Annual cost calculated incorrectly");
        }

        [Test]
        [TestCase(-1)]
        public void ShouldThroughArgumentException(double consumption)
        {
            // Arrange
            var basicTariff = new BasicTariff();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => basicTariff.GetAnnualCosts(consumption), "Should throw ArgumentException when consumption less 0");
        }
    }
}
