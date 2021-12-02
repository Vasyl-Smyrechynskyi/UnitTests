using System;
using Xunit;

namespace BerlinClock
{
    public class BerlinClockConverterTest
    {
        [InlineData(0, 0, 0, "Y")]
        [InlineData(0, 0, 1, "O")]
        [InlineData(0, 0, 2, "Y")]
        public void ConvertToBerlinClockValue_InitWithSeconds_ReturnsCorretRow1(int hours, int minutes, int seconds, string expected)
        {
            // Arange
            var converter = new BerlinClockConverter();

            // Act
            var result = converter.ConvertToBerlinClockValue(new TimeSpan(hours, minutes, seconds));

            // Assert
            Assert.Equal(expected, result.Row1);
        }

        [InlineData(0, 0, 0, "OOOO")]
        [InlineData(0, 1, 0, "YOOO")]
        [InlineData(0, 2, 0, "YYOO")]
        [InlineData(0, 5, 0, "OOOO")]
        public void ConvertToBerlinClockValue_InitWithMinutes_ReturnsCorretRow5(int hours, int minutes, int seconds, string expected)
        {
            // Arange
            var converter = new BerlinClockConverter();

            // Act
            var result = converter.ConvertToBerlinClockValue(new TimeSpan(hours, minutes, seconds));

            // Assert
            Assert.Equal(expected, result.Row5);
        }

        [InlineData(0, 0, 0, "OOOOOOOOOOO")]
        [InlineData(0, 5, 0, "YOOOOOOOOOO")]
        [InlineData(0, 6, 0, "YOOOOOOOOOO")]
        [InlineData(0, 10, 0, "YYOOOOOOOOO")]
        [InlineData(0, 15, 0, "YYROOOOOOOO")]
        public void ConvertToBerlinClockValue_InitWithMinutes_ReturnsCorretRow4(int hours, int minutes, int seconds, string expected)
        {
            // Arange
            var converter = new BerlinClockConverter();

            // Act
            var result = converter.ConvertToBerlinClockValue(new TimeSpan(hours, minutes, seconds));

            // Assert
            Assert.Equal(expected, result.Row4);
        }

        [InlineData(0, 0, 0, "OOOO")]
        [InlineData(1, 0, 0, "ROOO")]
        [InlineData(2, 0, 0, "RROO")]
        [InlineData(5, 0, 0, "OOOO")]
        public void ConvertToBerlinClockValue_InitWithHours_ReturnsCorretRow3(int hours, int minutes, int seconds, string expected)
        {
            // Arange
            var converter = new BerlinClockConverter();

            // Act
            var result = converter.ConvertToBerlinClockValue(new TimeSpan(hours, minutes, seconds));

            // Assert
            Assert.Equal(expected, result.Row3);
        }

        [InlineData(0, 0, 0, "OOOO")]
        [InlineData(5, 0, 0, "ROOO")]
        [InlineData(15, 0, 0, "RRRO")]
        [InlineData(23, 0, 0, "RRRR")]
        public void ConvertToBerlinClockValue_InitWithHours_ReturnsCorretRow2(int hours, int minutes, int seconds, string expected)
        {
            // Arange
            var converter = new BerlinClockConverter();

            // Act
            var result = converter.ConvertToBerlinClockValue(new TimeSpan(hours, minutes, seconds));

            // Assert
            Assert.Equal(expected, result.Row2);
        }

        [InlineData(0, 0, 0, "Y\nOOOO\nOOOO\nOOOOOOOOOOO\nOOOO")]
        [InlineData(16, 50, 6, "Y\nRRRO\nROOO\nYYRYYRYYRYO\nOOOO")]
        [InlineData(23, 59, 59, "O\nRRRR\nRRRO\nYYRYYRYYRYY\nYYYY")]
        [InlineData(11, 37, 01, "O\nRROO\nROOO\nYYRYYRYOOOO\nYYOO")]
        public void ConvertToBerlinClockValue_InitWithSpecicTime_ReturnsAllRowsCorrectly(int hours, int minutes, int seconds, string expected)
        {
            // Arange
            var converter = new BerlinClockConverter();

            // Act
            var result = converter.ConvertToBerlinClockValue(new TimeSpan(hours, minutes, seconds));

            // Assert
            Assert.Equal(expected, result.ToString());
        }
    }
}
