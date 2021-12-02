using System;
using System.Threading.Tasks;
using Xunit;

namespace TDD
{
    public class LeapYearCheckerTests
    {
        [Theory]
        [InlineData("1996")]
        [InlineData("2000")]
        [InlineData("4")]
        [InlineData("20000")]
        [InlineData("888")]
        public void CheckIfLeapYear_WithValidStringYears_GivesTrue(string year)
        {
            // Arange
            var leapYearChecker = new LeapYearChecker();

            // Act
            var isLeap = leapYearChecker.CheckIfLeapYear(year);

            // Assert
            Assert.True(isLeap);
        }

        [Theory]
        [InlineData("100")]
        [InlineData("2001")]
        [InlineData("5")]
        [InlineData("20001")]
        [InlineData("889")]
        public void CheckIfLeapYear_WithValidStringYears_GivesFalse(string year)
        {
            // Arange
            var leapYearChecker = new LeapYearChecker();

            // Act
            var isLeap = leapYearChecker.CheckIfLeapYear(year);

            // Assert
            Assert.False(isLeap);
        }

        [Theory]
        [InlineData("48fd")]
        [InlineData(null)]
        public void CheckIfLeapYear_WithInvalidStringYear_Throws(string year)
        {
            var leapYearChecker = new LeapYearChecker();

            Assert.ThrowsAsync<InvalidCastException>(() => Task.FromResult(leapYearChecker.CheckIfLeapYear(year)));
        }
    }
}
